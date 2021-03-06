USE [productinfo_db]
GO

/****** Object:  UserDefinedFunction [dbo].[MinDecimal]    Script Date: 01/02/2012 12:37:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[MinDecimal]
(
	-- Add the parameters for the function here
	  @arg1 decimal(28,13)
	, @arg2 decimal(28,13)
)
RETURNS float
AS
BEGIN
	-- Declare the return variable here
	DECLARE @RETVAL decimal(28,13)
	
	IF @arg1 <= @arg2
		SELECT @RETVAL = @arg1
	ELSE
		SELECT @RETVAL = @arg2

	RETURN @RETVAL

END

GO

