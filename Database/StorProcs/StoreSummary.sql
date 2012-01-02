-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[StoreSummary] 
	-- Add the parameters for the stored procedure here
	@StoreID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @RetVal decimal(28,13), @total_taken decimal(28,13), @total_given decimal(28,13)
	
	
	SELECT @total_taken = mt_taken.taken_amt
	FROM
	 (	SELECT SUM(money_transfer.amount) AS taken_amt,money_transfer.client_type
				FROM money_transfer 
				WHERE	money_transfer.type='Take' 
						--AND money_transfer.client_type = 'ProductInfo.Buyer'--this should be removed when both type op.s are supported on both client types
						AND money_transfer.store_id = @StoreID
				GROUP by money_transfer.client_type
	) mt_taken
	
	SELECT @total_given = mt_given.given_amt
	FROM 
	(	SELECT SUM(money_transfer.amount) AS given_amt,
				money_transfer.client_type
				FROM money_transfer 
				WHERE	money_transfer.type='Give' 
						--AND money_transfer.client_type = 'ProductInfo.Supplier'--this should be removed when both type op.s are supported on both client types
						AND money_transfer.store_id = @StoreID
				GROUP by money_transfer.client_type
	) mt_given
	
	SET @RetVal = 
		CASE WHEN @total_taken>=0 THEN @total_taken ELSE 0 END
		-
		CASE WHEN @total_given>=0 THEN @total_given ELSE 0 END
	
	SELECT @RetVal as money_sum
	
    -- Insert statements for procedure here
	RETURN 0
END
