-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateBuyer]
	-- Add the parameters for the stored procedure here
	@buyer_ident nvarchar(MAX)
	,@buyer_name nvarchar(MAX)
	,@buyer_addr nvarchar(MAX)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.buyers
	SET name = @buyer_name, address= @buyer_addr
	WHERE id_code = @buyer_ident
	
	IF @@ROWCOUNT = 0 RETURN 404
	ELSE RETURN 0
	
END
