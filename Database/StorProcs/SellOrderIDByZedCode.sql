-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SellOrderIDByZedCode] 
	-- Add the parameters for the stored procedure here
	  @buyer_ident nvarchar(MAX)
	, @zed_ident nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @matched_SO_count int  = (SELECT COUNT(*) from SellOrder 
			WHERE SellOrder.buyer_ident_code = @buyer_ident
			  AND SellOrder.zednadebis_nomeri = @zed_ident
			)
    IF NOT (@matched_SO_count > 0)
			RETURN 404
    IF (@matched_SO_count > 1)
			RETURN 183
    
	--DECLARE @SOID int = (SELECT id from SellOrder 
    --WHERE DATEPART(YEAR,dro) = DATEPART(YEAR,@dro)
    --AND DATEPART(MONTH,dro) = DATEPART(MONTH,@dro)
    --AND DATEPART(DAY,dro) = DATEPART(DAY,@dro)
    --AND DATEPART(HOUR,dro) = DATEPART(HOUR,@dro)
    --AND DATEPART(MINUTE,dro) = DATEPART(MINUTE,@dro)
    --AND DATEPART(SECOND,dro) = DATEPART(SECOND,@dro)
    --)
    --SELECT @SOID
    SELECT    id
			--, buyer_ident_code
			--, zednadebis_nomeri
			--, using_check
			--, pay_method 
			FROM SellOrder 
    WHERE SellOrder.buyer_ident_code = @buyer_ident
      AND SellOrder.zednadebis_nomeri = @zed_ident
    
    RETURN 0
    
END
