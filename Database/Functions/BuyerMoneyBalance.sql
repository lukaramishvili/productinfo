USE [productinfo_db]
GO

/****** Object:  UserDefinedFunction [dbo].[BuyerMoneyBalance]    Script Date: 01/02/2012 12:36:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[BuyerMoneyBalance]
(
	-- Add the parameters for the function here
	@BuyerIdent nvarchar(MAX)
)
RETURNS decimal(28,13)
AS
BEGIN
	
	
	-- Declare the return variable here
	DECLARE @ResultVar decimal(28,13)

	-- Add the T-SQL statements to compute the return value here
	DECLARE @sold_sum decimal(28,13) = (SELECT SUM(sold.piece_count*sold.piece_price) AS total_cost
				FROM SoldRemainders sold, SellOrder SO
				WHERE SO.buyer_ident_code = @BuyerIdent
				  AND sold.SellOrder_id = SO.id
	)
	
	DECLARE @mt_given decimal(28,13) = (SELECT SUM(money_transfer.amount) AS given_amt
				FROM money_transfer 
				WHERE money_transfer.type='Give' 
				  AND money_transfer.client_type='ProductInfo.Buyer'
				  AND money_transfer.client_id = @BuyerIdent
				)
	
	DECLARE @mt_taken decimal(28,13) = (SELECT SUM(money_transfer.amount) AS taken_amt
				FROM money_transfer 
				WHERE money_transfer.type='Take' 
				  AND money_transfer.client_type='ProductInfo.Buyer'
				  AND money_transfer.client_id = @BuyerIdent
				)
				
	IF (NOT @sold_sum > 0) OR (@sold_sum=NULL)
		SET @sold_sum = 0
	IF (NOT @mt_given > 0) OR (@mt_given=NULL)
		SET @mt_given = 0
	IF (NOT @mt_taken > 0) OR (@mt_taken=NULL)
		SET @mt_taken = 0
	
	SET @sold_sum=ISNULL(@sold_sum,0)
	SET @mt_given=ISNULL(@mt_given,0)
	SET @mt_taken=ISNULL(@mt_taken,0)
		
	--SET @ResultVar = ROUND(@mt_given,2)-ROUND(@mt_taken,2)+ROUND(@sold_sum,2)
	SET @ResultVar = CONVERT(decimal(28,13),(CONVERT(int,@mt_given*100)-CONVERT(int,@mt_taken*100)+CONVERT(int,@sold_sum*100)))/100
	-- Return the result of the function
	RETURN @ResultVar

END

GO

