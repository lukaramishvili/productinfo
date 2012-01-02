-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveZednadebi] 
	-- Add the parameters for the stored procedure here
	  @zed_ident nvarchar(MAX)
	, @oper_type nvarchar(MAX)
	, @client_ident nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF (@zed_ident = '' OR @oper_type = '' OR @client_ident = '')
	BEGIN
		RETURN 1
	END
	
	DECLARE @RemoveZedTranName nvarchar(MAX) = 'RemoveZednadebiTransaction'
    BEGIN TRANSACTION @RemoveZedTranName
	
	DECLARE @ret_val int = 0
	
	IF NOT (SELECT COUNT (id) FROM zednadebi WHERE zednadebi.id_code = @zed_ident AND zednadebi.operation = @oper_type AND zednadebi.client_id = @client_ident )>0
		BEGIN
			--ROLLBACK TRANSACTION @RemoveZedTranName
			--RETURN 404
			--if @ret_val>0 it will rollback & RETURN @ret_val
			SELECT @ret_val=404
		END
	ELSE
	BEGIN
		IF @oper_type = 'Buy'
		BEGIN
			-- Insert statements for procedure here
			IF NOT EXISTS (SELECT * FROM remainders r, SoldRemainders sold WHERE r.zednadebis_nomeri = @zed_ident 
																			AND r.supplier_ident = @client_ident
																			AND sold.remainder_id = r.id
																			)
			BEGIN
				DELETE remainders WHERE remainders.zednadebis_nomeri = @zed_ident 
									AND remainders.supplier_ident = @client_ident
				DELETE zednadebi WHERE zednadebi.id_code = @zed_ident 
									AND zednadebi.operation = @oper_type 
									AND zednadebi.client_id = @client_ident
					
				DELETE money_transfer WHERE type = 'Give'
										AND client_type = 'ProductInfo.Supplier'
										AND client_id = @client_ident
										AND purpose = 'PayFor'
										AND target_type = 'ProductInfo.Zednadebi'
										AND target_ident = @zed_ident
				--
			END
			ELSE
			BEGIN
			-- if remainder is already sold, we can't delete it
				SELECT @ret_val = 2
			END
		END
		ELSE IF @oper_type = 'Sell'
		BEGIN
			-- 
			IF NOT (SELECT COUNT(*) FROM SellOrder WHERE SellOrder.buyer_ident_code = @client_ident 
																		AND SellOrder.zednadebis_nomeri = @zed_ident)>0
			BEGIN
				SELECT @ret_val = 404
			END
			
			DECLARE @SellOrderIDofZed int = (SELECT id FROM SellOrder WHERE SellOrder.buyer_ident_code = @client_ident 
																		AND SellOrder.zednadebis_nomeri = @zed_ident)
			
			DECLARE @RmvSoldZedLoopResult int = 0
			
			WHILE (SELECT COUNT(*) FROM SoldRemainders WHERE SellOrder_id = @SellOrderIDofZed)>0
			BEGIN
				DECLARE @NextSoldRemIDOfZed int  = (SELECT TOP(1) id FROM SoldRemainders WHERE SellOrder_id = @SellOrderIDofZed)
				
				DECLARE	@RmvSoldZed_return_value int
				EXEC	@RmvSoldZed_return_value = [dbo].[RemoveSoldRemainder]
						@SoldRem_ID = @NextSoldRemIDOfZed
				
				IF @RmvSoldZed_return_value > 0 
				BEGIN
					SELECT @RmvSoldZedLoopResult = @RmvSoldZed_return_value
					BREAK
				END
			END
			
			IF @RmvSoldZedLoopResult = 0
			BEGIN
				DELETE TOP(1) SellOrder WHERE id = @SellOrderIDofZed
				
				DELETE zednadebi WHERE zednadebi.id_code = @zed_ident 
									AND zednadebi.operation = @oper_type 
									AND zednadebi.client_id = @client_ident
					
				DELETE money_transfer WHERE type = 'Take'
										AND client_type = 'ProductInfo.Buyer'
										AND client_id = @client_ident
										AND purpose = 'PayFor'
										AND target_type = 'ProductInfo.Zednadebi'
										AND target_ident = @zed_ident
				--
			END
			ELSE
			BEGIN
				SELECT @ret_val = @RmvSoldZedLoopResult
			END
			-- 
		END
	END
	
	IF @ret_val=0
	BEGIN
		COMMIT TRANSACTION @RemoveZedTranName
	END
	ELSE
	BEGIN
		ROLLBACK TRANSACTION @RemoveZedTranName
	END
	
	RETURN @ret_val
	
END
