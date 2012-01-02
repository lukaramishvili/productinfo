-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.Sxvaoba
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    
SELECT * FROM 
				(SELECT 
							r.id
							, p.barcode
							, r.initial_pieces
							, r.remaining_pieces
							, SUM(s.piece_count) AS sumPieceCount
							, (r.initial_pieces - r.remaining_pieces - SUM(s.piece_count)) AS sxvaoba
FROM products p, remainders r, SoldRemainders s
WHERE r.product_barcode = p.barcode AND s.remainder_id = r.id
AND NOT r.initial_pieces - r.remaining_pieces - s.piece_count = 0
    GROUP BY r.id, p.barcode, r.initial_pieces, r.remaining_pieces
    ) DiffTable    
    WHERE sxvaoba > 0 OR sxvaoba < 0
    
END
