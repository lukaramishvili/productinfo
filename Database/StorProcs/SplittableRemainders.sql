-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SplittableRemainders 
	-- Add the parameters for the stored procedure here
	@p_barcode nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT r.*,z.dro FROM (SELECT * FROM remainders WHERE product_barcode = @p_barcode AND remaining_pieces > 0) r
	
	LEFT JOIN zednadebi z
	ON (z.client_id = r.supplier_ident AND z.operation = 'Buy' AND r.zednadebis_nomeri = z.id_code)
	
	ORDER BY z.dro DESC
	
END
