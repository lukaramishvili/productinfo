USE [productinfo_db]
GO
/****** Object:  StoredProcedure [dbo].[UpdatetblSold_Rem_Statistics]    Script Date: 02/12/2012 23:41:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[UpdatetblSold_Rem_Statistics]
	-- Add the parameters for the stored procedure here
	@SellOrderIDToUpdate int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    DELETE tblSold_Rem_Statistics WHERE so_id = @SellOrderIDToUpdate
    INSERT INTO tblSold_Rem_Statistics (so_id,so_dro,cashbox_id,sName,buyer_name,store_id,zed_nomeri,using_check,whole_cost,costWithoutVAT,sold_price,sold_price_withoutVAT,sold_price_onlyVAT,paid_amount,whole_price_diff,price_diff_withoutVAT)
	SELECT *
			FROM (	
		SELECT	so.id AS so_id
				, so.dro AS so_dro
				, N'სალარო ' + CONVERT(nvarchar(MAX),mt.cashbox_id) as cashbox_id
				, Cashiers.sName
				, b.name as buyer_name
				, r.storehouse_id AS store_id
				, so.zednadebis_nomeri AS zed_nomeri
				, so.using_check AS using_check
				, SUM(sold.piece_count*r.buy_price) as whole_cost
				, SUM(dbo.CostWithoutVAT(sold.piece_count*r.buy_price,p.uses_vat)) as costWithoutVAT
				, SUM(sold.piece_count*sold.piece_price) as sold_price
				, SUM(dbo.CostWithoutVAT(sold.piece_count*sold.piece_price,p.uses_vat)) as sold_price_withoutVAT
				, SUM(CASE WHEN 0=p.uses_vat THEN sold.piece_count*sold.piece_price ELSE 0 END) as sold_price_onlyVAT
				, AVG(mt.amount) AS paid_amount --SUM(CASE so.pay_method WHEN 'Nagdi' THEN sold.piece_count*sold.piece_price WHEN 'Konsignacia' THEN 0 END)
				, ( SUM(sold.piece_count*sold.piece_price)-SUM(r.buy_price*sold.piece_count) ) as whole_price_diff
				, ( SUM(dbo.CostWithoutVAT(sold.piece_count*sold.piece_price,p.uses_vat)) - SUM(dbo.CostWithoutVAT(r.buy_price*sold.piece_count,p.uses_vat)) ) as price_diff_withoutVAT
				--, SUM(CASE so.pay_method WHEN 'Nagdi' THEN sold.piece_count*sold.piece_price WHEN 'Konsignacia' THEN 0 END)
				--, ( SUM(CASE so.pay_method WHEN 'Nagdi' THEN sold.piece_count*sold.piece_price WHEN 'Konsignacia' THEN 0 END)-SUM(CASE so.pay_method WHEN 'Nagdi' THEN r.buy_price*sold.piece_count WHEN 'Konsignacia' THEN 0 END) )
			FROM 
			(SELECT * FROM dbo.SellOrder WHERE id = @SellOrderIDToUpdate
			) so
		LEFT JOIN dbo.SoldRemainders sold
		ON(sold.SellOrder_id = so.id)
		LEFT JOIN dbo.remainders r
		ON(r.id = sold.remainder_id)
		LEFT JOIN dbo.products p
		ON (r.product_barcode = p.barcode)
		LEFT JOIN dbo.buyers b
		ON (so.buyer_ident_code = b.id_code)
		LEFT JOIN 
		(
		SELECT client_type, client_id, type, purpose, target_type, target_ident, SUM(amount) as amount, cashbox_id, cashier_id FROM money_transfer 
		GROUP BY client_type, client_id, type, purpose, target_type, target_ident, cashbox_id, cashier_id
		) mt
		LEFT JOIN Cashiers
		ON(Cashiers.id = mt.cashier_id)
		ON(mt.client_type = 'ProductInfo.Buyer'
				 AND mt.client_id = so.buyer_ident_code 
				 AND mt.type = 'Take' 
				 AND mt.purpose = 'PayFor' 
				 AND mt.target_type = CASE WHEN LEN(so.zednadebis_nomeri) > 0 THEN 'ProductInfo.Zednadebi' ELSE 'ProductInfo.SellOrder' END
				 AND mt.target_ident = CASE WHEN LEN(so.zednadebis_nomeri) > 0 THEN so.zednadebis_nomeri ELSE CONVERT(nvarchar(MAX),so.id) END
				 )
		
		
		GROUP BY so.id, so.dro, mt.cashbox_id, mt.cashier_id, so.buyer_ident_code, b.name, so.zednadebis_nomeri, so.using_check, r.storehouse_id, Cashiers.sName
	) complex_select
END
