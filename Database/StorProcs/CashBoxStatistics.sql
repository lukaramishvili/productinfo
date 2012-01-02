-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE CashBoxStatistics
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT cashbox_id, SUM(balance) as cashbox_balance FROM (
		SELECT 
			distinct cashbox_id as cashbox_id
			, CASE WHEN type = 'Take' THEN amount WHEN type = 'Give' THEN -1*amount END as balance
			
			
			FROM money_transfer
			
			WHERE cashbox_id IS NOT NULL
			) complex_select
			
	GROUP BY cashbox_id
	
END
