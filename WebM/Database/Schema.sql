USE [master]
GO
/****** Object:  Database [db_Community_Ban]    Script Date: 2/17/2015 4:43:13 PM ******/
CREATE DATABASE [db_Community_Ban]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_Community_Ban', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\db_Community_Ban.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'db_Community_Ban_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\db_Community_Ban_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [db_Community_Ban] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_Community_Ban].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_Community_Ban] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_Community_Ban] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_Community_Ban] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_Community_Ban] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_Community_Ban] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_Community_Ban] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [db_Community_Ban] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_Community_Ban] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_Community_Ban] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_Community_Ban] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_Community_Ban] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_Community_Ban] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_Community_Ban] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_Community_Ban] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_Community_Ban] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_Community_Ban] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_Community_Ban] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_Community_Ban] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_Community_Ban] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_Community_Ban] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_Community_Ban] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [db_Community_Ban] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_Community_Ban] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_Community_Ban] SET  MULTI_USER 
GO
ALTER DATABASE [db_Community_Ban] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_Community_Ban] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_Community_Ban] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_Community_Ban] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [db_Community_Ban] SET DELAYED_DURABILITY = DISABLED 
GO
USE [db_Community_Ban]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2/17/2015 4:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CenterMedicines]    Script Date: 2/17/2015 4:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CenterMedicines](
	[CenterMedicineId] [int] IDENTITY(1,1) NOT NULL,
	[MedicineQuantity] [float] NOT NULL,
	[CenterId] [int] NOT NULL,
	[MedicineId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.CenterMedicines] PRIMARY KEY CLUSTERED 
(
	[CenterMedicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Centers]    Script Date: 2/17/2015 4:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Centers](
	[CenterId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Code] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[District] [nvarchar](max) NULL,
	[Thana] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Centers] PRIMARY KEY CLUSTERED 
(
	[CenterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2/17/2015 4:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[DiseaseId] [int] NOT NULL,
	[PatientNumber] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Diseases]    Script Date: 2/17/2015 4:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diseases](
	[DiseaseId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[TreatmentProcedure] [nvarchar](max) NOT NULL,
	[PreferredDrugs] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Diseases] PRIMARY KEY CLUSTERED 
(
	[DiseaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Districts]    Script Date: 2/17/2015 4:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Districts](
	[DistrictId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Population] [float] NOT NULL,
 CONSTRAINT [PK_dbo.Districts] PRIMARY KEY CLUSTERED 
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DivAndDis]    Script Date: 2/17/2015 4:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DivAndDis](
	[DivAndDisRelId] [int] IDENTITY(1,1) NOT NULL,
	[DivisionId] [int] NOT NULL,
	[DistrictId] [int] NOT NULL,
 CONSTRAINT [PK_DivAndDis] PRIMARY KEY CLUSTERED 
(
	[DivAndDisRelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Divisions]    Script Date: 2/17/2015 4:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Divisions](
	[DivisionId] [int] IDENTITY(1,1) NOT NULL,
	[DivisionName] [varchar](50) NOT NULL,
	[DivisionCode] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Divisions] PRIMARY KEY CLUSTERED 
(
	[DivisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 2/17/2015 4:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[DoctorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Degree] [nvarchar](max) NULL,
	[Speciality] [nvarchar](max) NULL,
	[CenterId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Doctors] PRIMARY KEY CLUSTERED 
(
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Medicines]    Script Date: 2/17/2015 4:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicines](
	[MedicineId] [int] IDENTITY(1,1) NOT NULL,
	[GenericName] [nvarchar](max) NULL,
	[Quantity] [float] NOT NULL,
	[QuantityUnit] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Medicines] PRIMARY KEY CLUSTERED 
(
	[MedicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Patients]    Script Date: 2/17/2015 4:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[VoterId] [bigint] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Age] [float] NOT NULL,
	[CenterId] [int] NOT NULL,
	[ServiceCount] [int] NOT NULL,
	[DistrictId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Patients] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Prescriptions]    Script Date: 2/17/2015 4:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prescriptions](
	[PrescriptionId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[VoterId] [bigint] NOT NULL,
	[Observation] [nvarchar](max) NULL,
	[Dose] [nvarchar](max) NULL,
	[BeforeAfter] [nvarchar](max) NULL,
	[QuantityGiven] [int] NOT NULL,
	[Note] [nvarchar](max) NULL,
	[DiseaseId] [int] NOT NULL,
	[PatientId] [bigint] NOT NULL,
	[DoctorId] [int] NOT NULL,
	[MedicineId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Prescriptions] PRIMARY KEY CLUSTERED 
(
	[PrescriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reports]    Script Date: 2/17/2015 4:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[ReportId] [int] IDENTITY(1,1) NOT NULL,
	[DistrictName] [nvarchar](max) NULL,
	[DistrictId] [int] NOT NULL,
	[TotalPatient] [int] NOT NULL,
	[AffectedPopulationPercentage] [float] NOT NULL,
 CONSTRAINT [PK_dbo.Reports] PRIMARY KEY CLUSTERED 
(
	[ReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Thanas]    Script Date: 2/17/2015 4:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Thanas](
	[ThanaId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[DistrictId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Thanas] PRIMARY KEY CLUSTERED 
(
	[ThanaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_CenterId]    Script Date: 2/17/2015 4:43:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_CenterId] ON [dbo].[CenterMedicines]
(
	[CenterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MedicineId]    Script Date: 2/17/2015 4:43:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_MedicineId] ON [dbo].[CenterMedicines]
(
	[MedicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CenterId]    Script Date: 2/17/2015 4:43:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_CenterId] ON [dbo].[Patients]
(
	[CenterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DistrictId]    Script Date: 2/17/2015 4:43:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_DistrictId] ON [dbo].[Patients]
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DistrictId]    Script Date: 2/17/2015 4:43:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_DistrictId] ON [dbo].[Thanas]
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CenterMedicines]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CenterMedicines_dbo.Centers_CenterId] FOREIGN KEY([CenterId])
REFERENCES [dbo].[Centers] ([CenterId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CenterMedicines] CHECK CONSTRAINT [FK_dbo.CenterMedicines_dbo.Centers_CenterId]
GO
ALTER TABLE [dbo].[CenterMedicines]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CenterMedicines_dbo.Medicines_MedicineId] FOREIGN KEY([MedicineId])
REFERENCES [dbo].[Medicines] ([MedicineId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CenterMedicines] CHECK CONSTRAINT [FK_dbo.CenterMedicines_dbo.Medicines_MedicineId]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Patients_dbo.Centers_CenterId] FOREIGN KEY([CenterId])
REFERENCES [dbo].[Centers] ([CenterId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK_dbo.Patients_dbo.Centers_CenterId]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Patients_dbo.Districts_DistrictId] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Districts] ([DistrictId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK_dbo.Patients_dbo.Districts_DistrictId]
GO
ALTER TABLE [dbo].[Thanas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Thanas_dbo.Districts_DistrictId] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Districts] ([DistrictId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Thanas] CHECK CONSTRAINT [FK_dbo.Thanas_dbo.Districts_DistrictId]
GO
USE [master]
GO
ALTER DATABASE [db_Community_Ban] SET  READ_WRITE 
GO
