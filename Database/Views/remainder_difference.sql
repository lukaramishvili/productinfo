USE [productinfo_db]
GO

/****** Object:  View [dbo].[remainder_difference]    Script Date: 01/02/2012 12:36:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[remainder_difference]
AS 
SELECT * FROM
(
SELECT 
	r.id
	, p.name
	, r.initial_pieces/r.pack_capacity as "საწყისი (ყუთები)"
	, r.remaining_pieces/r.pack_capacity as "დარჩენილია (ყუთები)"
	, r.initial_pieces as "საწყისი (საცალო)"
	, r.remaining_pieces as "დარჩენილია (საცალო)"
	, SUM(s.piece_count) as "სულ გაყიდულია (ცალი)"
	, (r.initial_pieces - SUM(s.piece_count) - r.remaining_pieces) as სხვაობა 
	FROM products p, remainders r, SoldRemainders s
	where s.remainder_id = r.id AND r.product_barcode = p.barcode
	GROUP BY r.id, r.initial_pieces, r.remaining_pieces, p.name, r.pack_capacity
) sel
WHERE სხვაობა !=0

--3828920183347
GO

