-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddSupplier]
	-- Add the parameters for the stored procedure here
	@id_code nvarchar(MAX),
	@name nvarchar(MAX),
	@address nvarchar (MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    DECLARE @matchingSuppliers int
    SELECT @matchingSuppliers = COUNT(*) FROM dbo.suppliers WHERE dbo.suppliers.name = @name OR dbo.suppliers.id_code = @id_code
    IF (@matchingSuppliers>0) RETURN 183
    
	INSERT INTO suppliers
						( id_code, name, address)
			VALUES     ( @id_code, @name, @address ) 
			
	RETURN 0
	
END
