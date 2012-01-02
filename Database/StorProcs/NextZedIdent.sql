-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[NextZedIdent]
	-- Add the parameters for the stored procedure here
	@StoreID int
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    -- Insert statements for procedure here
    
    DECLARE @RetVal nvarchar(MAX) = ''
    
    --DECLARE @LastZedIdent nvarchar(MAX) = 
    DECLARE @LastZedNum int = 
    (SELECT MAX(CONVERT(int,SUBSTRING(id_code
											, LEN(id_code) - CHARINDEX('-', REVERSE(id_code)) + 2
											, 20))) id_code FROM dbo.zednadebi 
		WHERE zednadebi.operation = 'Sell' 
		AND zednadebi.id_code LIKE 'S'+CONVERT(nvarchar(max),@StoreID)+'-%'
		)
	
	--IF LEN(@LastZedIdent)>0
	IF @LastZedNum > 0
	BEGIN
		--DECLARE @LastZedNum int = SUBSTRING(@LastZedIdent
		--									, LEN(@LastZedIdent) - CHARINDEX('-', REVERSE(@LastZedIdent)) + 2
		--									, 20)
		SET @RetVal = 'S'+CONVERT(nvarchar(max),@StoreID)+'-'+CONVERT(nvarchar(max), @LastZedNum+1)
	END
	ELSE
	BEGIN
		SET @RetVal = 'S'+CONVERT(nvarchar(max),@StoreID)+'-'+CONVERT(nvarchar(max), 1)
	END
	
	SELECT @RetVal AS NextZedIdentCode
	
END
