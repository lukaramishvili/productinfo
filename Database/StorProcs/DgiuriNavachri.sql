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
ALTER PROCEDURE DgiuriNavachri
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CONVERT(DATE,COMPLEX_SO.dro)
		 , SUM(COMPLEX_SO.col_1) as col_1
		 , 0 as col_2
		 , 0 as col_3
		 , 0 as col_4
		 , 0 as col_5
		 , 0 as col_6
		 --TODO: other formulas here too
	FROM 
		(SELECT 
			SO.id as id
		  , SO.dro as dro
		  , SUM(Sold.piece_count * Sold.piece_price) as col_1
		  --TODO: other formulas here
		FROM SoldRemainders Sold, SellOrder SO
		WHERE SO.id = Sold.SellOrder_id
		GROUP BY SO.id, SO.dro
		) COMPLEX_SO
	GROUP BY CONVERT(DATE,COMPLEX_SO.dro)
	ORDER BY CONVERT(DATE,COMPLEX_SO.dro) DESC
	--
END
GO
