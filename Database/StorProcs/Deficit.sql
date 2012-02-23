-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE Deficit
	-- Add the parameters for the stored procedure here
	  @store_id int
	, @date_since DATETIME
	, @date_until DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--DECLARE @date_since DATE = DATEADD(DD, 1, GetDate())--DATEADD(DD 1) to @date_since to include today
	--DECLARE @date_until DATE = DATEADD(DD, -700, @date_since)
    -- Insert statements for procedure here
    SELECT DISTINCT REMAINING.barcode, REMAINING.name as product_name, MATCHED_SUPPLIERS.supplier_name, REMAINING.remaining_pieces 
		FROM 
		(SELECT p.name, p.barcode, SUM(r.remaining_pieces) as remaining_pieces
			FROM products p, remainders r, SoldRemainders sold, zednadebi incZed, /*zednadebi outgZed, */suppliers supp
			WHERE p.barcode = r.product_barcode AND r.id = sold.remainder_id AND supp.id_code = r.supplier_ident AND incZed.id_code = r.zednadebis_nomeri
				AND incZed.operation = N'Buy' /*AND outgZed.operation = N'Sell'*/
				AND incZed.dro < @date_until AND incZed.dro > @date_since AND 1 = dbo.RemainderHasStoreAsSellableParent(r.id, @store_id)
			GROUP BY r.product_barcode, p.name, p.barcode
			HAVING SUM(r.remaining_pieces) < 5 AND SUM(r.remaining_pieces) > 0
		 ) REMAINING
		 , (SELECT TOP(100000000000) p2.barcode, s2.name as supplier_name FROM suppliers s2, remainders r2, products p2, zednadebi z2
				WHERE z2.operation = N'Buy' AND z2.client_id = s2.id_code AND r2.supplier_ident = s2.id_code AND r2.product_barcode = p2.barcode
				ORDER BY z2.dro DESC
		) MATCHED_SUPPLIERS
		WHERE  MATCHED_SUPPLIERS.barcode = REMAINING.barcode
END
GO
