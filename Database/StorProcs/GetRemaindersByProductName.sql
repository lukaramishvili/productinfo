-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetRemaindersByProductName]
	-- Add the parameters for the stored procedure here
	--@product_barcode nvarchar(MAX) output,
	--@product_name nvarchar(MAX) output,
	--@remaining_pieces float output,
	--@whole_remaining_sum float output
	@StoreID int
	, @FromTime datetime
	, @ToTime datetime
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
	
	SELECT p.barcode as product_barcode, 
	p.name as product_name,
	s.name as supplier_name,
	r.pack_capacity as rem_capacity, 
	r.initial_pieces as initial_pieces, 
	r.sum_initial_cost AS sum_initial_cost, 
	--CONVERT(nvarchar(MAX),((r.remaining_pieces-(CONVERT(int,r.remaining_pieces)%CONVERT(int, r.pack_capacity)))/r.pack_capacity))+'/'+CONVERT(nvarchar(MAX),r.remaining_pieces) AS remaining_pieces, 
	r.remaining_pieces AS remaining_pieces, 
	r.buy_price AS piece_price, 
	r.remaining_pieces*r.buy_price AS whole_remaining_sum, 
	dbo.CostWithoutVAT(r.remaining_pieces*r.buy_price,p.uses_vat) AS whole_remaining_sum_withoutVAT
	
	FROM (SELECT products.* 
			FROM products, remainders
			WHERE remainders.product_barcode = products.barcode AND remainders.storehouse_id LIKE @FilterStoreID
			) p
	
	LEFT JOIN (
				SELECT 
					  SUM(rems.remaining_pieces) AS remaining_pieces
					, SUM(rems.remaining_pieces*rems.buy_price)/SUM(rems.remaining_pieces) AS buy_price
					, SUM(rems.initial_pieces) as initial_pieces
					, SUM(rems.sum_initial_cost) as sum_initial_cost
					, AVG(pack_capacity) AS pack_capacity
					, product_barcode
					FROM (SELECT 
								filteredrems.id
								, filteredrems.product_barcode
								, filteredrems.initial_pieces
								, filteredrems.remaining_pieces+ISNULL(sold_after.piece_count,0) as remaining_pieces
								, filteredrems.pack_capacity
								, filteredrems.buy_price 
								, filteredrems.initial_pieces * filteredrems.buy_price as sum_initial_cost
								FROM 
							   (SELECT remainders.* FROM remainders, zednadebi
										  WHERE remainders.storehouse_id LIKE @FilterStoreID 
												AND zednadebi.client_id = remainders.supplier_ident
												AND zednadebi.operation = 'Buy'
												AND zednadebi.id_code = remainders.zednadebis_nomeri
												AND zednadebi.dro > @FromTime
												AND zednadebi.dro < @ToTime
															--AND remainders.remaining_pieces > 0
								) filteredrems
								LEFT JOIN (	
												SELECT SUM(SoldRemainders.piece_count) AS piece_count, SoldRemainders.remainder_id
												FROM SoldRemainders, SellOrder
												WHERE SoldRemainders.SellOrder_id = SellOrder.id 
													AND SellOrder.dro > @ToTime
												GROUP BY remainder_id
								) sold_after
								ON(sold_after.remainder_id = filteredrems.id)
					  ) rems
					  WHERE rems.remaining_pieces > 0
					  GROUP BY product_barcode
					  
					  ) r
	ON (p.barcode = r.product_barcode)
	LEFT JOIN (SELECT DISTINCT(product_barcode), MAX(id) as id FROM remainders GROUP BY product_barcode) as r4id
	ON (r4id.product_barcode = p.barcode)
	LEFT JOIN remainders as r4supp
	ON (r4supp.id = r4id.id)
	LEFT JOIN suppliers s
	ON (s.id_code = r4supp.supplier_ident)
	GROUP BY p.barcode, p.name, r.pack_capacity, r.initial_pieces, r.remaining_pieces, r.buy_price, r.sum_initial_cost, p.uses_vat, r4supp.supplier_ident, s.name
	
	UNION
		
	SELECT p.barcode as product_barcode
			, p.name product_name
			, '' as supplier_name
			, 0 as rem_capacity
			, 0 AS initial_pieces
			, 0 AS sum_initial_cost
			, 0 AS remaining_pieces
			, 0 as piece_price
			, 0 whole_remaining_sum
			, 0  AS whole_remaining_sum_withoutVAT
	FROM products p
	WHERE NOT EXISTS(SELECT * FROM remainders where product_barcode=p.barcode)
	
	--ORDER BY r.remaining_pieces*r.buy_price DESC
	ORDER BY p.name ASC
	
	
	--SELECT @product_barcode = prods.barcode,
	--@product_name=prods.name,
	--@remaining_pieces=SUM(rems.remaining_pieces), 
	--@whole_remaining_sum = SUM(rems.buy_price) 
	--FROM dbo.remainders AS rems,dbo.products AS prods WHERE rems.product_barcode = prods.barcode
	--group by prods.barcode, prods.name
	
END
