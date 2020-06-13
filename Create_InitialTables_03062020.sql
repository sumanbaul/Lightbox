USE [Lightbox]
GO
/****** Object:  Table [dbo].[Arts]    Script Date: 6-6-2020 16:31:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IllustratorName] [nvarchar](max) NULL,
	[Country] [bigint] NULL,
	[Address] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[Rep] [nvarchar](max) NULL,
	[Website] [nvarchar](max) NULL,
	[Price] [bigint] NOT NULL,
	[Timeliness] [nvarchar](max) NULL,
	[Availability] [datetime] NULL,
	[Launguage] [nvarchar](max) NULL,
	[AgeGroup] [int] NULL,
	[Categories] [nvarchar](max) NULL,
	[ProgramsWorkedOn] [nvarchar](max) NULL,
	[ArtCommissioner] [nvarchar](max) NULL,
	[Image] [varbinary](max) NULL,
	[IsActive] [bit] NULL,
	[IsApproved] [bit] NULL,
	[Keywords] [nvarchar](max) NULL,
 CONSTRAINT [PK_Arts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Country]    Script Date: 6-6-2020 16:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [bigint] NOT NULL,
	[CountryName] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Photos]    Script Date: 6-6-2020 16:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Vendor] [nvarchar](max) NULL,
	[Terms] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreditLine] [nvarchar](max) NULL,
	[Restrictions] [nvarchar](max) NULL,
	[Keywords] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[AssetType] [nvarchar](max) NULL,
	[PropertyRelease] [date] NULL,
	[Country] [bigint] NULL,
	[Photoresearcher] [nvarchar](max) NULL,
	[Image] [varbinary](max) NULL,
	[IsActive] [bit] NULL,
	[IsApproved] [bit] NULL,
 CONSTRAINT [PK_Photos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
