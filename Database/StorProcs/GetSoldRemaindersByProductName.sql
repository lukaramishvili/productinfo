-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSoldRemaindersByProductName]
	-- Add the parameters for the stored procedure here
	--@product_barcode nvarchar(MAX) output,
	--@product_name nvarchar(MAX) output,
	--@remaining_pieces float output,
	--@whole_remaining_sum float output
	  @StoreID int
	, @Since datetime
	, @Until datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @FilterStoreID nvarchar(MAX)
	IF @StoreID = 0 
		SET @FilterStoreID = '%'
	ELSE
		SET @FilterStoreID = CONVERT(nvarchar(MAX),@StoreID)
		
		 
	SELECT	  products.barcode
			, products.name
			, supp.name
			, SUM(sum_sold)
			, AVG(sum_price/sum_sold)
			, AVG(sum_cost/sum_sold)
			, dbo.CostWithoutVAT(AVG(sum_cost/sum_sold)
			, AVG(products.uses_vat)) 
			, SUM(sum_sold) * AVG(sum_cost/sum_sold)
			, SUM(sum_sold) * AVG(sum_price/sum_sold)
		
	FROM 
	
								(SELECT		  SUM(piece_count) as sum_sold
											, SUM(SoldRemainders.piece_count*SoldRemainders.piece_price) as sum_price 
											, SUM(SoldRemainders.piece_count*remainders.buy_price) as sum_cost
										, remainder_id
										, product_barcode 
										
									FROM dbo.SoldRemainders, (SELECT * FROM remainders) remainders, SellOrder
									 
									WHERE SoldRemainders.remainder_id = remainders.id
											AND remainders.storehouse_id LIKE @FilterStoreID
											AND SoldRemainders.SellOrder_id = SellOrder.id
											AND SellOrder.dro > @Since AND SellOrder.dro < @Until
											
								GROUP BY product_barcode, remainder_id)
	ss
 
	LEFT JOIN products ON( ss.product_barcode=products.barcode)
	
	
	LEFT JOIN (SELECT DISTINCT(product_barcode), MAX(id) as id FROM remainders GROUP BY product_barcode) as r4id
	ON (r4id.product_barcode = products.barcode)
	LEFT JOIN remainders as r4supp
	ON (r4supp.id = r4id.id)
	LEFT JOIN suppliers supp
	ON (supp.id_code = r4supp.supplier_ident)

 
 GROUP BY barcode, products.name, supp.name
	/*
	SELECT p.barcode as product_barcode, 
	p.name as product_name, 
	SUM(sold.piece_count) as total_count,
	SUM(sold.piece_count*sold.piece_price)/SUM(sold.piece_count) as avg_sell_price,
	SUM(r.buy_price*r.remaining_pieces)/(CASE SUM(r.remaining_pieces) WHEN 0 THEN 1 ELSE SUM(r.remaining_pieces) END) AS piece_price, 
	
	--AVG(dbo.CostWithoutVAT(r.buy_price,p.uses_vat)) AS whole_remaining_sum_withoutVAT
	SUM(dbo.CostWithoutVAT(r.buy_price,p.uses_vat)*r.remaining_pieces)/(CASE SUM(r.remaining_pieces) WHEN 0 THEN 1 ELSE SUM(r.remaining_pieces) END) AS whole_remaining_sum_withoutVAT
	
	FROM (SELECT products.* FROM products, remainders, SoldRemainders, SellOrder
			WHERE remainders.product_barcode = products.barcode AND SoldRemainders.remainder_id = remainders.id
			AND SellOrder.id = SoldRemainders.SellOrder_id AND SellOrder.dro > @Since AND SellOrder.dro < @Until 
			) p
	
	LEFT JOIN (SELECT * FROM remainders WHERE (remainders.storehouse_id = @StoreID1 OR remainders.storehouse_id = @StoreID2) ) r
	ON (p.barcode = r.product_barcode)
		
	LEFT JOIN (SELECT SoldRemainders.* FROM SoldRemainders, SellOrder
				WHERE SoldRemainders.SellOrder_id = SellOrder.id 
				AND SellOrder.dro > @Since AND SellOrder.dro < @Until
				) 
	sold
	ON(sold.remainder_id = r.id)
	GROUP BY p.barcode, p.name
	ORDER BY total_count DESC*/
	
	--SELECT @product_barcode = prods.barcode,
	--@product_name=prods.name,
	--@remaining_pieces=SUM(rems.remaining_pieces), 
	--@whole_remaining_sum = SUM(rems.buy_price) 
	--FROM dbo.remainders AS rems,dbo.products AS prods WHERE rems.product_barcode = prods.barcode
	--group by prods.barcode, prods.name
	
END
