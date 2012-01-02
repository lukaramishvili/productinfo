-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetProductSuggestions]
	-- Add the parameters for the stored procedure here
	@hintnname_arg nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.products WHERE dbo.products.name LIKE '%' + @hintnname_arg + '%'
	ORDER BY dbo.products.name ASC
END
