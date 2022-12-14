USE [master]
GO
/****** Object:  Database [CRAutos]    Script Date: 12/7/2022 10:51:41 PM ******/
CREATE DATABASE [CRAutos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CRAutos', FILENAME = N'/var/opt/mssql/data/CRAutos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CRAutos_log', FILENAME = N'/var/opt/mssql/data/CRAutos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CRAutos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CRAutos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CRAutos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CRAutos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CRAutos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CRAutos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CRAutos] SET ARITHABORT OFF 
GO
ALTER DATABASE [CRAutos] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CRAutos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CRAutos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CRAutos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CRAutos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CRAutos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CRAutos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CRAutos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CRAutos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CRAutos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CRAutos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CRAutos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CRAutos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CRAutos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CRAutos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CRAutos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CRAutos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CRAutos] SET RECOVERY FULL 
GO
ALTER DATABASE [CRAutos] SET  MULTI_USER 
GO
ALTER DATABASE [CRAutos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CRAutos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CRAutos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CRAutos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CRAutos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CRAutos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CRAutos] SET QUERY_STORE = OFF
GO
USE [CRAutos]
GO
/****** Object:  Table [dbo].[AutoMovil]    Script Date: 12/7/2022 10:51:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutoMovil](
	[idAutoMovil] [int] IDENTITY(1,1) NOT NULL,
	[Año] [int] NULL,
	[Modelo] [varchar](30) NULL,
	[Cilindrada] [int] NULL,
	[Precio] [float] NULL,
	[Transmision] [varchar](30) NULL,
	[Combustible] [varchar](15) NULL,
	[Kilometraje] [int] NULL,
	[idColor] [int] NULL,
	[idEstilo] [int] NULL,
	[idMarca] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idAutoMovil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 12/7/2022 10:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[idColor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[idColor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estilo]    Script Date: 12/7/2022 10:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estilo](
	[idEstilo] [int] IDENTITY(1,1) NOT NULL,
	[NombreEstilo] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[idEstilo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 12/7/2022 10:51:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[idMarca] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[idMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AutoMovil] ON 

INSERT [dbo].[AutoMovil] ([idAutoMovil], [Año], [Modelo], [Cilindrada], [Precio], [Transmision], [Combustible], [Kilometraje], [idColor], [idEstilo], [idMarca]) VALUES (3, 2023, N'RAV4', 2500, 78, N'Manual', N'1', 28, 2, 1, 1)
INSERT [dbo].[AutoMovil] ([idAutoMovil], [Año], [Modelo], [Cilindrada], [Precio], [Transmision], [Combustible], [Kilometraje], [idColor], [idEstilo], [idMarca]) VALUES (5, 2015, N'6789', 678, 78, N'Automatico', N'78', 100, 4, 2, 4)
INSERT [dbo].[AutoMovil] ([idAutoMovil], [Año], [Modelo], [Cilindrada], [Precio], [Transmision], [Combustible], [Kilometraje], [idColor], [idEstilo], [idMarca]) VALUES (6, 2022, N'Yaris', 1000, 23, N'Manual', N'Diesel', 55, 1, 1, 2)
SET IDENTITY_INSERT [dbo].[AutoMovil] OFF
GO
SET IDENTITY_INSERT [dbo].[Color] ON 

INSERT [dbo].[Color] ([idColor], [Nombre]) VALUES (1, N'Blanco')
INSERT [dbo].[Color] ([idColor], [Nombre]) VALUES (2, N'Rojo')
INSERT [dbo].[Color] ([idColor], [Nombre]) VALUES (3, N'Azul')
INSERT [dbo].[Color] ([idColor], [Nombre]) VALUES (4, N'Negro')
INSERT [dbo].[Color] ([idColor], [Nombre]) VALUES (5, N'Naranja')
INSERT [dbo].[Color] ([idColor], [Nombre]) VALUES (6, N'Amarillo')
INSERT [dbo].[Color] ([idColor], [Nombre]) VALUES (7, N'Verde')
INSERT [dbo].[Color] ([idColor], [Nombre]) VALUES (8, N'Café')
INSERT [dbo].[Color] ([idColor], [Nombre]) VALUES (9, N'Violeta')
SET IDENTITY_INSERT [dbo].[Color] OFF
GO
SET IDENTITY_INSERT [dbo].[Estilo] ON 

INSERT [dbo].[Estilo] ([idEstilo], [NombreEstilo]) VALUES (1, N'Urbano')
INSERT [dbo].[Estilo] ([idEstilo], [NombreEstilo]) VALUES (2, N'subcompacto')
INSERT [dbo].[Estilo] ([idEstilo], [NombreEstilo]) VALUES (3, N'Hatchback')
INSERT [dbo].[Estilo] ([idEstilo], [NombreEstilo]) VALUES (4, N'Familiar')
INSERT [dbo].[Estilo] ([idEstilo], [NombreEstilo]) VALUES (5, N'Sedán')
INSERT [dbo].[Estilo] ([idEstilo], [NombreEstilo]) VALUES (6, N'Berlina')
INSERT [dbo].[Estilo] ([idEstilo], [NombreEstilo]) VALUES (7, N'Descapotable')
INSERT [dbo].[Estilo] ([idEstilo], [NombreEstilo]) VALUES (8, N'Coupé')
INSERT [dbo].[Estilo] ([idEstilo], [NombreEstilo]) VALUES (9, N'Muscle car')
INSERT [dbo].[Estilo] ([idEstilo], [NombreEstilo]) VALUES (10, N'Deportivos')
INSERT [dbo].[Estilo] ([idEstilo], [NombreEstilo]) VALUES (11, N'Monovolumen')
INSERT [dbo].[Estilo] ([idEstilo], [NombreEstilo]) VALUES (12, N'Todoterreno')
INSERT [dbo].[Estilo] ([idEstilo], [NombreEstilo]) VALUES (13, N'SUV')
INSERT [dbo].[Estilo] ([idEstilo], [NombreEstilo]) VALUES (14, N'Comercial')
INSERT [dbo].[Estilo] ([idEstilo], [NombreEstilo]) VALUES (15, N'Autocaravana')
INSERT [dbo].[Estilo] ([idEstilo], [NombreEstilo]) VALUES (16, N'PickUp')
INSERT [dbo].[Estilo] ([idEstilo], [NombreEstilo]) VALUES (17, N'Clásico')
SET IDENTITY_INSERT [dbo].[Estilo] OFF
GO
SET IDENTITY_INSERT [dbo].[Marca] ON 

INSERT [dbo].[Marca] ([idMarca], [Nombre]) VALUES (1, N'Nissan')
INSERT [dbo].[Marca] ([idMarca], [Nombre]) VALUES (2, N'Toyota')
INSERT [dbo].[Marca] ([idMarca], [Nombre]) VALUES (3, N'Hyundai')
INSERT [dbo].[Marca] ([idMarca], [Nombre]) VALUES (4, N'Ford')
INSERT [dbo].[Marca] ([idMarca], [Nombre]) VALUES (5, N'BMW')
INSERT [dbo].[Marca] ([idMarca], [Nombre]) VALUES (6, N'Audi')
INSERT [dbo].[Marca] ([idMarca], [Nombre]) VALUES (7, N'Mercedez Benz')
INSERT [dbo].[Marca] ([idMarca], [Nombre]) VALUES (8, N'Mitsubishi')
INSERT [dbo].[Marca] ([idMarca], [Nombre]) VALUES (9, N'Dodge')
INSERT [dbo].[Marca] ([idMarca], [Nombre]) VALUES (10, N'Jeep')
INSERT [dbo].[Marca] ([idMarca], [Nombre]) VALUES (11, N'Kia')
SET IDENTITY_INSERT [dbo].[Marca] OFF
GO
ALTER TABLE [dbo].[AutoMovil]  WITH CHECK ADD FOREIGN KEY([idColor])
REFERENCES [dbo].[Color] ([idColor])
GO
ALTER TABLE [dbo].[AutoMovil]  WITH CHECK ADD FOREIGN KEY([idEstilo])
REFERENCES [dbo].[Estilo] ([idEstilo])
GO
ALTER TABLE [dbo].[AutoMovil]  WITH CHECK ADD FOREIGN KEY([idMarca])
REFERENCES [dbo].[Marca] ([idMarca])
GO
/****** Object:  StoredProcedure [dbo].[AgregarAutomovil]    Script Date: 12/7/2022 10:51:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Steven Gazo
-- Create date: 07-12-2022
-- Description:	Trabajo de Equipo
-- =============================================
CREATE PROCEDURE [dbo].[AgregarAutomovil]
	@idMarca int ,
	@idEstilo int,
	@idColor int,
	@Modelo varchar(30) ,
	@Año int ,
	@Cilindrada int ,
	@Precio float ,
	@Transmision varchar(30) ,
	@Combustible varchar(15) ,
	@Kilometraje int,
	@ErrorMessage varchar(max) output,
	@ErrorCode int output,
	@idAutoMovil int output
AS
BEGIN
BEGIN TRY
	set @ErrorMessage = '';
	set @ErrorCode = 0;

	insert into AutoMovil(idMarca,idEstilo,idColor,Modelo,Año,Cilindrada,Precio,Transmision, Combustible,Kilometraje)
				values( @idMarca,@idEstilo,@idColor,@Modelo,@Año,@Cilindrada,@Precio,@Transmision,@Combustible,@Kilometraje)
	set @idAutoMovil = SCOPE_IDENTITY()
END TRY
BEGIN CATCH
	set @ErrorMessage = ERROR_MESSAGE();
	set @ErrorCode = @@ERROR;
	set @idAutoMovil = 0;
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarAuto]    Script Date: 12/7/2022 10:51:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Steven Gazo
-- Create date: 07-12-2022
-- Description:	Borra un auto
-- =============================================
CREATE PROCEDURE [dbo].[EliminarAuto]
		@idAutoMovil int =0,
		@ErrorMessage varchar(max) output,
		@ErrorCode int output
AS
BEGIN
BEGIN TRY
	DELETE FROM AutoMovil
	WHERE AutoMovil.idAutoMovil = @idAutoMovil
	SET @ErrorCode = 0;
	SET @ErrorMessage= '';
END TRY
BEGIN CATCH
	SET @ErrorCode = @@ERROR;
	SET @ErrorMessage = ERROR_MESSAGE()
END CATCH
END
GO
USE [master]
GO
ALTER DATABASE [CRAutos] SET  READ_WRITE 
GO
