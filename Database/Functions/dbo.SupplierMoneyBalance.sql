USE [productinfo_db]
GO

/****** Object:  UserDefinedFunction [dbo].[SupplierMoneyBalance]    Script Date: 01/02/2012 12:37:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[SupplierMoneyBalance]
(
	-- Add the parameters for the function here
	@SuppIdent nvarchar(MAX)
)
RETURNS decimal(28,13)
AS
BEGIN
	
	
	-- Declare the return variable here
	DECLARE @ResultVar decimal(28,13)

	-- Add the T-SQL statements to compute the return value here
	DECLARE @zed_sum decimal(28,13) = (SELECT SUM(r.buy_price*r.initial_pieces) AS total_cost
				FROM remainders r, zednadebi z
				WHERE r.supplier_ident=@SuppIdent 
				AND r.zednadebis_nomeri=z.id_code
				AND z.client_id=r.supplier_ident
				AND z.operation='Buy'
	)
	
	DECLARE @mt_given decimal(28,13)=(SELECT SUM(money_transfer.amount) AS given_amt
				FROM money_transfer 
				WHERE money_transfer.type='Give' 
				  AND money_transfer.client_type='ProductInfo.Supplier'
				  AND money_transfer.client_id = @SuppIdent
				)
	
	DECLARE @mt_taken decimal(28,13)=(SELECT SUM(money_transfer.amount) AS taken_amt
				FROM money_transfer 
				WHERE money_transfer.type='Take' 
				  AND money_transfer.client_type='ProductInfo.Supplier'
				  AND money_transfer.client_id = @SuppIdent
				)
				
	IF (NOT @zed_sum > 0) OR (@zed_sum=NULL)
		SET @zed_sum = 0
	IF (NOT @mt_given > 0) OR (@mt_given=NULL)
		SET @mt_given = 0
	IF (NOT @mt_taken > 0) OR (@mt_taken=NULL)
		SET @mt_taken = 0
	
	SET @zed_sum=ISNULL(@zed_sum,0)
	SET @mt_given=ISNULL(@mt_given,0)
	SET @mt_taken=ISNULL(@mt_taken,0)
		
	SET @ResultVar = ROUND(@mt_given,2)-ROUND(@mt_taken,2)-ROUND(@zed_sum,2)
	-- Return the result of the function
	RETURN @ResultVar

END

GO

