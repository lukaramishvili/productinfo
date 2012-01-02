USE [productinfo_db]
GO

/****** Object:  Table [dbo].[stores]    Script Date: 01/02/2012 12:35:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[stores](
	[id] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ParentID] [int] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[ResponsibleUserID] [int] NULL,
	[HasOwnStorageSpace] [int] NOT NULL,
	[CanSell] [int] NOT NULL,
 CONSTRAINT [PK_stores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

