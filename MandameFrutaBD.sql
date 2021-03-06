/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4206)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [MandameFrutaBD]
GO
/****** Object:  Table [dbo].[Arbol]    Script Date: vi. 13 de oct. 2017 1:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arbol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Variedad] [varchar](20) NOT NULL,
	[Disponibilidad] [varchar](20) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[Latitud] [varchar](50) NOT NULL,
	[Longitud] [varchar](50) NULL,
 CONSTRAINT [PK_Arbol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: vi. 13 de oct. 2017 1:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Arbol] [int] NOT NULL,
	[Emisor] [int] NOT NULL,
	[Receptor] [int] NOT NULL,
	[Estado] [varchar](20) NOT NULL,
	[Visto] [varchar](10) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[VisibleEmisor] [bit] NULL,
	[VisibleReceptor] [bit] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido_Arbol]    Script Date: vi. 13 de oct. 2017 1:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido_Arbol](
	[IdPedido] [int] NOT NULL,
	[IdArbol] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: vi. 13 de oct. 2017 1:05:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Pass] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Arbol] ON 

INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (1, 1, N'ciruela', N'alta', N'Calle 81 2301-2349, Los Hornos, Argentina', N'-34.96967165876522', N'-57.952880859375')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (2, 1, N'limón', N'alta', N'Calle 151 1215, Los Hornos, Argentina', N'-34.96010561740327', N'-57.99064636230469')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (3, 1, N'naranja', N'alta', N'Calle 516 Nº 5101-5199, San Carlos, Argentina', N'-34.92464525641476', N'-58.028411865234375')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (4, 1, N'palta', N'media', N'Calle 514 Nº 2700-2798, Gonnet, Argentina', N'-34.90015177377474', N'-58.00455093383789')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (5, 1, N'kiwi', N'baja', N'Calle 28 Nº 2731, Gonnet, Argentina', N'-34.89691358271834', N'-58.0213737487793')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (6, 1, N'higo', N'media', N'Calle 129 Nº 1649-1699, Berisso, Argentina', N'-34.90606466279636', N'-57.91374206542969')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (7, 2, N'melón', N'alta', N'Calle 140 Nº 1112, Los Hornos, Argentina', N'-34.948850021291626', N'-57.98017501831055')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (8, 2, N'pera', N'media', N'Calle 4 Bis Nº 2552-2600, Villa Elvira, Argentina', N'-34.93773360346577', N'-57.91391372680664')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (9, 2, N'durazno', N'alta', N'Calle 18 Nº 1169, La Plata, Argentina', N'-34.92886753200284', N'-57.95682907104492')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (10, 3, N'granada', N'alta', N'Calle 5 652-680, La Plata, Argentina', N'-34.909584037461684', N'-57.95193672180176')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (11, 4, N'maracuyá', N'media', N'Calle 68 516, La Plata, Argentina', N'-34.926193449358685', N'-57.93039321899414')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (12, 4, N'limón', N'baja', N'Calle 23 851-885, La Plata, Argentina', N'-34.929571223476366', N'-57.9667854309082')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (13, 4, N'mango', N'baja', N'Calle 2 64, La Plata, Argentina', N'-34.89691358271834', N'-57.961978912353516')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (14, 4, N'pomelo', N'alta', N'Calle 24 1262, La Plata, Argentina', N'-34.935200537974595', N'-57.960777282714844')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (15, 2, N'ananá', N'alta', N'Calle 8 Nº 465, Berisso, Argentina', N'-34.908880174596725', N'-57.91872024536133')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (17, 5, N'banana', N'media', N'Calle 2 1524, La Plata, Argentina', N'-34.91887446173657', N'-57.932281494140625')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (18, 5, N'damasco', N'baja', N'Calle 63 701-749, La Plata, Argentina', N'-34.92548972891449', N'-57.94086456298828')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (19, 5, N'mora', N'media', N'Calle 2 787, La Plata, Argentina', N'-34.909020947652444', N'-57.94670104980469')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (20, 5, N'uva', N'alta', N'Calle 134 1802-1850, Los Hornos, Argentina', N'-34.95419662216562', N'-57.95854568481445')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (21, 5, N'frutilla', N'media', N'Calle 22 225, La Plata, Argentina', N'-34.91859294917691', N'-57.979488372802734')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (22, 2, N'ananá', N'baja', N'Calle 511 Nº 3342, Gonnet, Argentina', N'-34.90282670487579', N'-58.01433563232422')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (23, 3, N'mango', N'alta', N'Calle 8 961, La Plata, Argentina', N'-34.91656954924354', N'-57.94991970062256')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (24, 3, N'sandía', N'media', N'Calle 47 291, La Plata, Argentina', N'-34.90712049103522', N'-57.94562816619873')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (25, 3, N'banana', N'media', N'Calle 47 869, La Plata, Argentina', N'-34.918065110525006', N'-57.95764446258545')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (26, 3, N'pera', N'media', N'Calle 3 1277, La Plata, Argentina', N'-34.91620005343491', N'-57.93923377990723')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (27, 3, N'palta', N'alta', N'Calle 42 1095, La Plata, Argentina', N'-34.918170678526955', N'-57.96764373779297')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (28, 4, N'pera', N'media', N'Calle 57 1674, La Plata, Argentina', N'-34.938718663363076', N'-57.9664421081543')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (30, 4, N'palta', N'media', N'Calle 12 526, La Plata, Argentina', N'-34.91394785253977', N'-57.96163558959961')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (31, 5, N'pera', N'alta', N'Calle 36 425, La Plata, Argentina', N'-34.90071492440465', N'-57.9609489440918')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (32, 5, N'palta', N'baja', N'Calle 69 1076, La Plata, Argentina', N'-34.93773360346577', N'-57.94086456298828')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (33, 5, N'pomelo', N'media', N'Calle 530 252, Tolosa, Argentina', N'-34.890155207559104', N'-57.96112060546875')
INSERT [dbo].[Arbol] ([Id], [IdUsuario], [Variedad], [Disponibilidad], [Direccion], [Latitud], [Longitud]) VALUES (34, 5, N'mango', N'baja', N'Calle 132 439, San Carlos, Argentina', N'-34.93196372933898', N'-57.98532485961914')
SET IDENTITY_INSERT [dbo].[Arbol] OFF
SET IDENTITY_INSERT [dbo].[Pedido] ON 

INSERT [dbo].[Pedido] ([Id], [Arbol], [Emisor], [Receptor], [Estado], [Visto], [Fecha], [VisibleEmisor], [VisibleReceptor]) VALUES (1, 4, 5, 1, N'Pendiente', N'novisto', CAST(N'2017-10-03T16:00:39.440' AS DateTime), 1, 1)
INSERT [dbo].[Pedido] ([Id], [Arbol], [Emisor], [Receptor], [Estado], [Visto], [Fecha], [VisibleEmisor], [VisibleReceptor]) VALUES (2, 3, 4, 1, N'Pendiente', N'novisto', CAST(N'2017-10-03T16:30:15.033' AS DateTime), 1, 1)
INSERT [dbo].[Pedido] ([Id], [Arbol], [Emisor], [Receptor], [Estado], [Visto], [Fecha], [VisibleEmisor], [VisibleReceptor]) VALUES (3, 1, 3, 1, N'Pendiente', N'novisto', CAST(N'2017-10-03T16:31:53.223' AS DateTime), 1, 1)
INSERT [dbo].[Pedido] ([Id], [Arbol], [Emisor], [Receptor], [Estado], [Visto], [Fecha], [VisibleEmisor], [VisibleReceptor]) VALUES (4, 8, 1, 2, N'Pendiente', N'novisto', CAST(N'2017-10-04T01:24:41.060' AS DateTime), 1, 1)
INSERT [dbo].[Pedido] ([Id], [Arbol], [Emisor], [Receptor], [Estado], [Visto], [Fecha], [VisibleEmisor], [VisibleReceptor]) VALUES (5, 7, 1, 2, N'Pendiente', N'novisto', CAST(N'2017-10-04T21:16:05.917' AS DateTime), 1, 1)
INSERT [dbo].[Pedido] ([Id], [Arbol], [Emisor], [Receptor], [Estado], [Visto], [Fecha], [VisibleEmisor], [VisibleReceptor]) VALUES (6, 32, 1, 5, N'Pendiente', N'novisto', CAST(N'2017-10-04T23:35:01.180' AS DateTime), 1, 1)
INSERT [dbo].[Pedido] ([Id], [Arbol], [Emisor], [Receptor], [Estado], [Visto], [Fecha], [VisibleEmisor], [VisibleReceptor]) VALUES (8, 5, 2, 1, N'Pendiente', N'novisto', CAST(N'2017-10-05T00:13:03.820' AS DateTime), 1, 1)
INSERT [dbo].[Pedido] ([Id], [Arbol], [Emisor], [Receptor], [Estado], [Visto], [Fecha], [VisibleEmisor], [VisibleReceptor]) VALUES (9, 8, 1, 2, N'Pendiente', N'novisto', CAST(N'2017-10-07T22:14:42.287' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Pedido] OFF
INSERT [dbo].[Pedido_Arbol] ([IdPedido], [IdArbol]) VALUES (2, 6)
INSERT [dbo].[Pedido_Arbol] ([IdPedido], [IdArbol]) VALUES (3, 2)
INSERT [dbo].[Pedido_Arbol] ([IdPedido], [IdArbol]) VALUES (3, 3)
INSERT [dbo].[Pedido_Arbol] ([IdPedido], [IdArbol]) VALUES (3, 4)
INSERT [dbo].[Pedido_Arbol] ([IdPedido], [IdArbol]) VALUES (4, 1)
INSERT [dbo].[Pedido_Arbol] ([IdPedido], [IdArbol]) VALUES (4, 2)
INSERT [dbo].[Pedido_Arbol] ([IdPedido], [IdArbol]) VALUES (4, 3)
INSERT [dbo].[Pedido_Arbol] ([IdPedido], [IdArbol]) VALUES (4, 4)
INSERT [dbo].[Pedido_Arbol] ([IdPedido], [IdArbol]) VALUES (4, 5)
INSERT [dbo].[Pedido_Arbol] ([IdPedido], [IdArbol]) VALUES (4, 6)
INSERT [dbo].[Pedido_Arbol] ([IdPedido], [IdArbol]) VALUES (5, 1)
INSERT [dbo].[Pedido_Arbol] ([IdPedido], [IdArbol]) VALUES (6, 3)
INSERT [dbo].[Pedido_Arbol] ([IdPedido], [IdArbol]) VALUES (9, 3)
INSERT [dbo].[Pedido_Arbol] ([IdPedido], [IdArbol]) VALUES (8, 9)
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Nombre], [NombreUsuario], [Email], [Pass]) VALUES (1, N'Esteban', N'esteban', N'estebanromero84@outlook.com', N'DVOZUIQnznlVbNpxkYAgwejRW1M=')
INSERT [dbo].[Usuario] ([Id], [Nombre], [NombreUsuario], [Email], [Pass]) VALUES (2, N'Caro', N'caro', N'caro@mail.com', N'DVOZUIQnznlVbNpxkYAgwejRW1M=')
INSERT [dbo].[Usuario] ([Id], [Nombre], [NombreUsuario], [Email], [Pass]) VALUES (3, N'Emilio', N'emilio', N'emilio@mail.com', N'DVOZUIQnznlVbNpxkYAgwejRW1M=')
INSERT [dbo].[Usuario] ([Id], [Nombre], [NombreUsuario], [Email], [Pass]) VALUES (4, N'Noe', N'noe', N'noe@mail.com', N'DVOZUIQnznlVbNpxkYAgwejRW1M=')
INSERT [dbo].[Usuario] ([Id], [Nombre], [NombreUsuario], [Email], [Pass]) VALUES (5, N'Laura', N'laura', N'laura@mail.com', N'DVOZUIQnznlVbNpxkYAgwejRW1M=')
INSERT [dbo].[Usuario] ([Id], [Nombre], [NombreUsuario], [Email], [Pass]) VALUES (6, N'Maria', N'maria', N'maria@mail.com', N'DVOZUIQnznlVbNpxkYAgwejRW1M=')
INSERT [dbo].[Usuario] ([Id], [Nombre], [NombreUsuario], [Email], [Pass]) VALUES (7, N'Pedro', N'pedro', N'pedro@mail.com', N'DVOZUIQnznlVbNpxkYAgwejRW1M=')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
ALTER TABLE [dbo].[Arbol]  WITH CHECK ADD  CONSTRAINT [FK_Arbol_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Arbol] CHECK CONSTRAINT [FK_Arbol_Usuario]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Usuario] FOREIGN KEY([Emisor])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Usuario]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Usuario1] FOREIGN KEY([Receptor])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Usuario1]
GO
ALTER TABLE [dbo].[Pedido_Arbol]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Arbol_Arbol] FOREIGN KEY([IdArbol])
REFERENCES [dbo].[Arbol] ([Id])
GO
ALTER TABLE [dbo].[Pedido_Arbol] CHECK CONSTRAINT [FK_Pedido_Arbol_Arbol]
GO
ALTER TABLE [dbo].[Pedido_Arbol]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Arbol_Pedido] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pedido_Arbol] CHECK CONSTRAINT [FK_Pedido_Arbol_Pedido]
GO
