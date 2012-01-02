USE [productinfo_db]
GO

/****** Object:  UserDefinedFunction [dbo].[MaxDecimal]    Script Date: 01/02/2012 12:36:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[MaxDecimal]
(
	-- Add the parameters for the function here
	  @arg1 decimal(28,13)
	, @arg2 decimal(28,13)
)
RETURNS decimal(28,13)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @RETVAL decimal(28,13)
	
	IF @arg1 >= @arg2
		SELECT @RETVAL = @arg1
	ELSE
		SELECT @RETVAL = @arg2

	RETURN @RETVAL

END

GO

