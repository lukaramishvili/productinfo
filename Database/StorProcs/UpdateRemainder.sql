-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateRemainder] 
	  @RemID int
	, @piece_count_arg decimal(28,13)
	, @piece_price_arg decimal(28,13)
	, @capacity_arg decimal(28,13)
	, @piece_sell_price_arg decimal(28,13)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF @RemID IS NULL OR @piece_count_arg IS NULL OR @piece_price_arg IS NULL OR @capacity_arg IS NULL OR @RemID = 0 OR @piece_count_arg = 0 OR @piece_price_arg = 0 OR @capacity_arg = 0 RETURN 1
	--
	DECLARE @tran_name nvarchar(MAX) = 'UpdateRemainderTransaction'
	
	BEGIN TRAN @tran_name
	
	--DECLARE @rem_id int = (SELECT remainder_id FROM SoldRemainders WHERE id = @RemID)
	DECLARE @cur_sold_count decimal(28,13) = (SELECT SUM(piece_count) FROM SoldRemainders WHERE remainder_id = @RemID)
	
	IF @cur_sold_count IS NULL SELECT @cur_sold_count = 0
	
	IF NOT (SELECT COUNT(*) FROM remainders WHERE id = @RemID AND @piece_count_arg >= (@cur_sold_count) ) > 0
	BEGIN
		ROLLBACK TRAN @tran_name
		RETURN 404
	END
	
	UPDATE remainders SET remaining_pieces = @piece_count_arg - (initial_pieces-remaining_pieces), initial_pieces = @piece_count_arg, buy_price = @piece_price_arg, pack_capacity = @capacity_arg, sell_price = @piece_sell_price_arg WHERE id = @RemID

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
