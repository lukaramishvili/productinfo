-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateProduct]
	-- Add the parameters for the stored procedure here
	@barcode nvarchar(MAX),
	@new_barcode nvarchar(MAX),
	@newname nvarchar(MAX),
	@newVATvalue int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @barcode IS NULL OR @newname IS NULL OR @newVATvalue IS NULL RETURN 1
	
	--es imitom rom axali saxeli dzvel arsebul romelime saxels ar daemtxves
	IF (SELECT COUNT(*) FROM dbo.products WHERE name = @newname AND barcode != @barcode) > 0
		RETURN 183
		
	--es imitom rom ori ertnairi barcode ar ganaxldes da axali ar chaeceros
	IF @barcode != @new_barcode AND (SELECT COUNT(*) FROM dbo.products WHERE barcode = @barcode) > 1
		RETURN 184
	
	--es imitom rom axali shtix-kodi dzvel romelime arsebuls ar daemtxves
	IF @barcode != @new_barcode AND (SELECT COUNT(*) FROM dbo.products WHERE barcode = @new_barcode) > 0
		RETURN 183
	
	UPDATE dbo.products SET name=@newname, uses_vat = @newVATvalue WHERE barcode = @barcode;
	IF @@ROWCOUNT = 0 RETURN 1
	
	--update product barcode everywhere
	IF @barcode != @new_barcode
	BEGIN
		BEGIN TRANSACTION tran_update_prod_barcode
		DECLARE @tran_upd_prod_barcode int = 0
		IF NOT (@new_barcode IS NULL) AND NOT (LEN(@new_barcode)<1)
		BEGIN
			DECLARE @assoc_rem_count int = (SELECT COUNT(id) FROM remainders WHERE product_barcode = @barcode)

			UPDATE products set barcode = @new_barcode WHERE barcode = @barcode
			IF @@ROWCOUNT < 1 
				SET @tran_upd_prod_barcode = 500
			UPDATE remainders SET product_barcode = @new_barcode WHERE product_barcode = @barcode
			IF @@ROWCOUNT != @assoc_rem_count 
				SET @tran_upd_prod_barcode = 500
			--
		END
		IF 0 = @tran_upd_prod_barcode
			COMMIT TRANSACTION tran_update_prod_barcode
		ELSE
			ROLLBACK TRANSACTION tran_update_prod_barcode
	END
	
	
END
