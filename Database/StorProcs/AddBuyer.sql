-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddBuyer]
	-- Add the parameters for the stored procedure here
	@id_code nvarchar(MAX),
	@name nvarchar(MAX),
	@address nvarchar (MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    DECLARE @matchingBuyers int
    SELECT @matchingBuyers = COUNT(*) FROM dbo.buyers WHERE dbo.buyers.name = @name OR dbo.buyers.id_code = @id_code
    IF (@matchingBuyers>0) RETURN 183
    
	INSERT INTO buyers
						( id_code, name, address)
			VALUES     ( @id_code, @name, @address ) 
			
	RETURN 0
			
END
