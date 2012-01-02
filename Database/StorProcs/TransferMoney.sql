-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TransferMoney]
	-- Add the parameters for the stored procedure here
	@Client_Ident nvarchar(MAX),
	@transfer_type nvarchar(MAX),
	@dro datetime,
	@amount decimal(28,13),
	@client_type nvarchar(MAX),
	@purpose nvarchar(MAX) = NULL,
	@store_id int = NULL,
	@target_type nvarchar(MAX) = NULL,
	@target_ident nvarchar(MAX) = NULL,
	@cashbox_id nvarchar(MAX) = NULL,
	@cashier_id nvarchar(MAX) = NULL
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF @Client_Ident IS NULL OR @transfer_type IS NULL OR @dro IS NULL OR @amount IS NULL OR @client_type IS NULL
		RETURN 1
	IF @Client_Ident = '' OR @transfer_type = '' OR @dro = '' OR @amount = 0 OR @client_type = ''
		RETURN 1
	
	SELECT @amount = ROUND(@amount,4)
	
    -- Insert statements for procedure here
	INSERT INTO dbo.money_transfer
           ([type]
           ,[dro]
           ,[amount]
           ,[client_type]
           ,[client_id]
           ,[purpose]
           ,[store_id]
           ,[target_type]
           ,[target_ident]
           ,[cashbox_id]
           ,[cashier_id])
     VALUES
           (@transfer_type
           ,@dro
           ,@amount
           ,@client_type
           ,@Client_Ident
           ,@purpose
           ,@store_id
           ,@target_type
           ,@target_ident
           ,@cashbox_id
           ,@cashier_id)
           
     IF @@ROWCOUNT = 0 RETURN 1
     
     RETURN 0

END
