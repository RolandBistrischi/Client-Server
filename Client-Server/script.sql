USE [master]
GO
/****** Object:  Database [BancaDatabase]    Script Date: 27.04.2024 07:00:54:PM ******/
CREATE DATABASE [BancaDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BancaDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BancaDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BancaDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BancaDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BancaDatabase] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BancaDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BancaDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BancaDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BancaDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BancaDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BancaDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [BancaDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BancaDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BancaDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BancaDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BancaDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BancaDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BancaDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BancaDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BancaDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BancaDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BancaDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BancaDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BancaDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BancaDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BancaDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BancaDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BancaDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BancaDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [BancaDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [BancaDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BancaDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BancaDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BancaDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BancaDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BancaDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BancaDatabase', N'ON'
GO
ALTER DATABASE [BancaDatabase] SET QUERY_STORE = ON
GO
ALTER DATABASE [BancaDatabase] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BancaDatabase]
GO
/****** Object:  Table [dbo].[Tranzactii]    Script Date: 27.04.2024 07:00:54:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tranzactii](
	[Id_tranzactii] [int] IDENTITY(1,1) NOT NULL,
	[Id_user_sursa] [int] NOT NULL,
	[Id_user_destinatie] [int] NOT NULL,
	[Id_valuta] [int] NOT NULL,
	[suma] [decimal](18, 2) NOT NULL,
	[data_tranzactie] [datetime] NOT NULL,
	[stare_tranzactie] [varchar](50) NULL,
 CONSTRAINT [PK_Tranzactii] PRIMARY KEY CLUSTERED 
(
	[Id_tranzactii] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Useri]    Script Date: 27.04.2024 07:00:55:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Useri](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[sold] [money] NULL,
	[iban] [varchar](20) NOT NULL,
	[nume] [varchar](20) NOT NULL,
	[prenume] [varchar](20) NOT NULL,
	[cnp] [varchar](15) NOT NULL,
	[telefon] [varchar](10) NOT NULL,
	[data_creare] [date] NOT NULL,
	[id_valuta] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Valute]    Script Date: 27.04.2024 07:00:55:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Valute](
	[id_valuta] [int] IDENTITY(1,1) NOT NULL,
	[cod_valutar] [varchar](10) NOT NULL,
	[denumire] [varchar](50) NOT NULL,
	[simbol] [char](10) NOT NULL,
	[tara] [varchar](100) NOT NULL,
	[curs_de_schimb] [float] NOT NULL,
 CONSTRAINT [PK_Valute] PRIMARY KEY CLUSTERED 
(
	[id_valuta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tranzactii] ADD  CONSTRAINT [DF_Tranzactii_stare_tranzactie]  DEFAULT ('In asteptare') FOR [stare_tranzactie]
GO
ALTER TABLE [dbo].[Tranzactii]  WITH CHECK ADD  CONSTRAINT [FK_Tranzactii_Useri_Destinatie] FOREIGN KEY([Id_user_destinatie])
REFERENCES [dbo].[Useri] ([id_user])
GO
ALTER TABLE [dbo].[Tranzactii] CHECK CONSTRAINT [FK_Tranzactii_Useri_Destinatie]
GO
ALTER TABLE [dbo].[Tranzactii]  WITH CHECK ADD  CONSTRAINT [FK_Tranzactii_Useri_Sursa] FOREIGN KEY([Id_user_sursa])
REFERENCES [dbo].[Useri] ([id_user])
GO
ALTER TABLE [dbo].[Tranzactii] CHECK CONSTRAINT [FK_Tranzactii_Useri_Sursa]
GO
ALTER TABLE [dbo].[Tranzactii]  WITH CHECK ADD  CONSTRAINT [FK_Tranzactii_Valute] FOREIGN KEY([Id_valuta])
REFERENCES [dbo].[Valute] ([id_valuta])
GO
ALTER TABLE [dbo].[Tranzactii] CHECK CONSTRAINT [FK_Tranzactii_Valute]
GO
ALTER TABLE [dbo].[Useri]  WITH CHECK ADD  CONSTRAINT [FK_User_Valute] FOREIGN KEY([id_valuta])
REFERENCES [dbo].[Valute] ([id_valuta])
GO
ALTER TABLE [dbo].[Useri] CHECK CONSTRAINT [FK_User_Valute]
GO
USE [master]
GO
ALTER DATABASE [BancaDatabase] SET  READ_WRITE 
GO
