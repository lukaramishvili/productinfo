USE [productinfo_db]
GO

/****** Object:  Trigger [dbo].[UpdatetblSold_Rem_StatisticsOnMTChange]    Script Date: 01/02/2012 12:40:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[UpdatetblSold_Rem_StatisticsOnMTChange]
   ON  [dbo].[money_transfer]
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
    IF 'ProductInfo.SellOrder' = (SELECT target_type FROM INSERTED)
    BEGIN
		DECLARE @SellOrderID int
		SET @SellOrderID = (SELECT CONVERT(int,target_ident) FROM INSERTED)
		EXEC	--@return_value = 
			[dbo].[UpdatetblSold_Rem_Statistics]
			@SellOrderIDToUpdate = @SellOrderID
	END

END

GO

