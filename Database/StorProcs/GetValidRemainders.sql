-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetValidRemainders]
	-- Add the parameters for the stored procedure here
	@StoreID int
	,@usingCheck int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	----------------------------
	DECLARE @FilterStoreID nvarchar(MAX)
	IF @StoreID = 0 
		SET @FilterStoreID = '%'
	ELSE
		SET @FilterStoreID = CONVERT(nvarchar(MAX),@StoreID)
		
	----------------------------
	DECLARE @SuppNotToGet nvarchar(MAX)='007'; -- by default, don't select unregistered products
	

	IF @usingCheck = 0
		SELECT @SuppNotToGet = 'no_supplier_has_such_ident_code'; --supplier with such id doesn't exist
	

    -- Insert statements for procedure here
    SELECT products.name,remainders.* FROM remainders, products, zednadebi
    WHERE remainders.remaining_pieces>0 
    AND remainders.product_barcode = products.barcode
    --AND (remainders.storehouse_id LIKE @FilterStoreID)
    AND 0 < dbo.RemainderHasStoreAsSellableParent(remainders.id, @StoreID)
    AND remainders.supplier_ident != @SuppNotToGet
    
		AND zednadebi.client_id=remainders.supplier_ident 
		AND zednadebi.operation = 'Buy'
		AND remainders.zednadebis_nomeri = zednadebi.id_code
		
    ORDER BY products.name ASC, zednadebi.dro ASC -- zed.dro ASC dalageba !!aucilebelia rom yvelaze adrindeli nashtis asagebi fasi amoagdos --, remaining_pieces DESC
END
