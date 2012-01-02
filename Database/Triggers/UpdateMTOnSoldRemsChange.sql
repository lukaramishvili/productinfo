USE [productinfo_db]
GO

/****** Object:  Trigger [dbo].[UpdateMTOnSoldRemsChange]    Script Date: 01/02/2012 12:40:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[UpdateMTOnSoldRemsChange] ON [dbo].[SoldRemainders]
AFTER INSERT, UPDATE
AS

DECLARE @SellOrderID int
SET @SellOrderID = (SELECT SellOrder_id FROM INSERTED)
DECLARE @SellOrderSum decimal(28,13) = (SELECT SUM(piece_count*piece_price) FROM dbo.SoldRemainders WHERE SellOrder_id = @SellOrderID )

IF 'Nagdi' = (SELECT pay_method FROM dbo.SellOrder WHERE id = @SellOrderID)
BEGIN
	IF 0 < LEN(ISNULL((SELECT zednadebis_nomeri from SellOrder WHERE id = @SellOrderID),''))
	BEGIN
		DECLARE @ZedIdentCode nvarchar(MAX)
		SET @ZedIdentCode = (SELECT zednadebis_nomeri FROM SellOrder WHERE id = @SellOrderID)
		UPDATE dbo.money_transfer 
		SET amount = @SellOrderSum
			WHERE type = 'Take'
			AND client_type = 'ProductInfo.Buyer' 
			AND purpose = 'PayFor' 
			AND target_type = 'ProductInfo.Zednadebi' 
			AND target_ident = @ZedIdentCode
	END
	ELSE
	BEGIN
		UPDATE dbo.money_transfer 
		SET amount = @SellOrderSum
			WHERE type = 'Take'
			AND client_type = 'ProductInfo.Buyer' 
			AND purpose = 'PayFor' 
			AND target_type = 'ProductInfo.SellOrder' 
			AND target_ident = CONVERT(nvarchar(MAX),@SellOrderID)
	END
END
GO

