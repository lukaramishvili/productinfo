-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Supplier_Fin_Statistics]
	-- Add the parameters for the stored procedure here
	
	--@ClientIdent nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here --SUM(r.buy_price*r.initial_pieces)  --   -SUM(mt_given.amount)
	SELECT 
	  s.name
	, s.id_code
	, s.address
	, 0
	, -1*dbo.SupplierMoneyBalance(s.id_code)
	--, CASE WHEN dbo.SupplierMoneyBalance(s.id_code)>=0 THEN dbo.SupplierMoneyBalance(s.id_code) ELSE 0 END
	--, CASE WHEN dbo.SupplierMoneyBalance(s.id_code)<0 THEN -1*dbo.SupplierMoneyBalance(s.id_code) ELSE 0 END
	--ROUND(ROUND(SUM(r.total_cost),4)-ROUND((SUM(mt_given.given_amt)/(CASE COUNT(mt_given.given_amt) when 0 then 1 else COUNT(mt_given.given_amt) end)),4),4)-- +(SUM(mt_taken.taken_amt)/COUNT(mt_taken.taken_amt))
	FROM suppliers s
/*	
	LEFT JOIN (	SELECT SUM(money_transfer.amount) AS given_amt,money_transfer.client_type, money_transfer.client_id 
				FROM money_transfer 
				WHERE money_transfer.type='Give' 
				GROUP by money_transfer.client_type, money_transfer.client_id
	) mt_given
	ON(mt_given.client_type = 'ProductInfo.Supplier' AND mt_given.client_id = s.id_code)
	
--	LEFT JOIN (	SELECT SUM(money_transfer.amount) AS taken_amt,money_transfer.target_type, money_transfer.client_id 
--				FROM money_transfer 
--				WHERE money_transfer.type='Take' 
--				GROUP by money_transfer.target_type, money_transfer.client_id
--	) mt_taken
--	ON(mt_given.target_type = 'ProductInfo.Supplier' AND mt_given.client_id = s.id_code)
	
	LEFT JOIN zednadebi z 
	ON(z.client_id = s.id_code AND z.operation = 'Buy')
	
	LEFT JOIN (SELECT SUM(remainders.buy_price*remainders.initial_pieces) AS total_cost, remainders.supplier_ident, remainders.zednadebis_nomeri, remainders.buy_price, remainders.initial_pieces
				FROM remainders
				GROUP BY remainders.supplier_ident, remainders.zednadebis_nomeri, remainders.buy_price, remainders.initial_pieces
	) r
	ON(r.supplier_ident = s.id_code AND r.zednadebis_nomeri = z.id_code)
*/	
	GROUP BY s.name,s.id_code, s.address
	ORDER BY s.name
END
