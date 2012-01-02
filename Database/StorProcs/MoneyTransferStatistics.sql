-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MoneyTransferStatistics]
	-- Add the parameters for the stored procedure here
	
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
	
    -- Insert statements for procedure here
	SELECT	  
			  mt.id,
			  CASE mt.client_type 
				WHEN 'ProductInfo.Supplier' THEN N'მომწოდებელი'
				WHEN 'ProductInfo.Buyer' THEN N'მყიდველი'
				END
			, CASE mt.client_type 
				WHEN 'ProductInfo.Supplier' THEN s.name
				WHEN 'ProductInfo.Buyer' THEN b.name
				END
			, CASE mt.type
				WHEN 'Take' THEN N'გამოვართვით'
				WHEN 'Give' THEN N'მივეცით'
				END
			, mt.dro
			, mt.amount
			, mt.purpose
			, mt.store_id
			, mt.target_type
			, mt.target_ident
			, mt.cashbox_id
			, mt.cashier_id
			
			FROM (SELECT * FROM money_transfer WHERE store_id LIKE @FilterStoreID AND dro > @Since AND dro < @Until
			)mt
			LEFT JOIN suppliers s
			ON(mt.client_type = 'ProductInfo.Supplier' AND s.id_code = mt.client_id)
			LEFT JOIN buyers b
			ON(mt.client_type = 'ProductInfo.Buyer' AND b.id_code = mt.client_id)
			ORDER BY mt.dro DESC
END
