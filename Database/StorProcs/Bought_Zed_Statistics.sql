-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bought_Zed_Statistics]
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
			s.name as supplier_name,
			af.af_seria as af_seria,
			af.af_nomeri as af_nomeri,
			SUM(r.buy_price*r.initial_pieces),
			SUM(dbo.CostWithoutVAT(r.buy_price*r.initial_pieces,p.uses_vat))
	FROM (SELECT * FROM zednadebi WHERE zednadebi.operation='Buy' AND zednadebi.dro >= @since_date AND zednadebi.dro <= @until_date) as z
	LEFT JOIN suppliers as s
	ON (z.client_id = s.id_code)
	LEFT JOIN angarishfaqtura as af
	ON (z.af_nomeri = af.af_nomeri AND z.af_seria = af.af_seria)
	LEFT JOIN remainders r 
	ON(r.zednadebis_nomeri = z.id_code AND r.supplier_ident = z.client_id)
	LEFT JOIN products p
	ON (p.barcode = r.product_barcode)
	GROUP BY z.id_code, z.dro, s.name, af.af_seria, af.af_nomeri
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
			
	
	--DECLARE @zed_ident nvarchar(MAX)
	--DECLARE @tarigi datetime
	--DECLARE @supplier_name nvarchar(MAX)
	--DECLARE @af_seria nvarchar(MAX)
	--DECLARE @af_nomeri nvarchar(MAX)

	--SELECT @zed_ident = zeds.id_code,
	--		@tarigi=zeds.dro, 
	--		@supplier_name = supps.name,
	--		@af_seria = afs.af_seria,
	--		@af_nomeri = afs.af_nomeri
	--		FROM dbo.zednadebi AS zeds--, dbo.suppliers as supps, dbo.angarishfaqtura as afs
	--		LEFT JOIN suppliers ON (zeds.client_id = supps.id_code AND zeds.af_seria = afs.af_seria AND zeds.af_nomeri = afs.af_nomeri)
	--		GROUP BY zeds.client_id,afs.af_seria,afs.af_nomeri
	--SELECT zednadebi.id_code AS zed_ident, 
	--		zednadebi.dro as tarigi,
	--		suppliers.name as supplier_name
	--		angarishfaqtura.af_seria as af_seria,
	--		angarishfaqtura.af_nomeri as af_nomeri
	--		FROM dbo.zednadebi, dbo.angarishfaqtura, dbo.s
	--		WHERE
	--		group by zednadebi.id_code
END
