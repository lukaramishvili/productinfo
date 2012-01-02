USE [productinfo_db]
GO

/****** Object:  UserDefinedFunction [dbo].[CostWithoutVAT]    Script Date: 01/02/2012 12:36:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[CostWithoutVAT]
(
	-- Add the parameters for the function here
	@AmountWithVAT decimal(28,13),
	@isTaxed int
)
RETURNS decimal(28,13)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @RetVal decimal(28,13) 

	-- Add the T-SQL statements to compute the return value here
	SELECT @RetVal = @AmountWithVAT*(118-@isTaxed*18)/118

	-- Return the result of the function
	RETURN @RetVal

END

GO

