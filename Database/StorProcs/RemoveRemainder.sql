-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE RemoveRemainder
	-- Add the parameters for the stored procedure here
	@Rem_ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @ret_val int = 0
	
	IF NOT (SELECT COUNT (id) FROM remainders WHERE id = @Rem_ID)>0
		RETURN 404
	
    -- Insert statements for procedure here
	IF NOT EXISTS (SELECT * FROM SoldRemainders WHERE remainder_id = @Rem_ID)
	BEGIN
		DELETE TOP(1) remainders WHERE id = @Rem_ID
	END
	ELSE
	BEGIN
		SELECT @ret_val = 2
	END
	RETURN @ret_val
END
