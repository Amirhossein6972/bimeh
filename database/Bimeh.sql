USE [master]
GO
/****** Object:  Database [Bimeh]    Script Date: 5/10/2024 5:51:34 PM ******/
CREATE DATABASE [Bimeh]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bimeh', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Bimeh.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Bimeh_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Bimeh_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Bimeh] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bimeh].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bimeh] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bimeh] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bimeh] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bimeh] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bimeh] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bimeh] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bimeh] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bimeh] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bimeh] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bimeh] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bimeh] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bimeh] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bimeh] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bimeh] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bimeh] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Bimeh] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bimeh] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bimeh] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bimeh] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bimeh] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bimeh] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Bimeh] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bimeh] SET RECOVERY FULL 
GO
ALTER DATABASE [Bimeh] SET  MULTI_USER 
GO
ALTER DATABASE [Bimeh] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bimeh] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bimeh] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bimeh] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Bimeh] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Bimeh', N'ON'
GO
ALTER DATABASE [Bimeh] SET QUERY_STORE = OFF
GO
USE [Bimeh]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/10/2024 5:51:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coverages]    Script Date: 5/10/2024 5:51:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coverages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](64) NOT NULL,
	[Rate] [decimal](18, 5) NOT NULL,
	[MaxCapital] [bigint] NOT NULL,
	[MinCapital] [bigint] NOT NULL,
 CONSTRAINT [PK_Coverages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InsuranceCalculations]    Script Date: 5/10/2024 5:51:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsuranceCalculations](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RequestCoverageId] [bigint] NOT NULL,
	[Rate] [decimal](18, 5) NOT NULL,
	[Result] [decimal](18, 5) NOT NULL,
 CONSTRAINT [PK_InsuranceCalculations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestCoverages]    Script Date: 5/10/2024 5:51:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestCoverages](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RequestId] [bigint] NOT NULL,
	[CoverageId] [int] NOT NULL,
	[Amount] [bigint] NOT NULL,
 CONSTRAINT [PK_RequestCoverages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requests]    Script Date: 5/10/2024 5:51:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requests](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240510124509_InitDataBase', N'8.0.4')
GO
SET IDENTITY_INSERT [dbo].[Coverages] ON 

INSERT [dbo].[Coverages] ([Id], [Title], [Rate], [MaxCapital], [MinCapital]) VALUES (1, N'پوشش جراحى', CAST(0.00520 AS Decimal(18, 5)), 500000000, 5000)
INSERT [dbo].[Coverages] ([Id], [Title], [Rate], [MaxCapital], [MinCapital]) VALUES (2, N'پوشش دندانپزشکی', CAST(0.00420 AS Decimal(18, 5)), 400000000, 4000)
INSERT [dbo].[Coverages] ([Id], [Title], [Rate], [MaxCapital], [MinCapital]) VALUES (3, N'پوشش بسترى', CAST(0.00500 AS Decimal(18, 5)), 200000000, 2000)
SET IDENTITY_INSERT [dbo].[Coverages] OFF
GO
SET IDENTITY_INSERT [dbo].[InsuranceCalculations] ON 

INSERT [dbo].[InsuranceCalculations] ([Id], [RequestCoverageId], [Rate], [Result]) VALUES (1, 1, CAST(0.00520 AS Decimal(18, 5)), CAST(260.00000 AS Decimal(18, 5)))
INSERT [dbo].[InsuranceCalculations] ([Id], [RequestCoverageId], [Rate], [Result]) VALUES (2, 2, CAST(0.00420 AS Decimal(18, 5)), CAST(2100.00000 AS Decimal(18, 5)))
INSERT [dbo].[InsuranceCalculations] ([Id], [RequestCoverageId], [Rate], [Result]) VALUES (3, 3, CAST(0.00520 AS Decimal(18, 5)), CAST(531.55440 AS Decimal(18, 5)))
SET IDENTITY_INSERT [dbo].[InsuranceCalculations] OFF
GO
SET IDENTITY_INSERT [dbo].[RequestCoverages] ON 

INSERT [dbo].[RequestCoverages] ([Id], [RequestId], [CoverageId], [Amount]) VALUES (1, 1, 1, 50000)
INSERT [dbo].[RequestCoverages] ([Id], [RequestId], [CoverageId], [Amount]) VALUES (2, 1, 2, 500000)
INSERT [dbo].[RequestCoverages] ([Id], [RequestId], [CoverageId], [Amount]) VALUES (3, 2, 1, 102222)
SET IDENTITY_INSERT [dbo].[RequestCoverages] OFF
GO
SET IDENTITY_INSERT [dbo].[Requests] ON 

INSERT [dbo].[Requests] ([Id], [Title]) VALUES (1, N'stringe')
INSERT [dbo].[Requests] ([Id], [Title]) VALUES (2, N'ggg')
SET IDENTITY_INSERT [dbo].[Requests] OFF
GO
/****** Object:  Index [IX_InsuranceCalculations_RequestCoverageId]    Script Date: 5/10/2024 5:51:34 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_InsuranceCalculations_RequestCoverageId] ON [dbo].[InsuranceCalculations]
(
	[RequestCoverageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RequestCoverages_RequestId]    Script Date: 5/10/2024 5:51:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_RequestCoverages_RequestId] ON [dbo].[RequestCoverages]
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[InsuranceCalculations]  WITH CHECK ADD  CONSTRAINT [FK_InsuranceCalculations_RequestCoverages_RequestCoverageId] FOREIGN KEY([RequestCoverageId])
REFERENCES [dbo].[RequestCoverages] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InsuranceCalculations] CHECK CONSTRAINT [FK_InsuranceCalculations_RequestCoverages_RequestCoverageId]
GO
ALTER TABLE [dbo].[RequestCoverages]  WITH CHECK ADD  CONSTRAINT [FK_RequestCoverages_Requests_RequestId] FOREIGN KEY([RequestId])
REFERENCES [dbo].[Requests] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RequestCoverages] CHECK CONSTRAINT [FK_RequestCoverages_Requests_RequestId]
GO
USE [master]
GO
ALTER DATABASE [Bimeh] SET  READ_WRITE 
GO
