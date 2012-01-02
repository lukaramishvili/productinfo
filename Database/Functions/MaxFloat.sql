USE [productinfo_db]
GO

/****** Object:  UserDefinedFunction [dbo].[MaxFloat]    Script Date: 01/02/2012 12:37:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[MaxFloat]
(
	-- Add the parameters for the function here
	  @arg1 float
	, @arg2 float
)
RETURNS float
AS
BEGIN
	-- Declare the return variable here
	DECLARE @RETVAL float
	
	IF @arg1 >= @arg2
		SELECT @RETVAL = @arg1
	ELSE
		SELECT @RETVAL = @arg2

	RETURN @RETVAL

END

GO

