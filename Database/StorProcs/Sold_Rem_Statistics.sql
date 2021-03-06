USE [productinfo_db]
GO
/****** Object:  StoredProcedure [dbo].[Sold_Rem_Statistics]    Script Date: 02/12/2012 23:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Sold_Rem_Statistics]
	-- Add the parameters for the stored procedure here
	@StoreID int
	,@since_date datetime
	,@until_date datetime
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
		
		
		
	SELECT 
			so_id,so_dro,cashbox_id,sName,buyer_name,store_id,zed_nomeri,using_check,whole_cost,costWithoutVAT,sold_price,sold_price_withoutVAT,sold_price_onlyVAT,paid_amount,whole_price_diff,price_diff_withoutVAT
		 FROM tblSold_Rem_Statistics so
		WHERE store_id LIKE @FilterStoreID AND so_dro >= @since_date AND so_dro <= @until_date
	ORDER BY so_dro DESC
END
