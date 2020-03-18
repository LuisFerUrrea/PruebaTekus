
USE [BDClientes]


/****** Object:  Table [dbo].[Clientes]    Script Date: 17/03/2020 19:35:19 ******/
SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NULL,
	[Correo] [varchar](150) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Servicios]    Script Date: 17/03/2020 19:35:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Servicios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NULL,
	[ValorHora] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Servicios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pais]    Script Date: 17/03/2020 19:35:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](150) NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClienteXServicios]    Script Date: 17/03/2020 19:35:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteXServicios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[ServicioId] [int] NOT NULL,
 CONSTRAINT [PK_ClienteXServicios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Table [dbo].[ClienteSevicioXPais]    Script Date: 17/03/2020 19:35:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteSevicioXPais](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClienteXServicioId] [int] NOT NULL,
	[PaisId] [int] NOT NULL,
 CONSTRAINT [PK_ClienteSevicioXPais] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO


SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ClienteSevicioXPais]  WITH CHECK ADD  CONSTRAINT [FK_ClienteSevicioXPais_ClienteXServicios] FOREIGN KEY([ClienteXServicioId])
REFERENCES [dbo].[ClienteXServicios] ([Id])
GO
ALTER TABLE [dbo].[ClienteSevicioXPais] CHECK CONSTRAINT [FK_ClienteSevicioXPais_ClienteXServicios]
GO
ALTER TABLE [dbo].[ClienteSevicioXPais]  WITH CHECK ADD  CONSTRAINT [FK_ClienteSevicioXPais_Pais] FOREIGN KEY([PaisId])
REFERENCES [dbo].[Pais] ([Id])
GO
ALTER TABLE [dbo].[ClienteSevicioXPais] CHECK CONSTRAINT [FK_ClienteSevicioXPais_Pais]
GO
ALTER TABLE [dbo].[ClienteXServicios]  WITH CHECK ADD  CONSTRAINT [FK_ClienteXServicios_Clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
GO
ALTER TABLE [dbo].[ClienteXServicios] CHECK CONSTRAINT [FK_ClienteXServicios_Clientes]
GO
ALTER TABLE [dbo].[ClienteXServicios]  WITH CHECK ADD  CONSTRAINT [FK_ClienteXServicios_Servicios] FOREIGN KEY([ServicioId])
REFERENCES [dbo].[Servicios] ([Id])
GO
ALTER TABLE [dbo].[ClienteXServicios] CHECK CONSTRAINT [FK_ClienteXServicios_Servicios]
GO
