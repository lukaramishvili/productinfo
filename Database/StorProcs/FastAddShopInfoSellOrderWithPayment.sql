-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE FastAddShopInfoSellOrderWithPayment
	-- SellOrder attributes
	  @argSOdro datetime
	, @argSObuyer_ident_code nvarchar(MAX)
	, @argSOselling_with_check int
	, @argSOpayment_method nvarchar(MAX)
	--table containing all the remainders to sell
	, @ListOfSellRemainders dbo.ListSellRemainder READONLY
	--money_transfer attributes
	, @argMTclient_ident_arg nvarchar(MAX)
	, @argMTSellOrderTotal decimal(28,13)
	, @argMTActiveStoreID int
	, @argMTActiveCashBoxID int
	, @argMTActiveCashierID int
AS
BEGIN
	--
	SET NOCOUNT ON;
	
	BEGIN TRANSACTION tran_add_sellorder
	
	--feed SO insert id into this variable
	--and then feed it to SellRemainder and TransferMoney
	DECLARE @SellOrderInsertID int
	
	--STEP 1: Add SellOrder
	DECLARE @RetValOfAddSellOrder int = 501
	
	EXEC @RetValOfAddSellOrder 
		= AddSellOrder @sell_time = @argSOdro
		, @buyer_ident_code = @argSObuyer_ident_code
		, @zed_ident = N''
		, @selling_with_check = @argSOselling_with_check
		, @Insert_Id = @SellOrderInsertID output
		, @payment_method = @argSOpayment_method
	--check AddSellOrder for success
	IF @RetValOfAddSellOrder > 0
	BEGIN
		ROLLBACK TRANSACTION tran_add_sellorder
		RETURN @RetValOfAddSellOrder
	END
	--END STEP 1
	
	--STEP 2: Add remainders
	DECLARE @remCount int = (SELECT COUNT(ixListSellRemainder) FROM @ListOfSellRemainders)
    DECLARE @curPos int = 1
   
    WHILE @curPos <= @remCount
    BEGIN--WHILE
		--DECLARE next row (nr) attributes
		DECLARE @nr_barcode nvarchar(MAX)
		DECLARE @nr_storeID int
		DECLARE @nr_selling_count decimal(28,13)
		DECLARE @nr_piece_price decimal(28,13)
		DECLARE @nr_SellOrderID int
		--assign current row attributes 
		--from current [Remainder to sell] record
        SELECT TOP(1) 
				@nr_barcode = barcode
			  , @nr_storeID = storeID
			  , @nr_selling_count = selling_count
			  , @nr_piece_price = piece_price
			FROM @ListOfSellRemainders
            WHERE ixListSellRemainder NOT IN 
				(SELECT TOP(@curPos-1) ixListSellRemainder FROM @ListOfSellRemainders)
		--piece_price and selling_count should be positive
		IF @nr_piece_price <= 0.0 OR @nr_selling_count <= 0.0
		BEGIN
			ROLLBACK TRANSACTION tran_add_sellorder
			RETURN 1
		END--if piece_price or selling_count aren't positive
		DECLARE @RetValOfSellRemainder int = 501
		EXEC @RetValOfSellRemainder
			= SellRemainder @barcode = @nr_barcode
						  , @storeID = @nr_storeID
						  , @selling_count = @nr_selling_count
						  , @piece_price = @nr_piece_price
						  , @SellOrderID = @SellOrderInsertID
		--check SellRemainder for success
		IF @RetValOfSellRemainder > 0
		BEGIN
			ROLLBACK TRANSACTION tran_add_sellorder
			RETURN @RetValOfSellRemainder
		END
		--TODO: use next row (nr) attributes to insert Remainder (sp SellRemainder)
		--increment position to next record
        SET @curPos = @curPos + 1
    END--WHILE
	--END STEP 2
	
	--STEP 3: add moneytransfer
	--check parameters
	IF NOT (LEN(@argMTclient_ident_arg) > 0) 
		OR NOT (@argMTSellOrderTotal > 0.0)
	BEGIN
		ROLLBACK TRANSACTION tran_add_sellorder
		RETURN 1
	END
	--add moneytransfer
	DECLARE @RetValOfTransferMoney int = 501
	
	EXEC @RetValOfTransferMoney 
		= TransferMoney @Client_Ident = @argMTclient_ident_arg
		, @transfer_type = N'Take'
		, @dro = @argSOdro
		, @amount = @argMTSellOrderTotal
		, @client_type = 'ProductInfo.Buyer'
		, @purpose = N'PayFor'
		, @store_id = @argMTActiveStoreID
		, @target_type = N'ProductInfo.SellOrder'
		, @target_ident = @SellOrderInsertID
		, @cashbox_id = @argMTActiveCashBoxID
		, @cashier_id = @argMTActiveCashierID
		
	EXEC	--@return_value = 
		[dbo].[UpdateMTForSellOrder]
		@SellOrderIDToUpdate = @SellOrderInsertID
	
	EXEC	--@return_value = 
		[dbo].[UpdatetblSold_Rem_Statistics]
		@SellOrderIDToUpdate = @SellOrderInsertID
	
	--check TransferMoney for success
	IF @RetValOfTransferMoney > 0
	BEGIN
		ROLLBACK TRANSACTION tran_add_sellorder
		RETURN @RetValOfTransferMoney
	END
	
	COMMIT TRANSACTION tran_add_sellorder
	RETURN 0
	
	
	--at the end return something
	
	--
END
