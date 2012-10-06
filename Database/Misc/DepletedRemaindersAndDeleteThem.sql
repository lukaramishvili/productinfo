select CONVERT(decimal(23,6),(select COUNT(*) from remainders where remaining_pieces = 0)) / CONVERT(decimal(23,6),(select COUNT(*) from remainders)) * 100

select CONVERT(decimal(23,6),(select COUNT(*) from SoldRemainders sold where exists (select * from remainders where id = sold.remainder_id AND remaining_pieces = 0))) / CONVERT(decimal(23,6),(select COUNT(*) from SoldRemainders)) * 100

select CONVERT(decimal(23,6),(select COUNT(*) from SellOrder SO where exists (select * from SoldRemainders sold, remainders r where r.id = sold.remainder_id AND r.remaining_pieces = 0 AND sold.SellOrder_id = SO.id))) / CONVERT(decimal(23,6),(select COUNT(*) from SellOrder)) * 100

select CONVERT(decimal(23,6),(select COUNT(*) from zednadebi where not exists (select * from remainders r where r.zednadebis_nomeri = zednadebi.id_code AND r.supplier_ident = client_id AND r.remaining_pieces > 0) AND operation=N'Buy' )) / CONVERT(decimal(23,6),(select COUNT(*) from zednadebi where operation = N'Buy')) * 100



IF 1 = 0 
BEGIN
	delete from SoldRemainders where exists (select * from remainders r where r.id = remainder_id AND r.remaining_pieces = 0 and r.id = remainder_id)

	delete from remainders where remaining_pieces = 0

	delete from SellOrder where not exists (select * from (select SellOrder_id from SoldRemainders) sold where sold.SellOrder_id = id)
	
	delete from zednadebi where not exists (select * from remainders r where r.zednadebis_nomeri = zednadebi.id_code AND r.supplier_ident = client_id AND r.remaining_pieces > 0) AND operation=N'Buy' 
END