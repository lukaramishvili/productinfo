-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateSoldRemainder] 
	  @SoldRemID int
	, @piece_count_arg decimal(28,13)
	, @piece_price_arg decimal(28,13)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF @SoldRemID IS NULL OR @piece_count_arg IS NULL OR @piece_price_arg IS NULL OR @SoldRemID = 0 OR @piece_count_arg = 0 OR @piece_price_arg = 0 RETURN 1
	--
	DECLARE @tran_name nvarchar(MAX) = 'UpdateSoldRemainderTransaction'
	
	BEGIN TRAN @tran_name
	
	DECLARE @rem_id int = (SELECT remainder_id FROM SoldRemainders WHERE id = @SoldRemID)
	DECLARE @cur_sold_count decimal(28,13) = (SELECT piece_count FROM SoldRemainders WHERE id = @SoldRemID)
	
	IF NOT (SELECT COUNT(*) FROM remainders WHERE id = @rem_id AND (remaining_pieces - ( @piece_count_arg - @cur_sold_count)) >= 0) > 0
	BEGIN
		ROLLBACK TRAN @tran_name
		RETURN 404
	END
	
	UPDATE remainders SET remaining_pieces = remaining_pieces - ( @piece_count_arg - @cur_sold_count) WHERE id = @rem_id

	IF @@ROWCOUNT = 0 
	BEGIN
		ROLLBACK TRAN @tran_name
		RETURN 404
	END
	
	UPDATE TOP (1) SoldRemainders SET piece_count = @piece_count_arg, piece_price = @piece_price_arg WHERE id = @SoldRemID
	
	--
	IF @@ROWCOUNT = 0 
	BEGIN
		ROLLBACK TRAN @tran_name
		RETURN 404
	END
	ELSE
	BEGIN
		COMMIT TRAN @tran_name
		RETURN 0
	END

END
