-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SingleZedDetails
	-- Add the parameters for the stored procedure here
	  @zed_ident nvarchar(MAX)
	, @oper_type nvarchar(MAX)
	, @client_ident nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    SELECT * FROM 
    (SELECT * FROM zednadebi WHERE id_code = @zed_ident AND operation = @oper_type AND client_id = @client_ident)
    z
    
    LEFT JOIN angarishfaqtura af
    ON(af.af_seria = z.af_seria AND af.af_nomeri = z.af_nomeri AND af.client_ident = z.client_id AND af.operation = z.operation)
END
