-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SoldRemainderByID
	@SoldRemID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    IF @SoldRemID IS NULL RETURN 1
	SELECT	  sr.piece_count AS piece_count
			, sr.piece_price AS piece_price
			,r.pack_capacity AS pack_capacity
			, b.name AS buyer_name
			, so.dro AS order_time
			, so.using_check AS using_check
			, so.zednadebis_nomeri AS zed_ident
				FROM 
					(SELECT * 
					FROM dbo.SoldRemainders
					WHERE id = @SoldRemID
					) sr
		LEFT JOIN dbo.SellOrder so
		ON (sr.SellOrder_id = so.id)
		LEFT JOIN dbo.buyers b
		ON (b.id_code = so.buyer_ident_code)
		LEFT JOIN dbo.remainders r
		ON(r.id = sr.remainder_id)
	
END
