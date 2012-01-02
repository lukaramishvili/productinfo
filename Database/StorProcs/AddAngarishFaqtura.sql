-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddAngarishFaqtura]
	-- Add the parameters for the stored procedure here
	@nomeri nvarchar(MAX),
	@seria nvarchar(MAX),
	@dro datetime,
	@operation nvarchar(MAX),
	@client_ident nvarchar(MAX)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	DECLARE @matchingAFs int
    SELECT @matchingAFs = COUNT(*) FROM dbo.angarishfaqtura WHERE dbo.angarishfaqtura.af_seria = @seria AND dbo.angarishfaqtura.af_nomeri = @nomeri
    IF (@matchingAFs>0) RETURN 183
    -- Insert statements for procedure here
	INSERT INTO dbo.angarishfaqtura
           (af_nomeri
           ,af_seria
           ,dro
           ,operation
           ,client_ident)
     VALUES
           (@nomeri,
           @seria,
           @dro,
           @operation,
           @client_ident);
           
     IF @@ROWCOUNT = 0 RETURN 1

END
