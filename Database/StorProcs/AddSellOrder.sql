-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddSellOrder] 
	-- Add the parameters for the stored procedure here
	@sell_time datetime,
	@buyer_ident_code nvarchar(MAX) = "ხელზე",
	@zed_ident nvarchar(MAX) = "0",
	@selling_with_check int = 1,
	@Insert_Id int output,
	@payment_method nvarchar(MAX)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT @Insert_Id = 0
	
    -- Insert statements for procedure here
	INSERT INTO SellOrder
           ([dro]
           ,[buyer_ident_code]
           ,[zednadebis_nomeri]
           ,[using_check]
           ,[pay_method])
     VALUES
           (@sell_time,
           @buyer_ident_code,
           @zed_ident,
           @selling_with_check,
           @payment_method)
           
	   IF @@ROWCOUNT = 0 RETURN 1
	   IF @@IDENTITY IS NOT NULL
		SELECT @Insert_Id = @@IDENTITY
	   
	   
	   RETURN 0

END
