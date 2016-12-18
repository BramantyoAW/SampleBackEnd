USE [master]
GO
/****** Object:  Database [StockDb]    Script Date: 08/11/2016 09.26.39 ******/
CREATE DATABASE [StockDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StockDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\StockDb.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StockDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\StockDb_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StockDb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StockDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StockDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StockDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StockDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StockDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StockDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [StockDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StockDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [StockDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StockDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StockDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StockDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StockDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StockDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StockDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StockDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StockDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StockDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StockDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StockDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StockDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StockDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StockDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StockDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StockDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StockDb] SET  MULTI_USER 
GO
ALTER DATABASE [StockDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StockDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StockDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StockDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [StockDb]
GO
/****** Object:  Table [dbo].[Barang]    Script Date: 08/11/2016 09.26.40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Barang](
	[KodeBarang] [varchar](50) NOT NULL,
	[IdJenisMotor] [int] NOT NULL,
	[KategoriId] [int] NOT NULL,
	[Nama] [varchar](100) NOT NULL,
	[Stok] [int] NOT NULL,
	[HargaBeli] [money] NOT NULL,
	[HargaJual] [money] NOT NULL,
	[TanggalBeli] [date] NOT NULL,
 CONSTRAINT [PK_Barang] PRIMARY KEY CLUSTERED 
(
	[KodeBarang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[JenisMotor]    Script Date: 08/11/2016 09.26.41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[JenisMotor](
	[IdJenisMotor] [int] IDENTITY(1,1) NOT NULL,
	[NamaJenisMotor] [varchar](100) NOT NULL,
	[NamaMerk] [varchar](50) NOT NULL,
 CONSTRAINT [PK_JenisMotor] PRIMARY KEY CLUSTERED 
(
	[IdJenisMotor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Kategori]    Script Date: 08/11/2016 09.26.41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategori](
	[KategoriId] [int] IDENTITY(1,1) NOT NULL,
	[NamaKategori] [nchar](10) NULL,
 CONSTRAINT [PK_Kategori] PRIMARY KEY CLUSTERED 
(
	[KategoriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[JenisMotor] ON 

INSERT [dbo].[JenisMotor] ([IdJenisMotor], [NamaJenisMotor], [NamaMerk]) VALUES (1, N'Kawazaki', N'Ninja 600cc')
INSERT [dbo].[JenisMotor] ([IdJenisMotor], [NamaJenisMotor], [NamaMerk]) VALUES (2, N'Yamaha', N'R1 1000cc')
INSERT [dbo].[JenisMotor] ([IdJenisMotor], [NamaJenisMotor], [NamaMerk]) VALUES (3, N'Yamaha', N'Vega Force')
SET IDENTITY_INSERT [dbo].[JenisMotor] OFF
ALTER TABLE [dbo].[Barang] ADD  CONSTRAINT [DF_Barang_Stok]  DEFAULT ((0)) FOR [Stok]
GO
ALTER TABLE [dbo].[Barang] ADD  CONSTRAINT [DF_Barang_HargaBeli]  DEFAULT ((0)) FOR [HargaBeli]
GO
ALTER TABLE [dbo].[Barang] ADD  CONSTRAINT [DF_Barang_HargaJual]  DEFAULT ((0)) FOR [HargaJual]
GO
ALTER TABLE [dbo].[Barang] ADD  CONSTRAINT [DF_Barang_TanggalBeli]  DEFAULT (getdate()) FOR [TanggalBeli]
GO
ALTER TABLE [dbo].[Barang]  WITH CHECK ADD  CONSTRAINT [FK_Barang_JenisMotor] FOREIGN KEY([IdJenisMotor])
REFERENCES [dbo].[JenisMotor] ([IdJenisMotor])
GO
ALTER TABLE [dbo].[Barang] CHECK CONSTRAINT [FK_Barang_JenisMotor]
GO
ALTER TABLE [dbo].[Barang]  WITH CHECK ADD  CONSTRAINT [FK_Barang_Kategori1] FOREIGN KEY([KategoriId])
REFERENCES [dbo].[Kategori] ([KategoriId])
GO
ALTER TABLE [dbo].[Barang] CHECK CONSTRAINT [FK_Barang_Kategori1]
GO
USE [master]
GO
ALTER DATABASE [StockDb] SET  READ_WRITE 
GO
