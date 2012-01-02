-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE AddPurchaseOrder
	-- Add the parameters for the stored procedure here
	@purchase_time datetime,
	@supplier_ident_code nvarchar(MAX),
	@zed_ident nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.PurchaseOrder (dro,supplier_ident_code,zednadebis_nomeri) 
	VALUES (@purchase_time,@supplier_ident_code,@zed_ident)
	
	RETURN 0
END
