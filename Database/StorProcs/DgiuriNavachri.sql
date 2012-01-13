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
ALTER PROCEDURE DgiuriNavachri
	-- Add the parameters for the stored procedure here
	  @store_id int
	, @date_since date
	, @date_until date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- jer titoeuli SellOrder-istvis vitvlit velebs (COMPLEX_SO) da shemdeg vajgufebt dgeebis mixedvit
	SELECT CONVERT(DATE,COMPLEX_SO.dro) as result_date
		 , SUM(COMPLEX_SO.SO_agebuli_tanxa) as sul_agebuli_tanxa
		 , SUM(COMPLEX_SO.SO_tvitgir) as sul_tvitgir
		 , SUM(((COMPLEX_SO.SO_agebuli_tanxa-COMPLEX_SO.SO_daubegr_gayid_sum)/1.18)+COMPLEX_SO.SO_daubegr_gayid_sum) as realiz_vat_gareshe
		 , SUM(((COMPLEX_SO.SO_tvitgir-COMPLEX_SO.SO_daubegr_tvitgir_sum)/1.18)+COMPLEX_SO.SO_daubegr_tvitgir_sum) as tvitgir_vat_gareshe
		 , SUM(COMPLEX_SO.SO_daubegr_gayid_sum) as sul_daubegr_gayid_sum--col_5
		 , SUM(COMPLEX_SO.SO_dakarguli) as sul_dakarguli
	FROM 
		(SELECT 
			SO.id as id
		  , SO.dro as dro
		  , ROUND(SUM(Sold.piece_count * Sold.piece_price),4) as SO_agebuli_tanxa--col_1
		  , ROUND(SUM(Sold.piece_count * r.buy_price),4) as SO_tvitgir--col_2
		  , ROUND(SUM((CASE WHEN p.uses_vat=0 THEN 1 ELSE 0 END)*Sold.piece_count*r.buy_price),4) as SO_daubegr_tvitgir_sum
		  , ROUND(SUM((CASE WHEN p.uses_vat=0 THEN 1 ELSE 0 END)*Sold.piece_count*Sold.piece_price),4) as SO_daubegr_gayid_sum--col_5
		  , ROUND(SUM(CASE WHEN Sold.piece_price < r.buy_price THEN Sold.piece_count*(r.buy_price - Sold.piece_price) ELSE 0 END),4) as SO_dakarguli--col_6
		FROM SoldRemainders Sold, SellOrder SO, remainders r, products p
		WHERE SO.id = Sold.SellOrder_id AND r.id = Sold.remainder_id AND p.barcode = r.product_barcode AND 1 = dbo.RemainderHasStoreAsSellableParent(r.id, @store_id)
		GROUP BY SO.id, SO.dro
		) COMPLEX_SO
	WHERE CONVERT(DATE,COMPLEX_SO.dro) >= @date_since AND CONVERT(DATE,COMPLEX_SO.dro) <= @date_until
	GROUP BY CONVERT(DATE,COMPLEX_SO.dro)
	ORDER BY CONVERT(DATE,COMPLEX_SO.dro) DESC
	--
END
GO
