-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemainderByID]
	@RemID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    IF @RemID IS NULL RETURN 1
    
    SELECT	  r.initial_pieces AS init_pieces
			, r.buy_price
			, r.sell_price
			, r.pack_capacity
			, r.supplier_ident
			, z.dro
			, z.id_code
    
    FROM (SELECT * FROM remainders WHERE id = @RemID ) r
    
    LEFT JOIN zednadebi z
    ON (r.zednadebis_nomeri = z.id_code AND r.supplier_ident = z.client_id AND z.operation = 'Buy')
    
	
	
END
