-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateSupplier]
	-- Add the parameters for the stored procedure here
	@supp_ident nvarchar(MAX)
	,@supp_name nvarchar(MAX)
	,@supp_addr nvarchar(MAX)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.suppliers
	SET name = @supp_name, address= @supp_addr
	WHERE id_code = @supp_ident
	
	IF @@ROWCOUNT = 0 RETURN 404
	ELSE RETURN 0
	
END
