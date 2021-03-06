USE [PosWeb]
GO

/****** Object:  Table [dbo].[Productos]    Script Date: 23-12-2019 6:24:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Producto] [varchar](250) NULL,
	[IdFamilia] [int] NULL,
	[UnidadMedida] [varchar](150) NULL,
	[Estado] [int] NOT NULL,
	[Familia] [varchar](250) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Productos] ADD  CONSTRAINT [DF_Productos_Estado]  DEFAULT ((1)) FOR [Estado]
GO


------------------------

USE [PosWeb]
GO

/****** Object:  Table [dbo].[FamiliaProductos]    Script Date: 23-12-2019 6:24:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FamiliaProductos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Familia] [varchar](250) NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_FamiliaProductos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FamiliaProductos] ADD  CONSTRAINT [DF_FamiliaProductos_Estado]  DEFAULT ((1)) FOR [Estado]
GO


