USE [productinfo_db]
GO

/****** Object:  Table [dbo].[Cashiers]    Script Date: 01/02/2012 12:34:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cashiers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sName] [nvarchar](max) NOT NULL,
	[sPasswd] [nvarchar](max) NOT NULL,
	[eActive] [bit] NOT NULL,
 CONSTRAINT [PK_Cashiers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

