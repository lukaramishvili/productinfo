
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddZednadebi]
	-- Add the parameters for the stored procedure here
	@id_code nvarchar(MAX),
	@dro datetime,
	@operation nvarchar(MAX),
	@client_id nvarchar(MAX),
	@af_seria nvarchar(MAX),
	@af_nomeri nvarchar(MAX),
	@pay_method nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF @id_code IS NULL OR @dro IS NULL OR @operation IS NULL OR @client_id IS NULL
		RETURN 1
	
	DECLARE @matchingZeds int
	SELECT @matchingZeds = COUNT(id) FROM dbo.zednadebi WHERE 
		(dbo.zednadebi.id_code = @id_code AND dbo.zednadebi.client_id = @client_id AND zednadebi.operation = 'Buy' AND @operation = 'Buy')
		OR 
		(dbo.zednadebi.id_code = @id_code AND zednadebi.operation = 'Sell' AND @operation ='Sell')
    IF (@matchingZeds>0) RETURN 183
    -- Insert statements for procedure here
	INSERT INTO dbo.zednadebi (id_code,dro,operation,client_id,af_seria,af_nomeri,pay_method)
						VALUES (@id_code,@dro,@operation,@client_id,@af_seria,@af_nomeri,@pay_method)
						
END

