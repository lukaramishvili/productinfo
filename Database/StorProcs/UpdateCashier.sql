-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCashier]
	-- Add the parameters for the stored procedure here
	@id int,
	@name nvarchar(MAX),
	@passwd nvarchar(MAX),
	@active bit
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @active_2 int
	IF (@active > 0) SET @active_2 = 1 ELSE SET @active_2 = 0
    -- Insert statements for procedure here

	IF @name IS NULL OR @passwd IS NULL OR @name = '' OR @passwd = '' RETURN 1
	IF EXISTS (SELECT * FROM Cashiers WHERE sName = @name and id != @id) RETURN 183
	
	IF (0 != @id AND (0 < (SELECT COUNT(id) FROM Cashiers WHERE id = @id)))
	BEGIN
		UPDATE dbo.Cashiers SET sName=@name, sPasswd = @passwd, eActive = @active_2 WHERE id = @id;
		IF @@ROWCOUNT = 0 RETURN 404
	END
	ELSE
	BEGIN	
		IF 0 = (SELECT COUNT(*) FROM Cashiers WHERE sName = @name)
		BEGIN
			INSERT INTO Cashiers (sName, sPasswd, eActive) VALUES (@name, @passwd, @active_2)
		END
		ELSE
		BEGIN
			RETURN 183
		END
	END
	
END
