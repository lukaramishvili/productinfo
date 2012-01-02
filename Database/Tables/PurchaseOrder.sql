USE [productinfo_db]
GO

/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 01/02/2012 12:35:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PurchaseOrder](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dro] [datetime] NOT NULL,
	[supplier_ident_code] [nvarchar](max) NOT NULL,
	[zednadebis_nomeri] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_bought] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

