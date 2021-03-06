USE [BDClientes]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

GO
INSERT [dbo].[Clientes] ([Id], [Nombre], [Correo]) VALUES (1, N'Importaciones Tekus S.A.', N'impor.tekeus@gmail.com')
GO
INSERT [dbo].[Clientes] ([Id], [Nombre], [Correo]) VALUES (2, N'Apple', N'Apple.app@gmail.com')
GO
INSERT [dbo].[Clientes] ([Id], [Nombre], [Correo]) VALUES (3, N'Google', N'Google.app@gmail.com')
GO
INSERT [dbo].[Clientes] ([Id], [Nombre], [Correo]) VALUES (4, N'Amazon', N'Amazon.app@gmail.com')
GO
INSERT [dbo].[Clientes] ([Id], [Nombre], [Correo]) VALUES (5, N'Coca-Cola', N'CocaCola@gmail.com')
GO
INSERT [dbo].[Clientes] ([Id], [Nombre], [Correo]) VALUES (6, N'IBM', N'ibm@gmail.com')
GO
INSERT [dbo].[Clientes] ([Id], [Nombre], [Correo]) VALUES (7, N'FedEx', N'FedEx@gmail.com')
GO
INSERT [dbo].[Clientes] ([Id], [Nombre], [Correo]) VALUES (8, N'Berkshire', N'Berkshire@gmail.com')
GO
INSERT [dbo].[Clientes] ([Id], [Nombre], [Correo]) VALUES (9, N'Starbucks', N'Starbucks@gmail.com')
GO
INSERT [dbo].[Clientes] ([Id], [Nombre], [Correo]) VALUES (10, N'Procter', N'Procter@gmail.com')
GO
INSERT [dbo].[Clientes] ([Id], [Nombre], [Correo]) VALUES (11, N'Southwest', N'Southwest@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Servicios] ON 

GO
INSERT [dbo].[Servicios] ([Id], [Nombre], [ValorHora]) VALUES (1, N'Descarga espacial de contenidos', CAST(130000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Servicios] ([Id], [Nombre], [ValorHora]) VALUES (2, N'Desaparición forzada de bytes', CAST(155980.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Servicios] ([Id], [Nombre], [ValorHora]) VALUES (4, N'Asesoramiento', CAST(187000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Servicios] ([Id], [Nombre], [ValorHora]) VALUES (5, N'Desarrollo de software', CAST(350000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Servicios] ([Id], [Nombre], [ValorHora]) VALUES (6, N'Servicio técnico', CAST(120000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Servicios] ([Id], [Nombre], [ValorHora]) VALUES (7, N'Mantenimiento preventivo', CAST(98700.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Servicios] ([Id], [Nombre], [ValorHora]) VALUES (8, N'Alquiler de servicios informáticos', CAST(56900.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Servicios] ([Id], [Nombre], [ValorHora]) VALUES (10, N'publicaciones diarios estadounidenses', CAST(3900.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Servicios] OFF
GO
SET IDENTITY_INSERT [dbo].[ClienteXServicios] ON 

GO
INSERT [dbo].[ClienteXServicios] ([Id], [ClienteId], [ServicioId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[ClienteXServicios] ([Id], [ClienteId], [ServicioId]) VALUES (2, 2, 2)
GO
INSERT [dbo].[ClienteXServicios] ([Id], [ClienteId], [ServicioId]) VALUES (3, 2, 4)
GO
INSERT [dbo].[ClienteXServicios] ([Id], [ClienteId], [ServicioId]) VALUES (4, 2, 5)
GO
INSERT [dbo].[ClienteXServicios] ([Id], [ClienteId], [ServicioId]) VALUES (5, 2, 6)
GO
INSERT [dbo].[ClienteXServicios] ([Id], [ClienteId], [ServicioId]) VALUES (6, 3, 2)
GO
INSERT [dbo].[ClienteXServicios] ([Id], [ClienteId], [ServicioId]) VALUES (7, 3, 5)
GO
INSERT [dbo].[ClienteXServicios] ([Id], [ClienteId], [ServicioId]) VALUES (8, 4, 7)
GO
INSERT [dbo].[ClienteXServicios] ([Id], [ClienteId], [ServicioId]) VALUES (9, 4, 8)
GO
INSERT [dbo].[ClienteXServicios] ([Id], [ClienteId], [ServicioId]) VALUES (10, 5, 2)
GO
INSERT [dbo].[ClienteXServicios] ([Id], [ClienteId], [ServicioId]) VALUES (11, 5, 7)
GO
SET IDENTITY_INSERT [dbo].[ClienteXServicios] OFF
GO
SET IDENTITY_INSERT [dbo].[Pais] ON 

GO
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (1, N'Colombia')
GO
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (2, N'Peru')
GO
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (3, N'Mexico')
GO
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (4, N'Brazil')
GO
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (5, N'Chile')
GO
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (6, N'Canada')
GO
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (7, N'Bolivia')
GO
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (8, N'Estados Unidos')
GO
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (9, N'España')
GO
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (10, N'Argentina')
GO
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (11, N'Alemania')
GO
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (12, N'Uruguay')
GO
INSERT [dbo].[Pais] ([Id], [Nombre]) VALUES (13, N'Paraguay')
GO
SET IDENTITY_INSERT [dbo].[Pais] OFF
GO
SET IDENTITY_INSERT [dbo].[ClienteSevicioXPais] ON 

GO
INSERT [dbo].[ClienteSevicioXPais] ([Id], [ClienteXServicioId], [PaisId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[ClienteSevicioXPais] ([Id], [ClienteXServicioId], [PaisId]) VALUES (2, 1, 2)
GO
INSERT [dbo].[ClienteSevicioXPais] ([Id], [ClienteXServicioId], [PaisId]) VALUES (3, 1, 3)
GO
INSERT [dbo].[ClienteSevicioXPais] ([Id], [ClienteXServicioId], [PaisId]) VALUES (4, 2, 5)
GO
INSERT [dbo].[ClienteSevicioXPais] ([Id], [ClienteXServicioId], [PaisId]) VALUES (5, 2, 6)
GO
INSERT [dbo].[ClienteSevicioXPais] ([Id], [ClienteXServicioId], [PaisId]) VALUES (6, 3, 8)
GO
INSERT [dbo].[ClienteSevicioXPais] ([Id], [ClienteXServicioId], [PaisId]) VALUES (7, 3, 9)
GO
INSERT [dbo].[ClienteSevicioXPais] ([Id], [ClienteXServicioId], [PaisId]) VALUES (8, 3, 10)
GO
INSERT [dbo].[ClienteSevicioXPais] ([Id], [ClienteXServicioId], [PaisId]) VALUES (9, 8, 7)
GO
INSERT [dbo].[ClienteSevicioXPais] ([Id], [ClienteXServicioId], [PaisId]) VALUES (10, 8, 11)
GO
INSERT [dbo].[ClienteSevicioXPais] ([Id], [ClienteXServicioId], [PaisId]) VALUES (11, 8, 13)
GO
SET IDENTITY_INSERT [dbo].[ClienteSevicioXPais] OFF
GO
