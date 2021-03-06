USE [DeveloperForest]
GO
/****** Object:  Table [dbo].[MasterCategory]    Script Date: 6/30/2017 10:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MasterCategory](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
	[CreatedBy] [smallint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [smallint] NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_MasterCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MasterItems]    Script Date: 6/30/2017 10:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MasterItems](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[ItemTitle] [varchar](50) NULL,
	[ItemDescription] [varchar](max) NULL,
	[IsFree] [bit] NULL,
	[Amount] [decimal](18, 2) NULL,
	[Currency] [varchar](10) NULL,
	[OfficalWebSiteName] [varchar](50) NULL,
	[License] [varchar](50) NULL,
	[SubCategoryID] [int] NULL,
	[CategoryID] [int] NULL,
	[CreatedBy] [smallint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [smallint] NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_MasterItems] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MasterSubCategory]    Script Date: 6/30/2017 10:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MasterSubCategory](
	[SubCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[SubCategoryName] [varchar](50) NULL,
	[CategoryID] [int] NULL,
	[CreatedBy] [smallint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [smallint] NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_MasterSubCategory] PRIMARY KEY CLUSTERED 
(
	[SubCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MasterUsers]    Script Date: 6/30/2017 10:29:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MasterUsers](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [smallint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [smallint] NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_MasterUsers] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
