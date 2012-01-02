USE [productinfo_db]
GO

/****** Object:  Table [dbo].[SellOrder]    Script Date: 01/02/2012 12:35:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SellOrder](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dro] [datetime] NOT NULL,
	[buyer_ident_code] [nvarchar](max) NULL,
	[zednadebis_nomeri] [nvarchar](max) NOT NULL,
	[using_check] [int] NOT NULL,
	[pay_method] [nvarchar](max) NULL,
 CONSTRAINT [PK_sold]]] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

