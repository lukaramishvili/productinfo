-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[BoughtZedDetails]
	-- Add the parameters for the stored procedure here
	@supplier_ident nvarchar(MAX),
	@zed_ident nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	  r.id
	, p.barcode
	, p.name as prod_name
	, r.initial_pieces as piece_count
	, r.buy_price as sacalo_ghirebuleba
	, r.initial_pieces*r.buy_price as ghirebuleba
	, r.sell_price as sacalo_gasayidi_fasi
	, r.sell_price*r.initial_pieces as jamuri_gasayidi_fasi
	, '--'
	, (dbo.CostWithoutVAT(r.initial_pieces*r.buy_price,p.uses_vat)) as ghirebuleba_VAT_gareshe
	, r.storehouse_id as store_id
	, s.name
	FROM (SELECT * 
								FROM remainders
								WHERE remainders.zednadebis_nomeri = @zed_ident
								AND remainders.supplier_ident = @supplier_ident
								) r
	LEFT JOIN products p
	ON(r.product_barcode = p.barcode)
	LEFT JOIN suppliers s
	ON (r.supplier_ident = s.id_code)
END
