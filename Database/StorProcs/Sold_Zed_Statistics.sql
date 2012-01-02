-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sold_Zed_Statistics]
	--@zed_ident nvarchar(MAX) output,
	--@tarigi datetime output,
	--@supplier_name nvarchar(MAX) output,
	--@af_seria nvarchar(MAX) output,
	--@af_nomeri nvarchar(MAX) output
	@since_date datetime
	,@until_date datetime
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	
	SELECT z.id_code AS zed_ident,
			z.dro AS tarigi,
			b.name as buyer_name,
			af.af_seria as af_seria,
			af.af_nomeri as af_nomeri,
			SUM(sold.piece_count*r.buy_price) as self_cost,
			SUM(dbo.CostWithoutVAT(sold.piece_count*r.buy_price,p.uses_vat)) as self_cost_withoutVAT,
			AVG(mt.amount) as incoming_amount, --SUM(CASE so.pay_method WHEN 'Nagdi' THEN sold.piece_count*sold.piece_price WHEN 'Konsignacia' THEN 0 END) as income,
			SUM(sold.piece_count*r.buy_price) + SUM( sold.piece_count*(sold.piece_price-r.buy_price) ) as zed_cost, -- SUM(CASE so.pay_method WHEN 'Nagdi' THEN dbo.CostWithoutVAT(sold.piece_count*sold.piece_price,p.uses_vat) WHEN 'Konsignacia' THEN 0 END) as income_withoutVAT,
			SUM( sold.piece_count*(sold.piece_price-r.buy_price) ) as mogeba,
			SUM( dbo.CostWithoutVAT(sold.piece_count*(sold.piece_price-r.buy_price),p.uses_vat) ) as mogeba_withoutVAT,
			--SUM(CASE so.pay_method WHEN 'Nagdi' THEN sold.piece_count*(sold.piece_price-r.buy_price) WHEN 'Konsignacia' THEN 0 END) as mogeba,
			--SUM(CASE so.pay_method WHEN 'Nagdi' THEN dbo.CostWithoutVAT(sold.piece_count*(sold.piece_price-r.buy_price),p.uses_vat) WHEN 'Konsignacia' THEN 0 END) as mogeba_withoutVAT
			SUM(sold.piece_count*sold.piece_price)-SUM(dbo.CostWithoutVAT(sold.piece_count*sold.piece_price,p.uses_vat)) as VAT_tax,
			SUM(dbo.CostWithoutVAT(sold.piece_count*sold.piece_price,p.uses_vat)) as price_withoutVAT
	FROM (SELECT * FROM zednadebi WHERE zednadebi.operation='Sell' AND zednadebi.dro >= @since_date AND zednadebi.dro <= @until_date) as z
	LEFT JOIN buyers as b
	ON (z.client_id = b.id_code)
	LEFT JOIN angarishfaqtura as af
	ON (z.af_nomeri = af.af_nomeri AND z.af_seria = z.af_seria)
	LEFT JOIN SellOrder so
	ON(so.zednadebis_nomeri=z.id_code AND so.buyer_ident_code=z.client_id)
	LEFT JOIN SoldRemainders sold
	ON(sold.SellOrder_id = so.id)
	LEFT JOIN remainders r 
	ON(r.id = sold.remainder_id)
	LEFT JOIN products p
	ON (p.barcode = r.product_barcode)
	LEFT JOIN 
	(
	SELECT client_type, client_id, type, purpose, target_type, target_ident, SUM(amount) as amount FROM money_transfer 
	GROUP BY client_type, client_id, type, purpose, target_type, target_ident
	) mt
	ON(mt.client_type = 'ProductInfo.Buyer' AND mt.client_id = b.id_code AND mt.type = 'Take' AND mt.purpose = 'PayFor' AND mt.target_type = 'ProductInfo.Zednadebi' AND mt.target_ident = z.id_code)
	
	GROUP BY z.id_code, z.dro, b.name, af.af_seria, af.af_nomeri
	ORDER BY z.dro DESC
	
	
	
	
	--SELECT zednadebi.id_code as zed_ident, 
	--		zednadebi.dro as tarigi,
	--		suppliers.name as supplier_name,
	--		angarishfaqtura.af_seria as af_seria,
	--		angarishfaqtura.af_nomeri as af_nomeri
	--FROM zednadebi, angarishfaqtura, suppliers
	--WHERE zednadebi.af_seria=angarishfaqtura.af_seria AND
	--		zednadebi.af_nomeri = angarishfaqtura.af_nomeri AND 
	--		zednadebi.client_id = suppliers.id_code
			
	

END
