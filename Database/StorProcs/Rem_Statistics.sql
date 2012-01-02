-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Rem_Statistics]
	-- Add the parameters for the stored procedure here
	@StoreID int
	, @FromTime datetime
	, @ToTime datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @FilterStoreID nvarchar(MAX)
	IF @StoreID = 0 
		SET @FilterStoreID = '%'
	ELSE
		SET @FilterStoreID = CONVERT(nvarchar(MAX),@StoreID)
	

    -- Insert statements for procedure here
    SELECT * FROM 
		( SELECT r.id as r_id,
			r.product_barcode AS PBarcode,
			p.name as PName,
			s.name as SupplierName,
			r.zednadebis_nomeri as zednadebis_nomeri,
			r.pack_capacity as capacity,
			r.storehouse_id as store_id,
			CONVERT(nvarchar(MAX),((r.remaining_pieces+ISNULL(sold_after.piece_count,0))/r.pack_capacity))+'  /  '+CONVERT(nvarchar(MAX),(r.initial_pieces/r.pack_capacity))+'  :  '+CONVERT(nvarchar(MAX),(CONVERT(dec(38,2),ROUND((r.remaining_pieces+ISNULL(sold_after.piece_count,0)),2)))) as remaining_pieces,
			r.buy_price AS piece_cost,
			r.sell_price AS piece_sell_price,
			SUM(r.remaining_pieces * r.sell_price) AS sum_sell_price,
			SUM((r.initial_pieces)*r.buy_price) AS initial_whole_cost,
			SUM((r.remaining_pieces+ISNULL(sold_after.piece_count,0))*r.buy_price) AS whole_cost,
			SUM(dbo.CostWithoutVAT((r.remaining_pieces+ISNULL(sold_after.piece_count,0))*r.buy_price,p.uses_vat)) AS whole_cost_withoutVAT
			
		FROM 
			(	SELECT remainders.* FROM remainders, zednadebi
				WHERE 
							--remainders.remaining_pieces > 0 AND 
							remainders.storehouse_id LIKE @FilterStoreID 
							AND zednadebi.client_id = remainders.supplier_ident
							AND zednadebi.operation = 'Buy'
							AND zednadebi.id_code = remainders.zednadebis_nomeri
							AND zednadebi.dro > @FromTime
							AND zednadebi.dro < @ToTime
			) r 
		LEFT JOIN products AS p
		ON ( p.barcode = r.product_barcode)
		LEFT JOIN suppliers as s
		ON (r.supplier_ident = s.id_code)
		LEFT JOIN (	
						SELECT SUM(SoldRemainders.piece_count) AS piece_count, SoldRemainders.remainder_id
						FROM SoldRemainders, SellOrder
						WHERE SoldRemainders.SellOrder_id = SellOrder.id 
							AND SellOrder.dro > @ToTime
						GROUP BY remainder_id
					) sold_after
		ON(sold_after.remainder_id = r.id)
		
		GROUP BY r.id, r.storehouse_id, s.id_code, r.product_barcode, p.name, s.name, r.pack_capacity, r.remaining_pieces, r.buy_price, r.sell_price, r.initial_pieces, sold_after.piece_count, r.zednadebis_nomeri
	) complex_select
	WHERE whole_cost > 0
	
	
END
