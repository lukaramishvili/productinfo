-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Agcera_Statistics]
	-- Add the parameters for the stored procedure here
	@StoreID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT r.product_barcode as barcode
	, p.name as product_name
	,r.storehouse_id as store_id
	,s.name as supplier_name
	,z.id_code as zed_nomeri
	,z.dro as zed_tarigi
	,a.af_seria as af_seria
	,a.af_nomeri as af_nomeri
	,a.dro as af_tarigi
	,r.remaining_pieces as remaining
	,dbo.CostWithoutVAT(r.buy_price,p.uses_vat) as price_without_VAT
	,r.buy_price as price_with_VAT
	
	FROM (SELECT * FROM dbo.remainders WHERE remaining_pieces > 0) r
	LEFT JOIN products p ON (p.barcode = r.product_barcode)
	LEFT JOIN suppliers s ON (s.id_code = r.supplier_ident)
	LEFT JOIN zednadebi z ON (z.client_id = s.id_code AND z.operation = 'Buy' AND z.id_code = r.zednadebis_nomeri)
	LEFT JOIN angarishfaqtura a ON (z.af_seria = a.af_seria AND z.af_nomeri = a.af_nomeri)
	
	
END
