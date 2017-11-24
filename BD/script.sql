USE [master]
GO
/****** Object:  Database [db_pedidos]    Script Date: 24/11/2017 11:13:52 ******/
CREATE DATABASE [db_pedidos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_pedidos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\db_pedidos.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'db_pedidos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\db_pedidos_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [db_pedidos] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_pedidos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_pedidos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_pedidos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_pedidos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_pedidos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_pedidos] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_pedidos] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [db_pedidos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_pedidos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_pedidos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_pedidos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_pedidos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_pedidos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_pedidos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_pedidos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_pedidos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_pedidos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_pedidos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_pedidos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_pedidos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_pedidos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_pedidos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_pedidos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_pedidos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_pedidos] SET  MULTI_USER 
GO
ALTER DATABASE [db_pedidos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_pedidos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_pedidos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_pedidos] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [db_pedidos]
GO
/****** Object:  Table [dbo].[tam_clientes]    Script Date: 24/11/2017 11:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tam_clientes](
	[cod_empresa] [numeric](10, 0) NOT NULL,
	[cod_cliente] [numeric](10, 0) NOT NULL,
	[cod_tipo_doc] [varchar](10) NOT NULL,
	[apellido] [varchar](30) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[calle] [varchar](50) NULL,
	[numero] [numeric](5, 0) NULL,
	[depto] [varchar](2) NULL,
	[piso] [varchar](2) NULL,
	[manzana] [varchar](2) NULL,
	[lote] [varchar](2) NULL,
	[cod_localidad] [numeric](10, 0) NULL,
	[telefono] [varchar](11) NULL,
	[caracteristica] [varchar](5) NULL,
	[email] [varchar](50) NULL,
	[estado] [char](1) NOT NULL,
	[fecha_creacion] [datetime] NULL,
 CONSTRAINT [PK_tam_clientes] PRIMARY KEY CLUSTERED 
(
	[cod_empresa] ASC,
	[cod_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tam_empresas]    Script Date: 24/11/2017 11:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tam_empresas](
	[cod_empresa] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NULL,
	[razon_social] [varchar](30) NULL,
	[cuit] [varchar](10) NULL,
	[estado] [char](10) NULL CONSTRAINT [DF_tam_empresas_estado]  DEFAULT ((0)),
	[fecha_creacion] [datetime] NULL CONSTRAINT [DF_tam_empresas_fecha_creacion]  DEFAULT (getdate()),
	[fecha_baja] [nchar](10) NULL,
 CONSTRAINT [PK_tam_empresas] PRIMARY KEY CLUSTERED 
(
	[cod_empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tam_localidades]    Script Date: 24/11/2017 11:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tam_localidades](
	[cod_provincia] [numeric](10, 0) NULL,
	[cod_localidad] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_tam_localidades] PRIMARY KEY CLUSTERED 
(
	[cod_localidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tam_marcas]    Script Date: 24/11/2017 11:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tam_marcas](
	[cod_empresa] [numeric](10, 0) NOT NULL,
	[cod_marca] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_tam_marcas_1] PRIMARY KEY CLUSTERED 
(
	[cod_marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tam_pedidos]    Script Date: 24/11/2017 11:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tam_pedidos](
	[cod_empresa] [numeric](10, 0) NOT NULL,
	[cod_pedido] [numeric](10, 0) NOT NULL,
	[cod_cliente] [numeric](10, 0) NULL,
	[fecha_creacion] [datetime] NULL,
	[estado] [char](1) NULL,
	[fecha_finalizado] [datetime] NULL,
	[id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tam_pedidos_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tam_productos]    Script Date: 24/11/2017 11:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tam_productos](
	[cod_empresa] [numeric](10, 0) NOT NULL,
	[cod_producto] [numeric](10, 0) NOT NULL,
	[nombre] [varchar](30) NULL,
	[descripcion] [varchar](200) NULL,
	[precio_costo] [decimal](15, 2) NULL,
	[precio_venta] [decimal](15, 2) NULL,
	[precio_recarga] [decimal](15, 2) NULL,
	[margen] [numeric](4, 2) NULL,
	[estado] [char](1) NULL CONSTRAINT [DF_tam_productos_estado]  DEFAULT ((0)),
	[cod_marca] [numeric](10, 0) NULL,
	[cod_rubro] [numeric](10, 0) NULL,
	[cod_subrubro] [numeric](10, 0) NULL,
	[cod_color] [nchar](10) NULL,
	[capacidad_nominal] [numeric](10, 2) NULL,
	[id_agente] [numeric](10, 0) NULL,
	[id_tipo_fuego] [numeric](10, 0) NULL,
	[fecha_creacion] [datetime] NULL CONSTRAINT [DF_tam_productos_fecha_creacion]  DEFAULT (getdate()),
	[id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tam_productos_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tam_provincias]    Script Date: 24/11/2017 11:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tam_provincias](
	[cod_provincia] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[descripcion] [nchar](30) NULL,
 CONSTRAINT [PK_tam_provincias] PRIMARY KEY CLUSTERED 
(
	[cod_provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tam_subrubros]    Script Date: 24/11/2017 11:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tam_subrubros](
	[cod_empresa] [numeric](10, 0) NOT NULL,
	[cod_rubro] [numeric](10, 0) NOT NULL,
	[cod_subrubro] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](30) NULL,
 CONSTRAINT [PK_tam_subrubros_1] PRIMARY KEY CLUSTERED 
(
	[cod_subrubro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tam_sucursales]    Script Date: 24/11/2017 11:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tam_sucursales](
	[cod_empresa] [numeric](10, 0) NOT NULL,
	[cod_sucursal] [numeric](10, 0) NOT NULL,
	[nombre] [varchar](30) NULL,
	[calle] [varchar](30) NULL,
	[numero] [numeric](5, 0) NULL,
	[depto] [varchar](2) NULL,
	[piso] [varchar](2) NULL,
	[cod_localidad] [numeric](10, 0) NULL,
	[telefono] [varchar](11) NULL,
	[caracteristica] [varchar](5) NULL,
	[mail] [varchar](50) NULL,
	[fecha_creacion] [datetime] NULL CONSTRAINT [DF_tam_sucursales_fecha_creacion]  DEFAULT (getdate()),
	[estado] [char](1) NULL CONSTRAINT [DF_tam_sucursales_estado]  DEFAULT ((0)),
	[id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tam_sucursales_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tamp_rubros]    Script Date: 24/11/2017 11:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tamp_rubros](
	[cod_empresa] [numeric](10, 0) NOT NULL,
	[cod_rubro] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](30) NULL,
 CONSTRAINT [PK_tamp_rubros_1] PRIMARY KEY CLUSTERED 
(
	[cod_rubro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tap_empresas]    Script Date: 24/11/2017 11:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tap_empresas](
	[cod_empresa] [numeric](10, 0) NOT NULL,
	[cod_parametro] [varchar](10) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[valor] [varchar](100) NULL,
	[id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tap_empresas_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tap_parametros]    Script Date: 24/11/2017 11:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tap_parametros](
	[cod_parametro] [nchar](10) NOT NULL,
	[descripcion] [nchar](10) NULL,
	[valor] [nchar](10) NULL,
 CONSTRAINT [PK_tap_parametros] PRIMARY KEY CLUSTERED 
(
	[cod_parametro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tap_productos_imagen]    Script Date: 24/11/2017 11:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tap_productos_imagen](
	[cod_imagen] [int] NOT NULL,
	[nombre_archivo] [varchar](100) NULL,
	[principal] [char](1) NULL,
	[fecha_creacion] [datetime] NULL,
	[id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[id_producto] [numeric](10, 0) NULL,
 CONSTRAINT [PK_tap_productos_imagen_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tap_tablas]    Script Date: 24/11/2017 11:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tap_tablas](
	[cod_tabla] [numeric](10, 0) NOT NULL,
	[codigo] [nchar](10) NOT NULL,
	[valor] [varchar](100) NULL,
	[id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tap_tablas_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tap_tipo_tablas]    Script Date: 24/11/2017 11:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tap_tipo_tablas](
	[cod_tabla] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](30) NULL,
 CONSTRAINT [PK_tap_tipo_tablas] PRIMARY KEY CLUSTERED 
(
	[cod_tabla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tar_pedidos_detall]    Script Date: 24/11/2017 11:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tar_pedidos_detall](
	[id_pedido] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[cod_producto] [numeric](10, 0) NOT NULL,
	[tipo] [char](1) NULL,
	[cantidad] [numeric](5, 0) NULL,
	[precio] [decimal](15, 2) NULL,
	[total] [decimal](15, 2) NULL,
	[estado] [char](1) NULL,
	[fecha_creacion] [datetime] NULL,
	[fecha_estado] [datetime] NULL,
	[id] [numeric](10, 0) NOT NULL,
	[id_producto] [numeric](10, 0) NULL,
 CONSTRAINT [PK_tar_pedidos_detall_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Index [IX_tam_pedidos]    Script Date: 24/11/2017 11:13:52 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_tam_pedidos] ON [dbo].[tam_pedidos]
(
	[cod_empresa] ASC,
	[cod_pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tam_productos]    Script Date: 24/11/2017 11:13:52 ******/
CREATE NONCLUSTERED INDEX [IX_tam_productos] ON [dbo].[tam_productos]
(
	[cod_empresa] ASC,
	[cod_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tam_subrubros]    Script Date: 24/11/2017 11:13:52 ******/
CREATE NONCLUSTERED INDEX [IX_tam_subrubros] ON [dbo].[tam_subrubros]
(
	[cod_empresa] ASC,
	[cod_rubro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tam_sucursales]    Script Date: 24/11/2017 11:13:52 ******/
CREATE NONCLUSTERED INDEX [IX_tam_sucursales] ON [dbo].[tam_sucursales]
(
	[cod_empresa] ASC,
	[cod_sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tamp_rubros]    Script Date: 24/11/2017 11:13:52 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_tamp_rubros] ON [dbo].[tamp_rubros]
(
	[cod_empresa] ASC,
	[cod_rubro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_tap_empresas]    Script Date: 24/11/2017 11:13:52 ******/
CREATE NONCLUSTERED INDEX [IX_tap_empresas] ON [dbo].[tap_empresas]
(
	[cod_empresa] ASC,
	[cod_parametro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tap_productos_imagen]    Script Date: 24/11/2017 11:13:52 ******/
CREATE NONCLUSTERED INDEX [IX_tap_productos_imagen] ON [dbo].[tap_productos_imagen]
(
	[id_producto] ASC,
	[cod_imagen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tar_pedidos_detall]    Script Date: 24/11/2017 11:13:52 ******/
CREATE NONCLUSTERED INDEX [IX_tar_pedidos_detall] ON [dbo].[tar_pedidos_detall]
(
	[id_pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tar_pedidos_detall_1]    Script Date: 24/11/2017 11:13:52 ******/
CREATE NONCLUSTERED INDEX [IX_tar_pedidos_detall_1] ON [dbo].[tar_pedidos_detall]
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tar_pedidos_detall_2]    Script Date: 24/11/2017 11:13:52 ******/
CREATE NONCLUSTERED INDEX [IX_tar_pedidos_detall_2] ON [dbo].[tar_pedidos_detall]
(
	[id_pedido] ASC,
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tam_clientes] ADD  CONSTRAINT [DF_tam_clientes_estado]  DEFAULT ((0)) FOR [estado]
GO
ALTER TABLE [dbo].[tam_clientes] ADD  CONSTRAINT [DF_tam_clientes_fecha_creacion]  DEFAULT (getdate()) FOR [fecha_creacion]
GO
ALTER TABLE [dbo].[tam_pedidos] ADD  CONSTRAINT [DF_tam_pedidos_fecha_creacion]  DEFAULT (getdate()) FOR [fecha_creacion]
GO
ALTER TABLE [dbo].[tam_pedidos] ADD  CONSTRAINT [DF_tam_pedidos_estado]  DEFAULT ((0)) FOR [estado]
GO
ALTER TABLE [dbo].[tap_productos_imagen] ADD  CONSTRAINT [DF_tap_productos_imagen_fecha_creacion]  DEFAULT (getdate()) FOR [fecha_creacion]
GO
ALTER TABLE [dbo].[tar_pedidos_detall] ADD  CONSTRAINT [DF_tar_pedidos_detall_fecha_creacion]  DEFAULT (getdate()) FOR [fecha_creacion]
GO
ALTER TABLE [dbo].[tam_clientes]  WITH CHECK ADD  CONSTRAINT [FK_tam_clientes_tam_empresas] FOREIGN KEY([cod_empresa])
REFERENCES [dbo].[tam_empresas] ([cod_empresa])
GO
ALTER TABLE [dbo].[tam_clientes] CHECK CONSTRAINT [FK_tam_clientes_tam_empresas]
GO
ALTER TABLE [dbo].[tam_clientes]  WITH CHECK ADD  CONSTRAINT [FK_tam_clientes_tam_localidades] FOREIGN KEY([cod_localidad])
REFERENCES [dbo].[tam_localidades] ([cod_localidad])
GO
ALTER TABLE [dbo].[tam_clientes] CHECK CONSTRAINT [FK_tam_clientes_tam_localidades]
GO
ALTER TABLE [dbo].[tam_localidades]  WITH CHECK ADD  CONSTRAINT [FK_tam_localidades_tam_provincias] FOREIGN KEY([cod_provincia])
REFERENCES [dbo].[tam_provincias] ([cod_provincia])
GO
ALTER TABLE [dbo].[tam_localidades] CHECK CONSTRAINT [FK_tam_localidades_tam_provincias]
GO
ALTER TABLE [dbo].[tam_pedidos]  WITH CHECK ADD  CONSTRAINT [FK_tam_pedidos_tam_clientes] FOREIGN KEY([cod_empresa], [cod_cliente])
REFERENCES [dbo].[tam_clientes] ([cod_empresa], [cod_cliente])
GO
ALTER TABLE [dbo].[tam_pedidos] CHECK CONSTRAINT [FK_tam_pedidos_tam_clientes]
GO
ALTER TABLE [dbo].[tam_pedidos]  WITH CHECK ADD  CONSTRAINT [FK_tam_pedidos_tam_empresas] FOREIGN KEY([cod_empresa])
REFERENCES [dbo].[tam_empresas] ([cod_empresa])
GO
ALTER TABLE [dbo].[tam_pedidos] CHECK CONSTRAINT [FK_tam_pedidos_tam_empresas]
GO
ALTER TABLE [dbo].[tam_pedidos]  WITH CHECK ADD  CONSTRAINT [FK_tam_pedidos_tam_empresas1] FOREIGN KEY([cod_empresa])
REFERENCES [dbo].[tam_empresas] ([cod_empresa])
GO
ALTER TABLE [dbo].[tam_pedidos] CHECK CONSTRAINT [FK_tam_pedidos_tam_empresas1]
GO
ALTER TABLE [dbo].[tam_productos]  WITH CHECK ADD  CONSTRAINT [FK_tam_productos_tam_empresas] FOREIGN KEY([cod_empresa])
REFERENCES [dbo].[tam_empresas] ([cod_empresa])
GO
ALTER TABLE [dbo].[tam_productos] CHECK CONSTRAINT [FK_tam_productos_tam_empresas]
GO
ALTER TABLE [dbo].[tam_productos]  WITH CHECK ADD  CONSTRAINT [FK_tam_productos_tam_marcas1] FOREIGN KEY([cod_marca])
REFERENCES [dbo].[tam_marcas] ([cod_marca])
GO
ALTER TABLE [dbo].[tam_productos] CHECK CONSTRAINT [FK_tam_productos_tam_marcas1]
GO
ALTER TABLE [dbo].[tam_productos]  WITH CHECK ADD  CONSTRAINT [FK_tam_productos_tam_subrubros1] FOREIGN KEY([cod_subrubro])
REFERENCES [dbo].[tam_subrubros] ([cod_subrubro])
GO
ALTER TABLE [dbo].[tam_productos] CHECK CONSTRAINT [FK_tam_productos_tam_subrubros1]
GO
ALTER TABLE [dbo].[tam_productos]  WITH CHECK ADD  CONSTRAINT [FK_tam_productos_tamp_rubros1] FOREIGN KEY([cod_rubro])
REFERENCES [dbo].[tamp_rubros] ([cod_rubro])
GO
ALTER TABLE [dbo].[tam_productos] CHECK CONSTRAINT [FK_tam_productos_tamp_rubros1]
GO
ALTER TABLE [dbo].[tam_productos]  WITH CHECK ADD  CONSTRAINT [FK_tam_productos_tap_tablas] FOREIGN KEY([id_agente])
REFERENCES [dbo].[tap_tablas] ([id])
GO
ALTER TABLE [dbo].[tam_productos] CHECK CONSTRAINT [FK_tam_productos_tap_tablas]
GO
ALTER TABLE [dbo].[tam_productos]  WITH CHECK ADD  CONSTRAINT [FK_tam_productos_tap_tablas1] FOREIGN KEY([id_tipo_fuego])
REFERENCES [dbo].[tap_tablas] ([id])
GO
ALTER TABLE [dbo].[tam_productos] CHECK CONSTRAINT [FK_tam_productos_tap_tablas1]
GO
ALTER TABLE [dbo].[tam_subrubros]  WITH CHECK ADD  CONSTRAINT [FK_tam_subrubros_tamp_rubros1] FOREIGN KEY([cod_rubro])
REFERENCES [dbo].[tamp_rubros] ([cod_rubro])
GO
ALTER TABLE [dbo].[tam_subrubros] CHECK CONSTRAINT [FK_tam_subrubros_tamp_rubros1]
GO
ALTER TABLE [dbo].[tam_sucursales]  WITH CHECK ADD  CONSTRAINT [FK_tam_sucursales_tam_empresas] FOREIGN KEY([cod_empresa])
REFERENCES [dbo].[tam_empresas] ([cod_empresa])
GO
ALTER TABLE [dbo].[tam_sucursales] CHECK CONSTRAINT [FK_tam_sucursales_tam_empresas]
GO
ALTER TABLE [dbo].[tam_sucursales]  WITH CHECK ADD  CONSTRAINT [FK_tam_sucursales_tam_empresas1] FOREIGN KEY([cod_empresa])
REFERENCES [dbo].[tam_empresas] ([cod_empresa])
GO
ALTER TABLE [dbo].[tam_sucursales] CHECK CONSTRAINT [FK_tam_sucursales_tam_empresas1]
GO
ALTER TABLE [dbo].[tam_sucursales]  WITH CHECK ADD  CONSTRAINT [FK_tam_sucursales_tam_localidades] FOREIGN KEY([cod_localidad])
REFERENCES [dbo].[tam_localidades] ([cod_localidad])
GO
ALTER TABLE [dbo].[tam_sucursales] CHECK CONSTRAINT [FK_tam_sucursales_tam_localidades]
GO
ALTER TABLE [dbo].[tamp_rubros]  WITH CHECK ADD  CONSTRAINT [FK_tamp_rubros_tam_empresas] FOREIGN KEY([cod_empresa])
REFERENCES [dbo].[tam_empresas] ([cod_empresa])
GO
ALTER TABLE [dbo].[tamp_rubros] CHECK CONSTRAINT [FK_tamp_rubros_tam_empresas]
GO
ALTER TABLE [dbo].[tap_empresas]  WITH CHECK ADD  CONSTRAINT [FK_tap_empresas_tam_empresas] FOREIGN KEY([cod_empresa])
REFERENCES [dbo].[tam_empresas] ([cod_empresa])
GO
ALTER TABLE [dbo].[tap_empresas] CHECK CONSTRAINT [FK_tap_empresas_tam_empresas]
GO
ALTER TABLE [dbo].[tap_productos_imagen]  WITH CHECK ADD  CONSTRAINT [FK_tap_productos_imagen_tam_productos1] FOREIGN KEY([id_producto])
REFERENCES [dbo].[tam_productos] ([id])
GO
ALTER TABLE [dbo].[tap_productos_imagen] CHECK CONSTRAINT [FK_tap_productos_imagen_tam_productos1]
GO
ALTER TABLE [dbo].[tap_tablas]  WITH CHECK ADD  CONSTRAINT [FK_tap_tablas_tap_tipo_tablas] FOREIGN KEY([cod_tabla])
REFERENCES [dbo].[tap_tipo_tablas] ([cod_tabla])
GO
ALTER TABLE [dbo].[tap_tablas] CHECK CONSTRAINT [FK_tap_tablas_tap_tipo_tablas]
GO
ALTER TABLE [dbo].[tar_pedidos_detall]  WITH CHECK ADD  CONSTRAINT [FK_tar_pedidos_detall_tam_pedidos1] FOREIGN KEY([id_pedido])
REFERENCES [dbo].[tam_pedidos] ([id])
GO
ALTER TABLE [dbo].[tar_pedidos_detall] CHECK CONSTRAINT [FK_tar_pedidos_detall_tam_pedidos1]
GO
ALTER TABLE [dbo].[tar_pedidos_detall]  WITH CHECK ADD  CONSTRAINT [FK_tar_pedidos_detall_tam_productos1] FOREIGN KEY([id_producto])
REFERENCES [dbo].[tam_productos] ([id])
GO
ALTER TABLE [dbo].[tar_pedidos_detall] CHECK CONSTRAINT [FK_tar_pedidos_detall_tam_productos1]
GO
USE [master]
GO
ALTER DATABASE [db_pedidos] SET  READ_WRITE 
GO
