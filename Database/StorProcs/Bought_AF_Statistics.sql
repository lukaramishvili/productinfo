-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bought_AF_Statistics] 
	-- Add the parameters for the stored procedure here
	--@af_saident nvarchar(MAX) output,
	--@dro datetime output,
	--@operation nvarchar(MAX) output,
	--@zed_count int output

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT s.id_code as supplier_barcode,
	s.name as supplier_name, 
	afs.af_seria as seria, 
	afs.af_nomeri as af_saident,
	afs.dro as dro,
	afs.operation as operation,
	COUNT(DISTINCT z.id) as zed_count,
	SUM(r.buy_price*r.initial_pieces),
	SUM(dbo.CostWithoutVAT(r.buy_price*r.initial_pieces,p.uses_vat)),	
	SUM(r.buy_price*r.initial_pieces)-SUM(dbo.CostWithoutVAT(r.buy_price*r.initial_pieces,p.uses_vat))
	
	FROM (SELECT * FROM angarishfaqtura WHERE operation = 'Buy') afs
	LEFT JOIN suppliers as s
	ON(s.id_code = afs.client_ident)
	LEFT JOIN zednadebi as z
	ON (z.af_seria = afs.af_seria AND z.af_nomeri = afs.af_nomeri AND z.client_id = afs.client_ident AND z.operation = 'Buy')
	LEFT JOIN remainders r
	ON(r.zednadebis_nomeri = z.id_code AND r.supplier_ident = z.client_id)
	LEFT JOIN products p
	ON(r.product_barcode = p.barcode)
	
	
	GROUP BY s.id_code, s.name, afs.af_seria, afs.af_nomeri, afs.client_ident, afs.dro, afs.operation
	ORDER BY afs.operation ASC
END
