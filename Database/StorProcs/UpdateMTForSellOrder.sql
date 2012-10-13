-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE UpdateMTForSellOrder
	-- Add the parameters for the stored procedure here
	@SellOrderID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--DECLARE @SellOrderID int
	--SET @SellOrderID = (SELECT SellOrder_id FROM DELETED)
	DECLARE @SellOrderSum decimal(28,13) = ISNULL((SELECT SUM(piece_count*piece_price) FROM dbo.SoldRemainders WHERE SellOrder_id = @SellOrderID ),0)

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
END
GO
