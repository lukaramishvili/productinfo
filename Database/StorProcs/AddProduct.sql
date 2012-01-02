-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddProduct]
	-- Add the parameters for the stored procedure here
	@barcode nvarchar(MAX),
	@name nvarchar (MAX),
	@usesVAT  int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    DECLARE @matchingProds int
    SELECT @matchingProds = COUNT(*) FROM dbo.products WHERE dbo.products.name = @name OR dbo.products.barcode = @barcode
    IF (@matchingProds>0) RETURN 183
	INSERT INTO dbo.products (barcode,name,uses_vat) VALUES (@barcode,@name,@usesVAT);
	
	RETURN 0
END
