-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SplitRemainder]
	-- Add the parameters for the stored procedure here
	  @Rem_ID int
	, @ToStoreID int
	, @PieceCount decimal(28,13)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF @Rem_ID IS NULL OR @ToStoreID IS NULL OR @PieceCount IS NULL OR @Rem_ID = 0 OR @ToStoreID = 0 OR @PieceCount = 0
		RETURN 1
	
    IF NOT ((SELECT remaining_pieces FROM remainders WHERE id = @Rem_ID) >= @PieceCount) RETURN 404
	
	
	DECLARE @m_barcode nvarchar(MAX), @m_supp_ident nvarchar(MAX), @m_zed_ident nvarchar(MAX), @m_store_id int, @m_buy_price decimal(28,13), @m_sell_price decimal(28,13), @m_capacity decimal(28,13)
	SELECT @m_barcode = product_barcode, @m_supp_ident = supplier_ident, @m_zed_ident = zednadebis_nomeri, @m_store_id = storehouse_id, @m_buy_price = buy_price, @m_sell_price = sell_price, @m_capacity = pack_capacity
	FROM remainders WHERE id = @Rem_ID
    
    
    
    -- Insert statements for procedure here
    IF (SELECT COUNT(*) FROM remainders WHERE product_barcode = @m_barcode
												AND supplier_ident = @m_supp_ident
												AND zednadebis_nomeri = @m_zed_ident
												AND storehouse_id = @ToStoreID
												--AND id != @Rem_ID
												 )> 0
    BEGIN
		UPDATE remainders SET remaining_pieces -= @PieceCount, initial_pieces -= @PieceCount WHERE id = @Rem_ID
		UPDATE remainders SET remaining_pieces += @PieceCount, initial_pieces+=@PieceCount WHERE product_barcode = @m_barcode
												AND supplier_ident = @m_supp_ident
												AND zednadebis_nomeri = @m_zed_ident
												AND storehouse_id = @ToStoreID
    END
    ELSE
    BEGIN
		UPDATE remainders SET remaining_pieces -= @PieceCount, initial_pieces -= @PieceCount WHERE id = @Rem_ID
		EXEC dbo.AddRemainder @m_barcode, @m_supp_ident, @m_zed_ident, @PieceCount, @PieceCount, @m_capacity, @m_buy_price, @m_sell_price, @ToStoreID 
    END
    
    RETURN 0
    
	
END
