USE [productinfo_db]
GO

/****** Object:  Table [dbo].[SoldRemainders]    Script Date: 01/02/2012 12:35:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SoldRemainders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[remainder_id] [int] NOT NULL,
	[SellOrder_id] [int] NOT NULL,
	[piece_count] [decimal](28, 13) NOT NULL,
	[piece_price] [decimal](28, 13) NOT NULL,
 CONSTRAINT [PK_SoldRemainders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SoldRemainders]  WITH CHECK ADD  CONSTRAINT [FK_SoldRemainders_remainders] FOREIGN KEY([remainder_id])
REFERENCES [dbo].[remainders] ([id])
GO

ALTER TABLE [dbo].[SoldRemainders] CHECK CONSTRAINT [FK_SoldRemainders_remainders]
GO

ALTER TABLE [dbo].[SoldRemainders]  WITH CHECK ADD  CONSTRAINT [FK_SoldRemainders_SellOrder] FOREIGN KEY([SellOrder_id])
REFERENCES [dbo].[SellOrder] ([id])
GO

ALTER TABLE [dbo].[SoldRemainders] CHECK CONSTRAINT [FK_SoldRemainders_SellOrder]
GO

