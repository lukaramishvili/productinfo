-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Gasavali
	-- Add the parameters for the stored procedure here
	@SellOrderID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		p.name as dasaxeleba
		, sold.piece_count/r.pack_capacity as yutebis_raodenoba
		, sold.piece_price*r.pack_capacity as yutis_fasi
		, sold.piece_count as sacalo_raodenoba
		, sold.piece_price as sacalo_fasi
		, sold.piece_count * sold.piece_price as sul_fasi
		
	FROM products p, remainders r, SoldRemainders sold, SellOrder SO
	WHERE SO.id = @SellOrderID
	AND sold.SellOrder_id = SO.id
	AND r.id = sold.remainder_id
	AND p.barcode = r.product_barcode
END
