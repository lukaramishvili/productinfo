USE [productinfo_db]
GO

/****** Object:  UserDefinedTableType [dbo].[ListSellRemainder]    Script Date: 01/02/2012 12:38:38 ******/
CREATE TYPE [dbo].[ListSellRemainder] AS TABLE(
	[ixListSellRemainder] [int] NOT NULL,
	[barcode] [nvarchar](max) NULL,
	[storeID] [int] NULL,
	[selling_count] [decimal](28, 13) NULL,
	[piece_price] [decimal](28, 13) NULL,
	PRIMARY KEY CLUSTERED 
(
	[ixListSellRemainder] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO

