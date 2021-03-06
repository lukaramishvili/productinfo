SELECT r.id, p.barcode, p.name, sold.id, outgZed.id_code, outgZed.dro 
FROM SellOrder SO, SoldRemainders sold, 
remainders r, products p, zednadebi incZ, zednadebi outgZed
WHERE sold.SellOrder_id = SO.id AND remainder_id = r.id AND product_barcode = p.barcode 
AND r.supplier_ident = incZ.client_id AND incZ.operation = N'Buy' AND incZ.id_code = r.zednadebis_nomeri
AND incZ.id_code = N'თბ0130281'
AND outgZed.operation = N'Sell' AND outgZed.client_id = SO.buyer_ident_code
AND outgZed.id_code = SO.zednadebis_nomeri
ORDER BY r.id ASC