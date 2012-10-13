-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[RemoveSoldRemainder]
	-- Add the parameters for the stored procedure here
	@SoldRem_ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @ret_val int = 0
	
	--return 404 if the soldrem doesnt exist
	IF NOT (SELECT COUNT (id) FROM SoldRemainders WHERE id = @SoldRem_ID)>0
		RETURN 404
	
	DECLARE @SellOrderID int
	SET @SellOrderID = (SELECT SellOrder_id FROM SoldRemainders where id = @SoldRem_ID)
	
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
	
	--update moneytransfer for corresponding sellorder	
	EXEC	--@return_value = 
		[dbo].[UpdateMTForSellOrder]
		@SellOrderIDToUpdate = @SellOrderID
	--finally, update sold rem statistics (gayidvebi) cache
	EXEC	--@return_value = 
		[dbo].[UpdatetblSold_Rem_Statistics]
		@SellOrderIDToUpdate = @SellOrderID
	
	-- end trans
	COMMIT TRANSACTION @SoldRemTranName
		
	RETURN @ret_val
END
