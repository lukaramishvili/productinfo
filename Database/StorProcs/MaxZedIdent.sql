-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MaxZedIdent]
	-- Add the parameters for the stored procedure here
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    -- Insert statements for procedure here
	SELECT TOP 1 zednadebi.id_code AS MaxZedIdentCode FROM dbo.zednadebi 
		WHERE zednadebi.operation = 'Sell' 
		AND ISNUMERIC(zednadebi.id_code)=1
		AND LEN(zednadebi.id_code) = (SELECT MAX(LEN(zednadebi.id_code)) FROM dbo.zednadebi
																			WHERE zednadebi.operation = 'Sell' AND ISNUMERIC(zednadebi.id_code)=1 )
		ORDER BY id_code DESC
END
