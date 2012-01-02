-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateZednadebi] 
	-- Add the parameters for the stored procedure here
	  @zed_ident nvarchar(MAX)
	, @new_zed_ident nvarchar(MAX)
	, @operation_type nvarchar(MAX)
	, @client_ident nvarchar(MAX)
	, @tarigi datetime = NULL
	, @af_seria nvarchar(MAX) = NULL
	, @af_nomeri nvarchar(MAX) = NULL
	, @af_date datetime = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @zed_ident IS NULL OR @operation_type IS NULL OR @client_ident IS NULL OR @zed_ident = '' OR @operation_type = '' OR @client_ident = '' 
		RETURN 1
		
	IF ( @tarigi IS NULL AND @af_seria = NULL AND @af_nomeri = NULL) OR (@tarigi IS NULL AND @af_seria = '' AND @af_nomeri = '')
		RETURN 1
		
	IF @zed_ident != @new_zed_ident AND (SELECT COUNT(*) FROM dbo.zednadebi WHERE id_code = @new_zed_ident AND operation = @operation_type AND client_id = @client_ident) > 0
		RETURN 183
		
	IF (SELECT COUNT(*) FROM dbo.zednadebi WHERE id_code = @zed_ident AND operation = @operation_type AND client_id = @client_ident) = 0
		RETURN 404
		
		
	IF @tarigi IS NOT NULL
	BEGIN
		UPDATE dbo.zednadebi SET dro = @tarigi WHERE id_code = @zed_ident AND operation = @operation_type AND client_id = @client_ident
	END
		
	--this check is needed to choose whether only date or date+af seria/nomeri are updated
	IF @af_seria IS NOT NULL AND @af_nomeri IS NOT NULL AND @af_seria != '' AND @af_nomeri != ''
	BEGIN
		UPDATE dbo.zednadebi SET af_seria = @af_seria, af_nomeri = @af_nomeri WHERE id_code = @zed_ident AND operation = @operation_type AND client_id = @client_ident
		
		--tu ukve arsebobs eseti, AddAngarishFaqtura mixvdeba
		EXEC dbo.AddAngarishFaqtura @af_nomeri, @af_seria, @af_date, @operation_type, @client_ident
		
	END
	
	IF @zed_ident != @new_zed_ident
	BEGIN
		BEGIN TRANSACTION tran_update_zed
		DECLARE @tran_upd_zed_ret int = 0
		--update zed ident code
		IF NOT (@new_zed_ident IS NULL) AND NOT (LEN(@new_zed_ident)<1)
		BEGIN
			IF @operation_type = 'Buy'
			BEGIN
				DECLARE @assoc_rem_count int = (SELECT COUNT(id) FROM remainders WHERE zednadebis_nomeri = @zed_ident and supplier_ident = @client_ident)
				DECLARE @assoc_bought_mt_count int = (SELECT COUNT(id) 
													FROM money_transfer WHERE client_id = @client_ident 
																			AND client_type = 'ProductInfo.Supplier'
																			AND target_ident = @zed_ident)
				UPDATE zednadebi SET id_code = @new_zed_ident WHERE id_code = @zed_ident AND operation = @operation_type AND client_id = @client_ident
				IF @@ROWCOUNT < 1 
					SET @tran_upd_zed_ret = 500
				UPDATE remainders SET zednadebis_nomeri = @new_zed_ident WHERE zednadebis_nomeri = @zed_ident and supplier_ident = @client_ident
				IF @@ROWCOUNT != @assoc_rem_count 
					SET @tran_upd_zed_ret = 500
				UPDATE money_transfer SET target_ident = @new_zed_ident WHERE client_id = @client_ident 
																			AND client_type = 'ProductInfo.Supplier'
																			AND target_ident = @zed_ident
				IF @@ROWCOUNT != @assoc_bought_mt_count 
					SET @tran_upd_zed_ret = 500
				--
			END
			ELSE IF @operation_type = 'Sell'
			BEGIN
				DECLARE @assoc_sold_mt_count int = (SELECT COUNT(id) 
													FROM money_transfer WHERE client_id = @client_ident 
																			AND client_type = 'ProductInfo.Supplier'
																			AND target_ident = @zed_ident)
				UPDATE zednadebi SET id_code = @new_zed_ident WHERE id_code = @zed_ident AND operation = @operation_type AND client_id = @client_ident
				IF @@ROWCOUNT < 1 
					SET @tran_upd_zed_ret = 500
				UPDATE SellOrder SET zednadebis_nomeri = @new_zed_ident WHERE zednadebis_nomeri = @zed_ident AND buyer_ident_code = @client_ident
				IF @@ROWCOUNT < 1 
					SET @tran_upd_zed_ret = 500
				UPDATE money_transfer SET target_ident = @new_zed_ident WHERE client_id = @client_ident 
																			AND client_type = 'ProductInfo.Buyer'
																			AND target_ident = @zed_ident
				IF @@ROWCOUNT != @assoc_bought_mt_count 
					SET @tran_upd_zed_ret = 500
				--
			END
		END
		IF 0 = @tran_upd_zed_ret
			COMMIT TRANSACTION tran_update_zed
		ELSE
			ROLLBACK TRANSACTION tran_update_zed
	END
	
	RETURN 0
	
	
	
END
