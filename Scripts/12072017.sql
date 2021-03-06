USE [DeveloperForest]
GO
/****** Object:  StoredProcedure [dbo].[spValidateLogin]    Script Date: 7/12/2017 9:31:20 PM ******/
DROP PROCEDURE [dbo].[spValidateLogin]
GO
/****** Object:  StoredProcedure [dbo].[spChangeFogortPassword]    Script Date: 7/12/2017 9:31:20 PM ******/
DROP PROCEDURE [dbo].[spChangeFogortPassword]
GO
/****** Object:  Table [dbo].[MasterUserType]    Script Date: 7/12/2017 9:31:20 PM ******/
DROP TABLE [dbo].[MasterUserType]
GO
/****** Object:  Table [dbo].[MasterUsers]    Script Date: 7/12/2017 9:31:20 PM ******/
DROP TABLE [dbo].[MasterUsers]
GO
/****** Object:  Table [dbo].[MasterSubCategory]    Script Date: 7/12/2017 9:31:20 PM ******/
DROP TABLE [dbo].[MasterSubCategory]
GO
/****** Object:  Table [dbo].[MasterItems]    Script Date: 7/12/2017 9:31:20 PM ******/
DROP TABLE [dbo].[MasterItems]
GO
/****** Object:  Table [dbo].[MasterCategory]    Script Date: 7/12/2017 9:31:20 PM ******/
DROP TABLE [dbo].[MasterCategory]
GO
/****** Object:  Table [dbo].[MasterCategory]    Script Date: 7/12/2017 9:31:20 PM ******/
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
/****** Object:  Table [dbo].[MasterItems]    Script Date: 7/12/2017 9:31:21 PM ******/
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
/****** Object:  Table [dbo].[MasterSubCategory]    Script Date: 7/12/2017 9:31:21 PM ******/
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
/****** Object:  Table [dbo].[MasterUsers]    Script Date: 7/12/2017 9:31:21 PM ******/
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
	[PasswordHash] [varchar](100) NULL,
	[PasswordSalt] [varchar](100) NULL,
	[UserTypeID] [smallint] NULL,
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
/****** Object:  Table [dbo].[MasterUserType]    Script Date: 7/12/2017 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MasterUserType](
	[UserTypeID] [tinyint] IDENTITY(1,1) NOT NULL,
	[UserType] [varchar](50) NOT NULL,
	[UserTitle] [varchar](100) NULL,
 CONSTRAINT [PK_UserTypeMaster] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[MasterUsers] ON 

GO
INSERT [dbo].[MasterUsers] ([UserID], [FirstName], [LastName], [Email], [Phone], [PasswordHash], [PasswordSalt], [UserTypeID], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'John', N'Smith', N'admin@admin.com', N'7508744004', N'Kk0E/KmXAFpR8K8SVp0yuvnetFqFy6/f', N'+d60WoXLr98=', 1, 1, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[MasterUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[MasterUserType] ON 

GO
INSERT [dbo].[MasterUserType] ([UserTypeID], [UserType], [UserTitle]) VALUES (1, N'Admin', NULL)
GO
INSERT [dbo].[MasterUserType] ([UserTypeID], [UserType], [UserTitle]) VALUES (2, N'AgencyOwner', NULL)
GO
SET IDENTITY_INSERT [dbo].[MasterUserType] OFF
GO
/****** Object:  StoredProcedure [dbo].[spChangeFogortPassword]    Script Date: 7/12/2017 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spChangeFogortPassword]
(
           @EMAIL varchar(100),
           @PasswordHash varchar(100),
           @PasswordSalt varchar(100)
		   )
		   AS
		   BEGIN
		   UPDATE MasterUsers set PasswordHash=@PasswordHash,PasswordSalt=@PasswordSalt where Email=@EMAIL
		   select 1
		   END
GO
/****** Object:  StoredProcedure [dbo].[spValidateLogin]    Script Date: 7/12/2017 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spValidateLogin] --[dbo].[spValidateLogin] 'admin@admin.com'
@email nvarchar(255)
as
Begin
		if exists(select 'exists' from MasterUsers where Email = @email)
			Begin
				select UserID,FirstName + isnull(' ' + LastName,'') as Name ,passwordHash,passwordSalt,Email, 1 as status ,
				um.UserTypeID,mut.UserType,
				'' as Imagename
				,'' as AgencyLogo
				from MasterUsers  um 
				join MasterUserType mut on um.UserTypeID=mut.UserTypeId
				where email = @email
			End
		else
			Begin
				select 2 as status
			End
End
GO
