/****** Object:  Database [DB_Ecommerse]    Script Date: 05/02/2021 12:03:12 ******/
CREATE DATABASE [DB_Ecommerse]  (EDITION = 'Basic', SERVICE_OBJECTIVE = 'Basic', MAXSIZE = 2 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS;
GO
ALTER DATABASE [DB_Ecommerse] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [DB_Ecommerse] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Ecommerse] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Ecommerse] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Ecommerse] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Ecommerse] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Ecommerse] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Ecommerse] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Ecommerse] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Ecommerse] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Ecommerse] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Ecommerse] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Ecommerse] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Ecommerse] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Ecommerse] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [DB_Ecommerse] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Ecommerse] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DB_Ecommerse] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Ecommerse] SET ENCRYPTION ON
GO
ALTER DATABASE [DB_Ecommerse] SET QUERY_STORE = ON
GO
ALTER DATABASE [DB_Ecommerse] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 7), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 10, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[Carrito]    Script Date: 05/02/2021 12:03:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrito](
	[id_Carrito] [int] NOT NULL,
	[id_Usuario] [int] NULL,
	[id_Articulo] [int] NULL,
	[cantidad] [int] NULL,
 CONSTRAINT [PK_Carrito] PRIMARY KEY CLUSTERED 
(
	[id_Carrito] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 05/02/2021 12:03:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[id_Categoria] [int] NOT NULL,
	[descripcion_Categoria] [varchar](50) NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[id_Categoria] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 05/02/2021 12:03:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[id_Producto] [int] NOT NULL,
	[id_Categoria] [int] NULL,
	[descripcion_Producto] [varchar](50) NULL,
	[precio_Producto] [numeric](18, 2) NULL,
	[cantidad] [int] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[id_Producto] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 05/02/2021 12:03:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[id_Review] [int] NOT NULL,
	[id_Producto] [int] NULL,
	[fecha_Review] [date] NULL,
	[id_Usuario] [int] NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[id_Review] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 05/02/2021 12:03:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id_Usuaro] [int] NOT NULL,
	[nombre_Usuario] [varchar](50) NULL,
	[contrasena_Usuario] [varchar](50) NULL,
	[correo_Usuario] [varchar](50) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_Usuaro] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Categoria] ([id_Categoria], [descripcion_Categoria]) VALUES (1, N'Electronico')
INSERT [dbo].[Categoria] ([id_Categoria], [descripcion_Categoria]) VALUES (2, N'Ropa')
INSERT [dbo].[Categoria] ([id_Categoria], [descripcion_Categoria]) VALUES (3, N'Automoviles')
INSERT [dbo].[Categoria] ([id_Categoria], [descripcion_Categoria]) VALUES (4, N'Oficina')
INSERT [dbo].[Categoria] ([id_Categoria], [descripcion_Categoria]) VALUES (5, N'Abarrotes')
INSERT [dbo].[Categoria] ([id_Categoria], [descripcion_Categoria]) VALUES (6, N'Equipo Especial')
GO
INSERT [dbo].[Producto] ([id_Producto], [id_Categoria], [descripcion_Producto], [precio_Producto], [cantidad]) VALUES (1, 1, N'Camisa', CAST(20000.00 AS Numeric(18, 2)), 10)
INSERT [dbo].[Producto] ([id_Producto], [id_Categoria], [descripcion_Producto], [precio_Producto], [cantidad]) VALUES (2, 1, N'Pantalon', CAST(22000.00 AS Numeric(18, 2)), 7)
INSERT [dbo].[Producto] ([id_Producto], [id_Categoria], [descripcion_Producto], [precio_Producto], [cantidad]) VALUES (3, 2, N'nuevoProducto', CAST(10000.00 AS Numeric(18, 2)), 2)
INSERT [dbo].[Producto] ([id_Producto], [id_Categoria], [descripcion_Producto], [precio_Producto], [cantidad]) VALUES (6, 1, N'Tennis', CAST(5000.00 AS Numeric(18, 2)), 10)
GO
INSERT [dbo].[Review] ([id_Review], [id_Producto], [fecha_Review], [id_Usuario]) VALUES (1, 1, CAST(N'2021-02-02' AS Date), 0)
INSERT [dbo].[Review] ([id_Review], [id_Producto], [fecha_Review], [id_Usuario]) VALUES (3, 2, CAST(N'2021-02-05' AS Date), 1)
GO
INSERT [dbo].[Usuario] ([id_Usuaro], [nombre_Usuario], [contrasena_Usuario], [correo_Usuario]) VALUES (1, N'Pablo', N'1234', N'pablo@correo.com')
INSERT [dbo].[Usuario] ([id_Usuaro], [nombre_Usuario], [contrasena_Usuario], [correo_Usuario]) VALUES (2, N'Jose Pablo Hernandez Fallas', N'1234', N'jhernandezf@bncr.fi.cr')
GO
ALTER DATABASE [DB_Ecommerse] SET  READ_WRITE 
GO
