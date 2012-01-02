-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveSellOrder] 
	-- Add the parameters for the stored procedure here
	  @SellOrderID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF (@SellOrderID <= 0 OR @SellOrderID = NULL)
	BEGIN
		RETURN 1
	END
	
	DECLARE @RemoveSOTranName nvarchar(MAX) = 'RemoveSellOrderTransaction'
    BEGIN TRANSACTION @RemoveSOTranName
	
	DECLARE @ret_val int = 0
	
	-- tu am SellOrder-s zednadebi sheesabameba, mashin EXEC RemoveZednadebi
	IF '' != (SELECT zednadebis_nomeri FROM SellOrder WHERE id = @SellOrderID)
	BEGIN
		DECLARE @MatchedSOZedIdent nvarchar(MAX),@MatchedSOBuyerIdent nvarchar(MAX)
		
		SELECT @MatchedSOZedIdent = zednadebis_nomeri, @MatchedSOBuyerIdent = buyer_ident_code FROM SellOrder WHERE id = @SellOrderID
		
		EXEC @ret_val = [dbo].[RemoveZednadebi]
		@zed_ident = @MatchedSOZedIdent,
		@oper_type = N'Sell',
		@client_ident = @MatchedSOBuyerIdent
	END
	ELSE
	BEGIN	
		IF NOT (SELECT COUNT (id) FROM SellOrder WHERE SellOrder.id = @SellOrderID)>0
			BEGIN
				--ROLLBACK TRANSACTION @RemoveSOTranName
				--RETURN 404
				--if @ret_val>0 it will rollback & RETURN @ret_val
				SELECT @ret_val=404
			END
		ELSE
		BEGIN
				--			
				DECLARE @RmvSoldRemLoopResult int = 0
				
				WHILE (SELECT COUNT(*) FROM SoldRemainders WHERE SellOrder_id = @SellOrderID)>0
				BEGIN
					DECLARE @NextSoldRemIDOfZed int  = (SELECT TOP(1) id FROM SoldRemainders WHERE SellOrder_id = @SellOrderID)
					
					DECLARE	@RmvSoldRem_return_value int
					EXEC	@RmvSoldRem_return_value = [dbo].[RemoveSoldRemainder]
							@SoldRem_ID = @NextSoldRemIDOfZed
					
					IF @RmvSoldRem_return_value > 0 
					BEGIN
						SELECT @RmvSoldRemLoopResult = @RmvSoldRem_return_value
						BREAK
					END
				END
				
				IF @RmvSoldRemLoopResult = 0
				BEGIN
					DELETE TOP(1) SellOrder WHERE id = @SellOrderID
					
					DELETE money_transfer WHERE type = 'Take'
											AND client_type = 'ProductInfo.Buyer'
											AND purpose = 'PayFor'
											AND target_type = 'ProductInfo.SellOrder'
											AND target_ident = CONVERT(nvarchar(MAX),@SellOrderID)
					
					DELETE FROM tblSold_Rem_Statistics WHERE so_id = @SellOrderID
					--
				END
				ELSE
				BEGIN
					SELECT @ret_val = @RmvSoldRemLoopResult
				END
				-- 
		END
	END
	
	IF @ret_val=0
	BEGIN
		COMMIT TRANSACTION @RemoveSOTranName
	END
	ELSE
	BEGIN
		ROLLBACK TRANSACTION @RemoveSOTranName
	END
	
	RETURN @ret_val
	
END
