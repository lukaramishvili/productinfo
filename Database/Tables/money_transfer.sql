USE [productinfo_db]
GO

/****** Object:  Table [dbo].[money_transfer]    Script Date: 01/02/2012 12:34:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[money_transfer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](max) NOT NULL,
	[dro] [datetime] NOT NULL,
	[amount] [decimal](28, 13) NOT NULL,
	[client_type] [nvarchar](max) NOT NULL,
	[client_id] [nvarchar](max) NOT NULL,
	[purpose] [nvarchar](max) NULL,
	[store_id] [int] NULL,
	[target_type] [nvarchar](max) NULL,
	[target_ident] [nvarchar](max) NULL,
	[cashbox_id] [int] NULL,
	[cashier_id] [int] NULL
) ON [PRIMARY]

GO

