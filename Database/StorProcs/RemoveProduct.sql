-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveProduct] 
	-- Add the parameters for the stored procedure here
	@p_barcode nvarchar(MAX)
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @p_clones int = 0
	--how many product rows are there with this barcode
	SELECT @p_clones = COUNT(*) FROM dbo.products WHERE barcode = @p_barcode
	   
	   
	DECLARE @rem_count int = 0
    -- get if there are any remainders with this barcode
	SELECT @rem_count = COUNT(*) FROM remainders WHERE product_barcode = @p_barcode
	
	IF @rem_count > 0
	BEGIN
		DELETE dbo.products
		 FROM (SELECT TOP (@p_clones-1) * FROM dbo.products WHERE barcode = @p_barcode) AS p1
		 WHERE dbo.products.id = p1.id
	END
	ELSE
	BEGIN
		--DELETE FROM dbo.products WHERE barcode = @p_barcode
		DELETE dbo.products
		 FROM (SELECT TOP (@p_clones-1) * FROM dbo.products WHERE barcode = @p_barcode) AS p1
		 WHERE dbo.products.id = p1.id
	END
END
