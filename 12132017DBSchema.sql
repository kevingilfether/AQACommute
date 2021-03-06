USE [master]
GO
/****** Object:  Database [AQACommuteDB]    Script Date: 12/13/2017 10:20:04 AM ******/
CREATE DATABASE [AQACommuteDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AQACommuteDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\AQACommuteDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AQACommuteDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\AQACommuteDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AQACommuteDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AQACommuteDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AQACommuteDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AQACommuteDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AQACommuteDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AQACommuteDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AQACommuteDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AQACommuteDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AQACommuteDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AQACommuteDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AQACommuteDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AQACommuteDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AQACommuteDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AQACommuteDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AQACommuteDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AQACommuteDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AQACommuteDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AQACommuteDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AQACommuteDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AQACommuteDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AQACommuteDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AQACommuteDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AQACommuteDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AQACommuteDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AQACommuteDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AQACommuteDB] SET  MULTI_USER 
GO
ALTER DATABASE [AQACommuteDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AQACommuteDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AQACommuteDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AQACommuteDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AQACommuteDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [AQACommuteDB]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 12/13/2017 10:20:04 AM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/13/2017 10:20:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/13/2017 10:20:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/13/2017 10:20:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/13/2017 10:20:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/13/2017 10:20:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Commute]    Script Date: 12/13/2017 10:20:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Commute](
	[CommuteID] [int] IDENTITY(1,1) NOT NULL,
	[CommuteTime] [varchar](50) NULL,
	[StartPoint] [nvarchar](300) NOT NULL,
	[EndPoint] [nvarchar](300) NOT NULL,
	[TotalMiles] [float] NULL,
	[CO2GeneratedLbs] [float] NOT NULL,
	[TransportMethodID] [int] NOT NULL,
 CONSTRAINT [PK_Commute] PRIMARY KEY CLUSTERED 
(
	[CommuteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CommuteLocation]    Script Date: 12/13/2017 10:20:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommuteLocation](
	[CommuteLocationID] [int] IDENTITY(1,1) NOT NULL,
	[LocationsID] [int] NOT NULL,
	[CommuteID] [int] NOT NULL,
 CONSTRAINT [PK_CommuteLocation] PRIMARY KEY CLUSTERED 
(
	[CommuteLocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Locations]    Script Date: 12/13/2017 10:20:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[LocationsID] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [nvarchar](50) NOT NULL,
	[LocationAddress] [nvarchar](100) NOT NULL,
	[UserID] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[LocationsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Make]    Script Date: 12/13/2017 10:20:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Make](
	[MakeID] [int] IDENTITY(1,1) NOT NULL,
	[MakeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Make] PRIMARY KEY CLUSTERED 
(
	[MakeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Model]    Script Date: 12/13/2017 10:20:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Model](
	[ModelID] [int] IDENTITY(1,1) NOT NULL,
	[ModelName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED 
(
	[ModelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Option]    Script Date: 12/13/2017 10:20:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Option](
	[OptionID] [int] IDENTITY(1,1) NOT NULL,
	[OptionName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Option] PRIMARY KEY CLUSTERED 
(
	[OptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TransportMethod]    Script Date: 12/13/2017 10:20:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportMethod](
	[TransportMethodID] [int] IDENTITY(1,1) NOT NULL,
	[TransportMode] [nvarchar](50) NOT NULL,
	[TransportClass] [nvarchar](50) NULL,
	[AvgMPG] [float] NOT NULL,
	[CityMPG] [float] NULL,
	[HwyMPG] [float] NULL,
	[CO2Lbs] [float] NULL,
	[MakeID] [int] NULL,
	[ModelID] [int] NULL,
	[YearID] [int] NULL,
	[OptionID] [int] NULL,
	[Make] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[Year] [nvarchar](50) NULL,
	[Options] [nvarchar](200) NULL,
 CONSTRAINT [PK_TransportMethod] PRIMARY KEY CLUSTERED 
(
	[TransportMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UTM]    Script Date: 12/13/2017 10:20:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UTM](
	[UTMID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](128) NOT NULL,
	[TransportMethodID] [int] NOT NULL,
 CONSTRAINT [PK_UTM] PRIMARY KEY CLUSTERED 
(
	[UTMID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Year]    Script Date: 12/13/2017 10:20:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Year](
	[YearID] [int] IDENTITY(1,1) NOT NULL,
	[Year] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Year] PRIMARY KEY CLUSTERED 
(
	[YearID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 12/13/2017 10:20:04 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 12/13/2017 10:20:04 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 12/13/2017 10:20:04 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 12/13/2017 10:20:04 AM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 12/13/2017 10:20:04 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 12/13/2017 10:20:04 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Commute]  WITH CHECK ADD  CONSTRAINT [FK_Commute_TransportMethod] FOREIGN KEY([TransportMethodID])
REFERENCES [dbo].[TransportMethod] ([TransportMethodID])
GO
ALTER TABLE [dbo].[Commute] CHECK CONSTRAINT [FK_Commute_TransportMethod]
GO
ALTER TABLE [dbo].[CommuteLocation]  WITH CHECK ADD  CONSTRAINT [FK_CommuteLocation_Commute] FOREIGN KEY([CommuteID])
REFERENCES [dbo].[Commute] ([CommuteID])
GO
ALTER TABLE [dbo].[CommuteLocation] CHECK CONSTRAINT [FK_CommuteLocation_Commute]
GO
ALTER TABLE [dbo].[CommuteLocation]  WITH CHECK ADD  CONSTRAINT [FK_CommuteLocation_Locations] FOREIGN KEY([LocationsID])
REFERENCES [dbo].[Locations] ([LocationsID])
GO
ALTER TABLE [dbo].[CommuteLocation] CHECK CONSTRAINT [FK_CommuteLocation_Locations]
GO
ALTER TABLE [dbo].[Locations]  WITH CHECK ADD  CONSTRAINT [FK_Locations_AspNetUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Locations] CHECK CONSTRAINT [FK_Locations_AspNetUsers]
GO
ALTER TABLE [dbo].[TransportMethod]  WITH CHECK ADD  CONSTRAINT [FK_TransportMethod_Make] FOREIGN KEY([MakeID])
REFERENCES [dbo].[Make] ([MakeID])
GO
ALTER TABLE [dbo].[TransportMethod] CHECK CONSTRAINT [FK_TransportMethod_Make]
GO
ALTER TABLE [dbo].[TransportMethod]  WITH CHECK ADD  CONSTRAINT [FK_TransportMethod_Model] FOREIGN KEY([ModelID])
REFERENCES [dbo].[Model] ([ModelID])
GO
ALTER TABLE [dbo].[TransportMethod] CHECK CONSTRAINT [FK_TransportMethod_Model]
GO
ALTER TABLE [dbo].[TransportMethod]  WITH CHECK ADD  CONSTRAINT [FK_TransportMethod_Option] FOREIGN KEY([OptionID])
REFERENCES [dbo].[Option] ([OptionID])
GO
ALTER TABLE [dbo].[TransportMethod] CHECK CONSTRAINT [FK_TransportMethod_Option]
GO
ALTER TABLE [dbo].[TransportMethod]  WITH CHECK ADD  CONSTRAINT [FK_TransportMethod_Year] FOREIGN KEY([YearID])
REFERENCES [dbo].[Year] ([YearID])
GO
ALTER TABLE [dbo].[TransportMethod] CHECK CONSTRAINT [FK_TransportMethod_Year]
GO
ALTER TABLE [dbo].[UTM]  WITH CHECK ADD  CONSTRAINT [FK_UTM_AspNetUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UTM] CHECK CONSTRAINT [FK_UTM_AspNetUsers]
GO
ALTER TABLE [dbo].[UTM]  WITH CHECK ADD  CONSTRAINT [FK_UTM_TransportMethod] FOREIGN KEY([TransportMethodID])
REFERENCES [dbo].[TransportMethod] ([TransportMethodID])
GO
ALTER TABLE [dbo].[UTM] CHECK CONSTRAINT [FK_UTM_TransportMethod]
GO
USE [master]
GO
ALTER DATABASE [AQACommuteDB] SET  READ_WRITE 
GO
