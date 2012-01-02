USE [productinfo_db]
GO

/****** Object:  UserDefinedFunction [dbo].[RemainderHasStoreAsSellableParent]    Script Date: 01/02/2012 12:37:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[RemainderHasStoreAsSellableParent]
(
	-- Add the parameters for the function here
	  @remainder_id int
	, @store_id int
)
RETURNS bit
AS
BEGIN
	-- Declare the return variable here
	DECLARE @RetVal bit = 0
	
	DECLARE @current_ancient_id int = (SELECT storehouse_id from remainders WHERE id = @remainder_id)
	
	-- Add the T-SQL statements to compute the return value here
	WHILE (NOT @current_ancient_id = -1)
	BEGIN
		--check all parents for being able to sell
		IF 1 > (SELECT CanSell FROM stores WHERE id = @current_ancient_id)
			BREAK
		--check if current ancient matches searching store
		IF @current_ancient_id = @store_id
		BEGIN
			SET @RetVal = 1
			BREAK
		END
		ELSE
		BEGIN
			SET @current_ancient_id = (SELECT ParentID FROM stores WHERE id = @current_ancient_id)
		END
	END
	-- Return the result of the function
	RETURN @RetVal

END

GO

