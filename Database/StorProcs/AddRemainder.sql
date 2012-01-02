-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddRemainder]
	@barcode nvarchar(MAX),
	@supplier_ident nvarchar(MAX),
	@zed_nomeri nvarchar(MAX),
	@initial_pieces decimal(28,13),
	@remaining_pieces decimal(28,13),
	@capacity decimal(28,13),
	@buy_price decimal(28,13),
	@sell_price decimal(28,13),
	@store_id int
	
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    IF	@barcode = '' OR
		@supplier_ident = '' OR
		@zed_nomeri = '' OR
		@initial_pieces <= 0 OR
		@remaining_pieces <=0 OR
		@capacity <=0 OR
		@buy_price <=0 OR
		@sell_price <0
		RETURN 1
    -- prevent duplicate products on the same zed
		IF (SELECT COUNT(*) FROM remainders
							WHERE zednadebis_nomeri = @zed_nomeri
							AND supplier_ident = @supplier_ident
							AND product_barcode = @barcode
							AND storehouse_id = @store_id
			)>0
			RETURN 183
			
		--prevent different prices in different stores
		IF (SELECT COUNT(*) FROM remainders
						WHERE zednadebis_nomeri = @zed_nomeri
						AND supplier_ident = @supplier_ident
						AND product_barcode = @barcode
						AND storehouse_id != @store_id
						AND (buy_price != @buy_price OR pack_capacity != @capacity)
		)>0
		RETURN 183

    
	INSERT INTO dbo.remainders (product_barcode,
								supplier_ident,
								zednadebis_nomeri,
								initial_pieces,
								remaining_pieces,
								pack_capacity,
								buy_price,
								sell_price,
								storehouse_id)
						VALUES (@barcode,
								@supplier_ident,
								@zed_nomeri,
								@initial_pieces,
								@remaining_pieces,
								@capacity,
								@buy_price,
								@sell_price,
								@store_id)
	IF @@ROWCOUNT = 0 RETURN 1	
END
