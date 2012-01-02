USE [productinfo_db]
GO

/****** Object:  UserDefinedFunction [dbo].[MinInt]    Script Date: 01/02/2012 12:37:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[MinInt] 
(
	-- Add the parameters for the function here
	  @arg1 int
	, @arg2 int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @RETVAL int
	
	IF @arg1 <= @arg2
		SELECT @RETVAL = @arg1
	ELSE
		SELECT @RETVAL = @arg2

	RETURN @RETVAL

END

GO

