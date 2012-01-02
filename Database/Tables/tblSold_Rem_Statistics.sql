USE [productinfo_db]
GO

/****** Object:  Table [dbo].[tblSold_Rem_Statistics]    Script Date: 01/02/2012 12:35:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblSold_Rem_Statistics](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[so_id] [int] NOT NULL,
	[so_dro] [datetime] NULL,
	[cashbox_id] [nvarchar](max) NULL,
	[sName] [nvarchar](max) NULL,
	[buyer_name] [nvarchar](max) NULL,
	[store_id] [int] NULL,
	[zed_nomeri] [nvarchar](max) NULL,
	[using_check] [int] NULL,
	[whole_cost] [decimal](28, 13) NULL,
	[costWithoutVAT] [decimal](28, 13) NULL,
	[sold_price] [decimal](28, 13) NULL,
	[paid_amount] [decimal](28, 13) NULL,
	[whole_price_diff] [decimal](28, 13) NULL,
	[price_diff_withoutVAT] [decimal](28, 13) NULL,
 CONSTRAINT [PK_tblSold_Rem_Statistics] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

