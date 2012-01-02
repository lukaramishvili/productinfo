USE [productinfo_db]
GO

/****** Object:  Table [dbo].[remainders]    Script Date: 01/02/2012 12:35:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[remainders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_barcode] [nvarchar](max) NOT NULL,
	[supplier_ident] [nvarchar](max) NOT NULL,
	[zednadebis_nomeri] [nvarchar](max) NOT NULL,
	[initial_pieces] [decimal](28, 13) NOT NULL,
	[remaining_pieces] [decimal](28, 13) NOT NULL,
	[pack_capacity] [decimal](28, 13) NOT NULL,
	[buy_price] [decimal](28, 13) NOT NULL,
	[formal_buy_price] [decimal](28, 13) NULL,
	[sell_price] [decimal](28, 13) NULL,
	[formal_sell_price] [decimal](28, 13) NULL,
	[storehouse_id] [int] NOT NULL,
 CONSTRAINT [PK_remainders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

