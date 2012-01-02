-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SellOrder_Details]
	-- Add the parameters for the stored procedure here
	@SellOrderID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
	SELECT sold.id, p.barcode
	, p.name as prod_name
	, sold.piece_count as piece_count
	, r.buy_price as sacalo_ghirebuleba
	, sold.piece_count*r.buy_price as ghirebuleba
	, sold.piece_price as piece_price
	, sold.piece_count*sold.piece_price as whole_price
	, (sold.piece_count*sold.piece_price) - (sold.piece_count*r.buy_price) as mogeba
	, (dbo.CostWithoutVAT(sold.piece_count*sold.piece_price,p.uses_vat)) as ghirebuleba_VAT_gareshe--(dbo.CostWithoutVAT(sold.piece_count*r.buy_price,p.uses_vat))
	, r.storehouse_id as store_id
	FROM (SELECT * FROM SoldRemainders WHERE SellOrder_id = @SellOrderID) sold
	LEFT JOIN remainders r 
	ON(sold.remainder_id = r.id)
	LEFT JOIN products p
	ON(r.product_barcode = p.barcode)
	LEFT JOIN SellOrder so
	ON(sold.SellOrder_id = so.id)
	
END
