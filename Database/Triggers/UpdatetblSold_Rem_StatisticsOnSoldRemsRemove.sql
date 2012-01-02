USE [productinfo_db]
GO

/****** Object:  Trigger [dbo].[UpdatetblSold_Rem_StatisticsOnSoldRemsRemove]    Script Date: 01/02/2012 12:41:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[UpdatetblSold_Rem_StatisticsOnSoldRemsRemove]
   ON [dbo].[SoldRemainders]
   AFTER DELETE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
    DECLARE @SellOrderID int
	SET @SellOrderID = (SELECT SellOrder_id FROM DELETED)
	EXEC	--@return_value = 
		[dbo].[UpdatetblSold_Rem_Statistics]
		@SellOrderIDToUpdate = @SellOrderID
	
END

GO

