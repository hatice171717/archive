USE [master]
GO
/****** Object:  Database [ArsivOdasi]    Script Date: 13.11.2022 22:53:30 ******/
CREATE DATABASE [ArsivOdasi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ArsivOdasi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ArsivOdasi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ArsivOdasi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ArsivOdasi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ArsivOdasi] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ArsivOdasi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ArsivOdasi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ArsivOdasi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ArsivOdasi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ArsivOdasi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ArsivOdasi] SET ARITHABORT OFF 
GO
ALTER DATABASE [ArsivOdasi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ArsivOdasi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ArsivOdasi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ArsivOdasi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ArsivOdasi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ArsivOdasi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ArsivOdasi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ArsivOdasi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ArsivOdasi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ArsivOdasi] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ArsivOdasi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ArsivOdasi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ArsivOdasi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ArsivOdasi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ArsivOdasi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ArsivOdasi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ArsivOdasi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ArsivOdasi] SET RECOVERY FULL 
GO
ALTER DATABASE [ArsivOdasi] SET  MULTI_USER 
GO
ALTER DATABASE [ArsivOdasi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ArsivOdasi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ArsivOdasi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ArsivOdasi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ArsivOdasi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ArsivOdasi] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ArsivOdasi] SET QUERY_STORE = OFF
GO
USE [ArsivOdasi]
GO
/****** Object:  Table [dbo].[Bolum]    Script Date: 13.11.2022 22:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bolum](
	[Oda_Id] [int] NULL,
	[Bolum_Id] [int] IDENTITY(1,1) NOT NULL,
	[Bolum_Ad] [varchar](30) NULL,
 CONSTRAINT [PK_Bolum] PRIMARY KEY CLUSTERED 
(
	[Bolum_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dosya]    Script Date: 13.11.2022 22:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dosya](
	[Oda_Id] [int] NULL,
	[Bolum_Id] [int] NULL,
	[Raf_Id] [int] NULL,
	[Klasor_Id] [int] NULL,
	[Dosya_Id] [int] IDENTITY(1,1) NOT NULL,
	[Dosya_Ad] [varchar](30) NULL,
 CONSTRAINT [PK_Dosya] PRIMARY KEY CLUSTERED 
(
	[Dosya_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evrak]    Script Date: 13.11.2022 22:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evrak](
	[Oda_Id] [int] NULL,
	[Bolum_Id] [int] NULL,
	[Raf_Id] [int] NULL,
	[Klasor_Id] [int] NULL,
	[Dosya_Id] [int] NULL,
	[Evrak_Id] [int] IDENTITY(1,1) NOT NULL,
	[Evrak_Ad] [varchar](30) NULL,
	[Evrak_Turu] [varchar](50) NULL,
 CONSTRAINT [PK_Evrak] PRIMARY KEY CLUSTERED 
(
	[Evrak_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kisiler]    Script Date: 13.11.2022 22:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kisiler](
	[K_TC] [varchar](30) NULL,
	[K_AdSoyad] [varchar](50) NULL,
	[K_Yas] [varchar](15) NULL,
	[K_Tel] [varchar](30) NULL,
	[K_Sifre] [varchar](30) NULL,
	[K_SifreTekrar] [varchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Klasor]    Script Date: 13.11.2022 22:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klasor](
	[Oda_Id] [int] NULL,
	[Bolum_Id] [int] NULL,
	[Raf_Id] [int] NULL,
	[Klasor_Id] [int] IDENTITY(1,1) NOT NULL,
	[Klasor_Ad] [varchar](30) NULL,
 CONSTRAINT [PK_Klasor] PRIMARY KEY CLUSTERED 
(
	[Klasor_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oda]    Script Date: 13.11.2022 22:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oda](
	[Oda_Id] [int] IDENTITY(1,1) NOT NULL,
	[Oda_Ad] [varchar](30) NULL,
 CONSTRAINT [PK_Oda] PRIMARY KEY CLUSTERED 
(
	[Oda_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Raf]    Script Date: 13.11.2022 22:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Raf](
	[Oda_Id] [int] NULL,
	[Bolum_Id] [int] NULL,
	[Raf_Id] [int] IDENTITY(1,1) NOT NULL,
	[Raf_Ad] [varchar](30) NULL,
 CONSTRAINT [PK_Raf] PRIMARY KEY CLUSTERED 
(
	[Raf_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bolum] ON 

INSERT [dbo].[Bolum] ([Oda_Id], [Bolum_Id], [Bolum_Ad]) VALUES (98, 39, N'Bolum_1')
INSERT [dbo].[Bolum] ([Oda_Id], [Bolum_Id], [Bolum_Ad]) VALUES (99, 42, N'Bolum_2')
INSERT [dbo].[Bolum] ([Oda_Id], [Bolum_Id], [Bolum_Ad]) VALUES (100, 43, N'Bolum_3')
INSERT [dbo].[Bolum] ([Oda_Id], [Bolum_Id], [Bolum_Ad]) VALUES (100, 44, N'Bolum_4')
INSERT [dbo].[Bolum] ([Oda_Id], [Bolum_Id], [Bolum_Ad]) VALUES (100, 45, N'Bolum_5')
INSERT [dbo].[Bolum] ([Oda_Id], [Bolum_Id], [Bolum_Ad]) VALUES (101, 46, N'Bolum_6')
INSERT [dbo].[Bolum] ([Oda_Id], [Bolum_Id], [Bolum_Ad]) VALUES (103, 47, N'Bolum_7')
INSERT [dbo].[Bolum] ([Oda_Id], [Bolum_Id], [Bolum_Ad]) VALUES (104, 48, N'Bolum_8')
INSERT [dbo].[Bolum] ([Oda_Id], [Bolum_Id], [Bolum_Ad]) VALUES (105, 49, N'Bolum_9')
INSERT [dbo].[Bolum] ([Oda_Id], [Bolum_Id], [Bolum_Ad]) VALUES (105, 50, N'Bolum_10')
INSERT [dbo].[Bolum] ([Oda_Id], [Bolum_Id], [Bolum_Ad]) VALUES (107, 51, N'Bolum_11')
INSERT [dbo].[Bolum] ([Oda_Id], [Bolum_Id], [Bolum_Ad]) VALUES (109, 56, N'Oda_11B')
INSERT [dbo].[Bolum] ([Oda_Id], [Bolum_Id], [Bolum_Ad]) VALUES (109, 57, N'Oda_112')
INSERT [dbo].[Bolum] ([Oda_Id], [Bolum_Id], [Bolum_Ad]) VALUES (109, 59, N'Oda_113')
INSERT [dbo].[Bolum] ([Oda_Id], [Bolum_Id], [Bolum_Ad]) VALUES (111, 60, N'Bolum_Nure')
INSERT [dbo].[Bolum] ([Oda_Id], [Bolum_Id], [Bolum_Ad]) VALUES (98, 61, N'yeni')
SET IDENTITY_INSERT [dbo].[Bolum] OFF
GO
SET IDENTITY_INSERT [dbo].[Dosya] ON 

INSERT [dbo].[Dosya] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Dosya_Id], [Dosya_Ad]) VALUES (99, 42, 27, 19, 13, N'D1')
INSERT [dbo].[Dosya] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Dosya_Id], [Dosya_Ad]) VALUES (109, 56, 26, 23, 15, N'D3')
INSERT [dbo].[Dosya] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Dosya_Id], [Dosya_Ad]) VALUES (98, 39, 19, 18, 16, N'1234')
INSERT [dbo].[Dosya] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Dosya_Id], [Dosya_Ad]) VALUES (98, 39, 19, 16, 17, N'1235')
INSERT [dbo].[Dosya] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Dosya_Id], [Dosya_Ad]) VALUES (98, 39, 19, 20, 18, N'1254')
INSERT [dbo].[Dosya] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Dosya_Id], [Dosya_Ad]) VALUES (111, 60, 28, 24, 19, N'DosyaNure')
INSERT [dbo].[Dosya] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Dosya_Id], [Dosya_Ad]) VALUES (111, 60, 28, 24, 20, N'Nuree')
INSERT [dbo].[Dosya] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Dosya_Id], [Dosya_Ad]) VALUES (98, 39, 19, 16, 21, N'Yeni')
SET IDENTITY_INSERT [dbo].[Dosya] OFF
GO
SET IDENTITY_INSERT [dbo].[Evrak] ON 

INSERT [dbo].[Evrak] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Dosya_Id], [Evrak_Id], [Evrak_Ad], [Evrak_Turu]) VALUES (98, 39, 19, 16, 13, 1, N'E1001', N'Gelen Evrak')
INSERT [dbo].[Evrak] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Dosya_Id], [Evrak_Id], [Evrak_Ad], [Evrak_Turu]) VALUES (98, 39, 19, 16, 13, 3, N'E1002', N'Gelen Evrak')
INSERT [dbo].[Evrak] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Dosya_Id], [Evrak_Id], [Evrak_Ad], [Evrak_Turu]) VALUES (98, 39, 19, 16, 13, 4, N'E1003', N'Gelen Evrak')
INSERT [dbo].[Evrak] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Dosya_Id], [Evrak_Id], [Evrak_Ad], [Evrak_Turu]) VALUES (111, 60, 28, 24, 19, 5, N'ilaçlar', N'Gelen Evrak')
INSERT [dbo].[Evrak] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Dosya_Id], [Evrak_Id], [Evrak_Ad], [Evrak_Turu]) VALUES (111, 60, 28, 24, 19, 6, N'ilaçlar2', N'Giden Evrak')
INSERT [dbo].[Evrak] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Dosya_Id], [Evrak_Id], [Evrak_Ad], [Evrak_Turu]) VALUES (98, 39, 19, 16, 13, 7, N'Yeni', N'Gelen Evrak')
SET IDENTITY_INSERT [dbo].[Evrak] OFF
GO
INSERT [dbo].[Kisiler] ([K_TC], [K_AdSoyad], [K_Yas], [K_Tel], [K_Sifre], [K_SifreTekrar]) VALUES (N'12457845121', N'rukiye albayrak', N'30', N'(531) 326-8592', N'1111', N'1111')
INSERT [dbo].[Kisiler] ([K_TC], [K_AdSoyad], [K_Yas], [K_Tel], [K_Sifre], [K_SifreTekrar]) VALUES (N'14785296314', N'Gülcan arslan kara', N'25', N'5489639665', N'1245', N'1245')
INSERT [dbo].[Kisiler] ([K_TC], [K_AdSoyad], [K_Yas], [K_Tel], [K_Sifre], [K_SifreTekrar]) VALUES (N'11768822612', N'hatice albayrak', N'30', N'(562) 488-5621', N'1453', N'1453')
INSERT [dbo].[Kisiler] ([K_TC], [K_AdSoyad], [K_Yas], [K_Tel], [K_Sifre], [K_SifreTekrar]) VALUES (N'58831254680', N'Zeynep Albayrak', N'22', N'(569) 852-6365', N'14313560', N'14313560')
INSERT [dbo].[Kisiler] ([K_TC], [K_AdSoyad], [K_Yas], [K_Tel], [K_Sifre], [K_SifreTekrar]) VALUES (N'25123454145', N'Adalet Albayrak', N'35', N'(586) 418-5152', N'1234', N'1234')
INSERT [dbo].[Kisiler] ([K_TC], [K_AdSoyad], [K_Yas], [K_Tel], [K_Sifre], [K_SifreTekrar]) VALUES (N'11111111111', N'admin', N'25', N'(596) 321-5415', N'1234', N'1234')
INSERT [dbo].[Kisiler] ([K_TC], [K_AdSoyad], [K_Yas], [K_Tel], [K_Sifre], [K_SifreTekrar]) VALUES (N'22222222222', N'Nure', N'58', N'(589) 612-6312', N'2202', N'2202')
GO
SET IDENTITY_INSERT [dbo].[Klasor] ON 

INSERT [dbo].[Klasor] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Klasor_Ad]) VALUES (98, 39, 19, 16, N'Klasor_1')
INSERT [dbo].[Klasor] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Klasor_Ad]) VALUES (109, 56, 26, 17, N'klasor')
INSERT [dbo].[Klasor] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Klasor_Ad]) VALUES (98, 39, 19, 18, N'Klasor1')
INSERT [dbo].[Klasor] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Klasor_Ad]) VALUES (99, 42, 27, 19, N'Klasor2')
INSERT [dbo].[Klasor] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Klasor_Ad]) VALUES (98, 39, 19, 20, N'klasor çalıştır')
INSERT [dbo].[Klasor] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Klasor_Ad]) VALUES (109, 56, 26, 23, N'deneme')
INSERT [dbo].[Klasor] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Klasor_Ad]) VALUES (111, 60, 28, 24, N'Klasor_Nure')
INSERT [dbo].[Klasor] ([Oda_Id], [Bolum_Id], [Raf_Id], [Klasor_Id], [Klasor_Ad]) VALUES (98, 39, 19, 25, N'Yeni')
SET IDENTITY_INSERT [dbo].[Klasor] OFF
GO
SET IDENTITY_INSERT [dbo].[Oda] ON 

INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (98, N'Oda_1')
INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (99, N'Oda_2')
INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (100, N'Oda_3')
INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (101, N'Oda_4')
INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (102, N'Oda_5')
INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (103, N'Oda_6')
INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (104, N'Oda_7')
INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (105, N'Oda_8')
INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (106, N'Oda_9')
INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (107, N'Oda_10')
INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (109, N'Oda_11')
INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (111, N'O_Nure')
INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (112, N'yeni')
INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (113, N'dene')
INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (114, N'12345')
INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (115, N'vay')
INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (116, N'varan 32')
INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (117, N'47')
INSERT [dbo].[Oda] ([Oda_Id], [Oda_Ad]) VALUES (118, N'iki kelime')
SET IDENTITY_INSERT [dbo].[Oda] OFF
GO
SET IDENTITY_INSERT [dbo].[Raf] ON 

INSERT [dbo].[Raf] ([Oda_Id], [Bolum_Id], [Raf_Id], [Raf_Ad]) VALUES (98, 39, 19, N'Raf_1')
INSERT [dbo].[Raf] ([Oda_Id], [Bolum_Id], [Raf_Id], [Raf_Ad]) VALUES (98, 39, 21, N'Raf_2')
INSERT [dbo].[Raf] ([Oda_Id], [Bolum_Id], [Raf_Id], [Raf_Ad]) VALUES (103, 48, 24, N'Raf_5')
INSERT [dbo].[Raf] ([Oda_Id], [Bolum_Id], [Raf_Id], [Raf_Ad]) VALUES (100, 51, 25, N'Raf')
INSERT [dbo].[Raf] ([Oda_Id], [Bolum_Id], [Raf_Id], [Raf_Ad]) VALUES (109, 56, 26, N'Raf12')
INSERT [dbo].[Raf] ([Oda_Id], [Bolum_Id], [Raf_Id], [Raf_Ad]) VALUES (99, 42, 27, N'Raf1234')
INSERT [dbo].[Raf] ([Oda_Id], [Bolum_Id], [Raf_Id], [Raf_Ad]) VALUES (111, 60, 28, N'Raf_nure')
INSERT [dbo].[Raf] ([Oda_Id], [Bolum_Id], [Raf_Id], [Raf_Ad]) VALUES (98, 39, 29, N'Yeni')
SET IDENTITY_INSERT [dbo].[Raf] OFF
GO
ALTER TABLE [dbo].[Bolum]  WITH CHECK ADD  CONSTRAINT [FK_Bolum_Oda] FOREIGN KEY([Oda_Id])
REFERENCES [dbo].[Oda] ([Oda_Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Bolum] CHECK CONSTRAINT [FK_Bolum_Oda]
GO
ALTER TABLE [dbo].[Bolum]  WITH CHECK ADD  CONSTRAINT [FK_OdaID] FOREIGN KEY([Oda_Id])
REFERENCES [dbo].[Oda] ([Oda_Id])
GO
ALTER TABLE [dbo].[Bolum] CHECK CONSTRAINT [FK_OdaID]
GO
ALTER TABLE [dbo].[Dosya]  WITH CHECK ADD  CONSTRAINT [FK_Dosya_Klasor] FOREIGN KEY([Klasor_Id])
REFERENCES [dbo].[Klasor] ([Klasor_Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Dosya] CHECK CONSTRAINT [FK_Dosya_Klasor]
GO
ALTER TABLE [dbo].[Dosya]  WITH CHECK ADD  CONSTRAINT [FK_KlasorID] FOREIGN KEY([Klasor_Id])
REFERENCES [dbo].[Klasor] ([Klasor_Id])
GO
ALTER TABLE [dbo].[Dosya] CHECK CONSTRAINT [FK_KlasorID]
GO
ALTER TABLE [dbo].[Evrak]  WITH CHECK ADD  CONSTRAINT [FK_DosyaID] FOREIGN KEY([Dosya_Id])
REFERENCES [dbo].[Dosya] ([Dosya_Id])
GO
ALTER TABLE [dbo].[Evrak] CHECK CONSTRAINT [FK_DosyaID]
GO
ALTER TABLE [dbo].[Evrak]  WITH CHECK ADD  CONSTRAINT [FK_Evrak_Dosya] FOREIGN KEY([Dosya_Id])
REFERENCES [dbo].[Dosya] ([Dosya_Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Evrak] CHECK CONSTRAINT [FK_Evrak_Dosya]
GO
ALTER TABLE [dbo].[Klasor]  WITH CHECK ADD  CONSTRAINT [FK_Klasor_Raf] FOREIGN KEY([Raf_Id])
REFERENCES [dbo].[Raf] ([Raf_Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Klasor] CHECK CONSTRAINT [FK_Klasor_Raf]
GO
ALTER TABLE [dbo].[Klasor]  WITH CHECK ADD  CONSTRAINT [FK_RafID] FOREIGN KEY([Raf_Id])
REFERENCES [dbo].[Raf] ([Raf_Id])
GO
ALTER TABLE [dbo].[Klasor] CHECK CONSTRAINT [FK_RafID]
GO
ALTER TABLE [dbo].[Raf]  WITH CHECK ADD  CONSTRAINT [FK_BolumID] FOREIGN KEY([Bolum_Id])
REFERENCES [dbo].[Bolum] ([Bolum_Id])
GO
ALTER TABLE [dbo].[Raf] CHECK CONSTRAINT [FK_BolumID]
GO
ALTER TABLE [dbo].[Raf]  WITH CHECK ADD  CONSTRAINT [FK_Raf_Bolum] FOREIGN KEY([Bolum_Id])
REFERENCES [dbo].[Bolum] ([Bolum_Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Raf] CHECK CONSTRAINT [FK_Raf_Bolum]
GO
USE [master]
GO
ALTER DATABASE [ArsivOdasi] SET  READ_WRITE 
GO
