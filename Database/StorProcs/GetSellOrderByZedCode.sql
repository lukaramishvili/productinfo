-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetSellOrderByZedCode]
	-- Add the parameters for the stored procedure here
	@zed_ident nvarchar(MAX) output
	,@zed_tarigi datetime = now output
	,@buyer_ident nvarchar(MAX) = N'0' output
	,@buyer_name nvarchar(MAX) = N'noname' output
	,@buyer_address nvarchar(MAX) = N'nowhere' output
	,@zed_sum decimal(28,13) = 0.0 output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT @zed_ident = z.id_code
			,@zed_tarigi = z.dro
			,@buyer_ident = b.id_code
			,@buyer_name = b.name
			,@buyer_address = b.address 
			,@zed_sum = SUM(sold.piece_count*sold.piece_price)
						
	FROM (SELECT * FROM dbo.SellOrder WHERE SellOrder.zednadebis_nomeri = @zed_ident) SO
	LEFT JOIN zednadebi z
	ON(z.operation='Sell' AND z.id_code = SO.zednadebis_nomeri)
	LEFT JOIN buyers b
	ON(z.client_id = b.id_code)
	LEFT JOIN SoldRemainders sold
	ON(sold.SellOrder_id=SO.id)
	LEFT JOIN remainders r
	ON(r.id = sold.remainder_id)
	LEFT JOIN products p
	ON(p.barcode = r.product_barcode)
	GROUP BY z.id_code, z.dro, b.id_code, b.name, b.address
	
	SELECT 
			p.name as product_barcode
			,p.name as product_name
			,sold.piece_count as piece_count
			,sold.piece_price as piece_price
			,SUM(sold.piece_price*sold.piece_count) as product_sum 
			
	FROM (SELECT * FROM dbo.SellOrder WHERE SellOrder.zednadebis_nomeri = @zed_ident) SO
	LEFT JOIN zednadebi z
	ON(z.operation='Sell' AND z.id_code = SO.zednadebis_nomeri)
	LEFT JOIN buyers b
	ON(z.client_id = b.id_code)
	
	LEFT JOIN (SELECT MIN(SoldRemainders.id) AS id,
					MIN(SoldRemainders.remainder_id) AS remainder_id,
					MIN(SoldRemainders.SellOrder_id) AS SellOrder_id,
					SUM(SoldRemainders.piece_count) AS piece_count,
					--MIN(SoldRemainders.piece_price) AS piece_price
					SUM(SoldRemainders.piece_count*SoldRemainders.piece_price)/SUM(SoldRemainders.piece_count) AS piece_price
					FROM SoldRemainders, remainders 
					WHERE SoldRemainders.remainder_id = remainders.id
					GROUP BY remainders.product_barcode, SoldRemainders.SellOrder_id
			) sold	
	ON(sold.SellOrder_id=SO.id)
	
	LEFT JOIN remainders r
	ON(r.id = sold.remainder_id)
	LEFT JOIN products p
	ON(p.barcode = r.product_barcode)
	GROUP BY z.id_code, z.dro, b.id_code, b.name, b.address, p.barcode, p.name, sold.id, sold.piece_count, sold.piece_price
	
END
