USE [productinfo_db]
GO

/****** Object:  Table [dbo].[zednadebi]    Script Date: 01/02/2012 12:35:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[zednadebi](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_code] [nvarchar](max) NOT NULL,
	[dro] [datetime] NOT NULL,
	[operation] [nvarchar](max) NOT NULL,
	[client_id] [nvarchar](max) NOT NULL,
	[af_seria] [nvarchar](max) NULL,
	[af_nomeri] [nvarchar](max) NULL,
	[pay_method] [nvarchar](max) NULL,
 CONSTRAINT [PK_zednadebi] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

