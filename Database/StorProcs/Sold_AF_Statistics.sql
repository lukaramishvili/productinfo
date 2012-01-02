-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sold_AF_Statistics] 
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

	SELECT b.name AS buyer_name, 
	afs.af_seria AS seria, 
	afs.af_nomeri AS af_saident,
	afs.dro AS dro,
	afs.operation AS operation,
	COUNT(DISTINCT z.id) AS zed_count,
	SUM(z.whole_cost) AS total_cost,
	SUM(dbo.CostWithoutVAT(z.whole_cost,p.uses_vat)) AS total_cost_withoutVAT--imito ar mushaobs ro products AS p agar ebmeva
	
	FROM (SELECT * FROM angarishfaqtura WHERE operation = 'Sell') afs
	LEFT JOIN buyers AS b
	ON(b.id_code = afs.client_ident)
	-- left join zednadebebi romlebsac uceriat aseve tavisi jamuri girebuleba
	LEFT JOIN				(SELECT 
	                                z1.id as id
	                                , z1.id_code as id_code
									, z1.af_seria AS af_seria
									, z1.af_nomeri AS af_nomeri
									, z1.client_id AS client_id
									, z1.operation AS operation
									, sr1.whole_cost as whole_cost
									FROM (SELECT * FROM zednadebi WHERE operation = 'Sell') z1
									LEFT JOIN SellOrder so1
									ON (z1.client_id = so1.buyer_ident_code AND z1.id_code = so1.zednadebis_nomeri)
									LEFT JOIN (SELECT SoldRemainders.SellOrder_id as SellOrder_id
												, SUM(piece_count*piece_price) AS whole_cost FROM SoldRemainders GROUP BY SoldRemainders.SellOrder_id) sr1
									ON(sr1.SellOrder_id = so1.id)
									
							)AS z
	ON (z.af_seria = afs.af_seria AND z.af_nomeri = afs.af_nomeri AND z.client_id = afs.client_ident)-- and z.operation = 'Sell' --es zedmet resurss daxarjavs da zemot gadatana jobia
	
	LEFT JOIN remainders AS r
	ON(r.zednadebis_nomeri = z.id_code AND r.supplier_ident = z.client_id)

	LEFT JOIN products AS p
	ON(r.product_barcode = p.barcode)
	
	
	GROUP BY b.name, afs.af_seria, afs.af_nomeri, afs.client_ident, afs.dro, afs.operation
	ORDER BY afs.operation ASC
END
