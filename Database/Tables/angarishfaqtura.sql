USE [productinfo_db]
GO

/****** Object:  Table [dbo].[angarishfaqtura]    Script Date: 01/02/2012 12:34:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[angarishfaqtura](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[af_nomeri] [nvarchar](max) NOT NULL,
	[af_seria] [nvarchar](max) NOT NULL,
	[dro] [datetime] NOT NULL,
	[operation] [nvarchar](max) NOT NULL,
	[client_ident] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_angarishfaqtura] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

