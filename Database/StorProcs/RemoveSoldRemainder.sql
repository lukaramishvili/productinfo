-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveSoldRemainder]
	-- Add the parameters for the stored procedure here
	@SoldRem_ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @ret_val int = 0
	
	IF NOT (SELECT COUNT (id) FROM SoldRemainders WHERE id = @SoldRem_ID)>0
		RETURN 404
	
    -- Insert statements for procedure here
    
    DECLARE @SoldRemTranName nvarchar(MAX) = 'SoldRemainderTransaction'
    BEGIN TRANSACTION @SoldRemTranName
	-- begin trans
	DECLARE @assoc_rem_id int = (SELECT remainders.id FROM remainders, SoldRemainders WHERE 
																				SoldRemainders.id = @SoldRem_ID
																			AND remainders.id = remainder_id
																			)
	DECLARE @assoc_rem_count decimal(28,13) = (SELECT piece_count FROM SoldRemainders WHERE SoldRemainders.id = @SoldRem_ID)
	
	UPDATE remainders SET remaining_pieces += @assoc_rem_count WHERE id = @assoc_rem_id
	
	DELETE TOP(1) FROM SoldRemainders WHERE id = @SoldRem_ID
	
	-- end trans
	COMMIT TRANSACTION @SoldRemTranName
		
	RETURN @ret_val
END
