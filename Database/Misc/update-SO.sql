DECLARE @oneid int -- or the appropriate type

DECLARE the_cursor CURSOR FAST_FORWARD
FOR SELECT spro.Id  
    FROM SellOrder as spro where DATEpart(day,spro.dro) = DATEPART(day,GETDATE())
    AND  DATEpart(MONTH,spro.dro) = DATEPART(MONTH,GETDATE())

OPEN the_cursor
FETCH NEXT FROM the_cursor INTO @oneid

WHILE @@FETCH_STATUS = 0
BEGIN
    EXEC UpdateMTForSellOrder @oneid

    FETCH NEXT FROM the_cursor INTO @oneid
END

CLOSE the_cursor
DEALLOCATE the_cursor