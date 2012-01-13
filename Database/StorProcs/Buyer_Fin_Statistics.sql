-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Buyer_Fin_Statistics]
	-- Add the parameters for the stored procedure here
	
	--@ClientIdent nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here --SUM(r.buy_price*r.initial_pieces)  --   -SUM(mt_given.amount)
    --(SUM(mt_taken.taken_amt)/COUNT(mt_taken.taken_amt))-(SUM(mt_given.given_amt)/COUNT(mt_given.given_amt))
	SELECT 
		  b.name
		, b.id_code
		, b.address
		, 0
		, dbo.BuyerMoneyBalance(b.id_code)
		--, CASE WHEN dbo.BuyerMoneyBalance(b.id_code)>=0 THEN 0 ELSE -1*dbo.BuyerMoneyBalance(b.id_code) END
		--, CASE WHEN dbo.BuyerMoneyBalance(b.id_code)<0 THEN 0 ELSE dbo.BuyerMoneyBalance(b.id_code) END
		--ROUND(ROUND(SUM(sold_total),4) - ROUND(SUM(mt_taken.taken_amt),4),4) -- - mt_given.given_amt
	FROM buyers b
	
--	LEFT JOIN (	SELECT SUM(money_transfer.amount) AS given_amt,money_transfer.target_type, money_transfer.client_id 
--				FROM money_transfer 
--				WHERE money_transfer.type='Give' 
--				GROUP by money_transfer.target_type, money_transfer.client_id
--	) mt_given
--	ON(mt_given.target_type = 'ProductInfo.Buyer' AND mt_given.client_id = b.id_code)
/*	
	LEFT JOIN (	SELECT SUM(money_transfer.amount) AS taken_amt,money_transfer.client_type, money_transfer.client_id 
				FROM money_transfer 
				WHERE money_transfer.type='Take' 
				GROUP by money_transfer.client_type, money_transfer.client_id
	) mt_taken
	ON(mt_taken.client_type = 'ProductInfo.Buyer' AND mt_taken.client_id = b.id_code)
	
	--LEFT JOIN SellOrder so
	--ON (so.buyer_ident_code = b.id_code)
	
	LEFT JOIN 
	(SELECT SellOrder.buyer_ident_code AS buyer_ident, SUM(piece_price*piece_count) AS sold_total FROM SoldRemainders, SellOrder
		WHERE SoldRemainders.SellOrder_id = SellOrder.id
		--AND SellOrder.pay_method = 'Konsignacia'
		GROUP BY buyer_ident_code
	 )
	sold
	ON(sold.buyer_ident = b.id_code)
	*/
	GROUP BY b.name,b.id_code, b.address --, mt_given.given_amt, mt_taken.taken_amt
	ORDER BY b.name
END
