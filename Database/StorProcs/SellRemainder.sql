-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SellRemainder]
	-- Add the parameters for the stored procedure here
	@barcode nvarchar(MAX),
	@storeID int,
	@selling_count decimal(28,13),
	@piece_price decimal(28,13),
	@SellOrderID int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
IF 0 >= @selling_count OR 0 >= @piece_price
	RETURN 1

DECLARE @using_check int = (SELECT using_check FROM SellOrder WHERE id = @SellOrderID);

DECLARE @SuppIdentNotToSell nvarchar(MAX) = '007';

IF @using_check=0 
	SELECT @SuppIdentNotToSell = 'no_supplier_exists_with_such_ident_code';

IF (SELECT COUNT(*) FROM dbo.SoldRemainders, dbo.remainders
					WHERE SoldRemainders.SellOrder_id=@SellOrderID
					  AND SoldRemainders.remainder_id = remainders.id
					  AND remainders.product_barcode = @barcode
					  --AND remainders.storehouse_id = @storeID
					  AND 1 = dbo.RemainderHasStoreAsSellableParent(remainders.id, @storeID)
					)>0
	RETURN 183
IF (SELECT COUNT(*) FROM dbo.SoldRemainders, dbo.remainders
					WHERE SoldRemainders.SellOrder_id=@SellOrderID
					  AND SoldRemainders.remainder_id = remainders.id
					  AND remainders.product_barcode = @barcode
					  --AND remainders.storehouse_id != @storeID
					  AND 0 = dbo.RemainderHasStoreAsSellableParent(remainders.id, @storeID)
					  AND (SoldRemainders.piece_price != @piece_price)
					)>0
	RETURN 183


DECLARE @left_to_sell decimal(28,13) = @selling_count

DECLARE @affected_rem_id int = 0

DECLARE @sold_on_this_loop decimal(28,13) = 0

--IF (SELECT SUM(remaining_pieces) FROM remainders WHERE product_barcode = @barcode AND storehouse_id = @storeID AND supplier_ident != @SuppIdentNotToSell)<@selling_count
IF (SELECT SUM(remaining_pieces) FROM remainders WHERE product_barcode = @barcode AND 1 = dbo.RemainderHasStoreAsSellableParent(id, @storeID) AND supplier_ident != @SuppIdentNotToSell)<@selling_count
	RETURN 404

	

WHILE @left_to_sell > 0
BEGIN
	--check if there is some remainder with >0 left pieces
	SELECT @affected_rem_id = (SELECT TOP (1) r.id FROM remainders r, zednadebi z WHERE 
																    product_barcode = @barcode
																--AND r.storehouse_id = @storeID
																AND 1 = dbo.RemainderHasStoreAsSellableParent(r.id, @storeID)
																AND r.remaining_pieces > 0
																AND r.supplier_ident != @SuppIdentNotToSell
																
																AND z.operation = 'Buy'
																AND z.client_id = r.supplier_ident
																AND z.id_code = r.zednadebis_nomeri
																
																ORDER BY z.dro ASC
																)
	IF @affected_rem_id = 0 
		RETURN 404
	
	DECLARE @this_rem_can_sell decimal(28,13) = (SELECT dbo.MinDecimal(@left_to_sell, remaining_pieces) FROM remainders WHERE id = @affected_rem_id)
	
	IF NOT (@this_rem_can_sell > 0)
		RETURN 404	
		
	--shevamocmot rom produqtis shemosvlis tarigze adrindeli tarigit ar gaiyidos
	IF (SELECT COUNT(zednadebi.id) FROM zednadebi, remainders, SellOrder WHERE 
													remainders.id = @affected_rem_id 
												AND zednadebi.id_code = remainders.zednadebis_nomeri 
												AND zednadebi.operation = 'Buy' 
												AND zednadebi.client_id = remainders.supplier_ident
												
												AND SellOrder.id = @SellOrderID
												AND zednadebi.dro>=SellOrder.dro
												)>0
		RETURN 10022
							
	--sell the amount we can sell on this loop
		UPDATE remainders SET 
			remaining_pieces -= @this_rem_can_sell
			WHERE id = @affected_rem_id
			
		IF @@ROWCOUNT = 0 
			RETURN 404
		
		SELECT @sold_on_this_loop = @this_rem_can_sell
		
		--we have now less to sell
		SELECT @left_to_sell -= @this_rem_can_sell
		
		
	INSERT INTO dbo.SoldRemainders
           (remainder_id
           ,SellOrder_id
           ,piece_count
           ,piece_price)
     VALUES
           (@affected_rem_id
           ,@SellOrderID
           ,@sold_on_this_loop
           ,@piece_price)
           
     IF @@ROWCOUNT = 0 
		RETURN 404
      
	
END
--END WHILE

RETURN 0
	
END

