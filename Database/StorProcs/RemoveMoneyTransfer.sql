-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveMoneyTransfer] 
	-- Add the parameters for the stored procedure here
	@mt_id int
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF (SELECT COUNT(id) FROM dbo.money_transfer WHERE dbo.money_transfer.id = @mt_id)=0
		RETURN 404	   
	   
	
	
	DELETE TOP(1) dbo.money_transfer WHERE dbo.money_transfer.id = @mt_id
	
	
END
