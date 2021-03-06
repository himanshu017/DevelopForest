USE [DeveloperForest]
GO
/****** Object:  StoredProcedure [dbo].[spValidateLogin]    Script Date: 8/30/2017 8:34:44 PM ******/
DROP PROCEDURE [dbo].[spValidateLogin]
GO
/****** Object:  StoredProcedure [dbo].[spChangeFogortPassword]    Script Date: 8/30/2017 8:34:44 PM ******/
DROP PROCEDURE [dbo].[spChangeFogortPassword]
GO
/****** Object:  StoredProcedure [dbo].[sp_Themes]    Script Date: 8/30/2017 8:34:44 PM ******/
DROP PROCEDURE [dbo].[sp_Themes]
GO
/****** Object:  StoredProcedure [dbo].[sp_MasterSubCategory]    Script Date: 8/30/2017 8:34:44 PM ******/
DROP PROCEDURE [dbo].[sp_MasterSubCategory]
GO
/****** Object:  StoredProcedure [dbo].[sp_MasterCategory]    Script Date: 8/30/2017 8:34:44 PM ******/
DROP PROCEDURE [dbo].[sp_MasterCategory]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteThemeById]    Script Date: 8/30/2017 8:34:44 PM ******/
DROP PROCEDURE [dbo].[sp_DeleteThemeById]
GO
/****** Object:  Table [dbo].[Themes]    Script Date: 8/30/2017 8:34:44 PM ******/
DROP TABLE [dbo].[Themes]
GO
/****** Object:  Table [dbo].[ThemeImage]    Script Date: 8/30/2017 8:34:44 PM ******/
DROP TABLE [dbo].[ThemeImage]
GO
/****** Object:  Table [dbo].[MasterUserType]    Script Date: 8/30/2017 8:34:44 PM ******/
DROP TABLE [dbo].[MasterUserType]
GO
/****** Object:  Table [dbo].[MasterUsers]    Script Date: 8/30/2017 8:34:44 PM ******/
DROP TABLE [dbo].[MasterUsers]
GO
/****** Object:  Table [dbo].[MasterSubCategory]    Script Date: 8/30/2017 8:34:44 PM ******/
DROP TABLE [dbo].[MasterSubCategory]
GO
/****** Object:  Table [dbo].[MasterItems]    Script Date: 8/30/2017 8:34:44 PM ******/
DROP TABLE [dbo].[MasterItems]
GO
/****** Object:  Table [dbo].[MasterCategory]    Script Date: 8/30/2017 8:34:44 PM ******/
DROP TABLE [dbo].[MasterCategory]
GO
/****** Object:  Table [dbo].[AdvancedTheme]    Script Date: 8/30/2017 8:34:44 PM ******/
DROP TABLE [dbo].[AdvancedTheme]
GO
/****** Object:  Table [dbo].[AdvancedTheme]    Script Date: 8/30/2017 8:34:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdvancedTheme](
	[AdvancedThemeId] [int] IDENTITY(1,1) NOT NULL,
	[ThemeId] [int] NULL,
	[RelatedLink1] [varchar](300) NULL,
	[RelatedLink2] [varchar](300) NULL,
	[RelatedLink3] [varchar](300) NULL,
	[RelatedLink4] [varchar](300) NULL,
	[RelatedLink5] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[AdvancedThemeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MasterCategory]    Script Date: 8/30/2017 8:34:44 PM ******/
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
	[CSSClass] [varchar](50) NULL,
	[CurrentIndex] [smallint] NULL,
 CONSTRAINT [PK_MasterCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MasterItems]    Script Date: 8/30/2017 8:34:44 PM ******/
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
/****** Object:  Table [dbo].[MasterSubCategory]    Script Date: 8/30/2017 8:34:44 PM ******/
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
	[CurrentIndex] [smallint] NULL,
 CONSTRAINT [PK_MasterSubCategory] PRIMARY KEY CLUSTERED 
(
	[SubCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MasterUsers]    Script Date: 8/30/2017 8:34:44 PM ******/
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
/****** Object:  Table [dbo].[MasterUserType]    Script Date: 8/30/2017 8:34:44 PM ******/
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
/****** Object:  Table [dbo].[ThemeImage]    Script Date: 8/30/2017 8:34:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ThemeImage](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[ImageName] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Themes]    Script Date: 8/30/2017 8:34:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Themes](
	[ThemeId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[SubCategoryId] [int] NULL,
	[Title] [varchar](300) NULL,
	[ImageId] [int] NULL,
	[Description] [varchar](max) NULL,
	[DemoLink] [varchar](300) NULL,
	[DownloadLink] [varchar](300) NULL,
	[CreatedBy] [smallint] NULL,
	[CreatedOn] [datetime] NULL CONSTRAINT [DF_Themes_CreatedOn]  DEFAULT (getdate()),
	[ModifiedBy] [smallint] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsTrending] [bit] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ThemeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AdvancedTheme] ON 

GO
INSERT [dbo].[AdvancedTheme] ([AdvancedThemeId], [ThemeId], [RelatedLink1], [RelatedLink2], [RelatedLink3], [RelatedLink4], [RelatedLink5]) VALUES (1, 20, N'http://localhost:50609/Theme/Theme1', N'http://localhost:50609/Theme/Theme2', N'http://localhost:50609/Theme/Theme3', N'http://localhost:50609/Theme/Theme4', N'http://localhost:50609/Theme/Theme6')
GO
SET IDENTITY_INSERT [dbo].[AdvancedTheme] OFF
GO
SET IDENTITY_INSERT [dbo].[MasterCategory] ON 

GO
INSERT [dbo].[MasterCategory] ([CategoryID], [CategoryName], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [CSSClass], [CurrentIndex]) VALUES (2, N'Test', 0, NULL, NULL, NULL, NULL, 2)
GO
INSERT [dbo].[MasterCategory] ([CategoryID], [CategoryName], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [CSSClass], [CurrentIndex]) VALUES (3, N'abc', 0, NULL, 0, NULL, N'ss', 4)
GO
INSERT [dbo].[MasterCategory] ([CategoryID], [CategoryName], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [CSSClass], [CurrentIndex]) VALUES (4, N'Template', 0, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[MasterCategory] ([CategoryID], [CategoryName], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [CSSClass], [CurrentIndex]) VALUES (5, N'Shoping', 0, NULL, NULL, NULL, N'Shoping Css', 3)
GO
INSERT [dbo].[MasterCategory] ([CategoryID], [CategoryName], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [CSSClass], [CurrentIndex]) VALUES (6, N'AAA', 0, NULL, NULL, NULL, N'aaa', 5)
GO
SET IDENTITY_INSERT [dbo].[MasterCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[MasterSubCategory] ON 

GO
INSERT [dbo].[MasterSubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [CurrentIndex]) VALUES (1, N'SubTests', 2, 0, NULL, 0, NULL, 3)
GO
INSERT [dbo].[MasterSubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [CurrentIndex]) VALUES (3, N'yuuii', 2, 0, NULL, 0, NULL, 4)
GO
INSERT [dbo].[MasterSubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [CurrentIndex]) VALUES (4, N'Test', 3, 0, NULL, 0, NULL, 2)
GO
INSERT [dbo].[MasterSubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [CurrentIndex]) VALUES (5, N'TemplateSub', 4, 0, NULL, 0, NULL, 1)
GO
INSERT [dbo].[MasterSubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [CurrentIndex]) VALUES (6, N'Plain', 5, 0, NULL, 0, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[MasterSubCategory] OFF
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
SET IDENTITY_INSERT [dbo].[ThemeImage] ON 

GO
INSERT [dbo].[ThemeImage] ([ImageId], [ImageName]) VALUES (1, N'f4259581-d717-421d-b5bc-b6aa6bfcc2ec.jpg')
GO
INSERT [dbo].[ThemeImage] ([ImageId], [ImageName]) VALUES (2, N'f502003e-7192-4f13-8af1-e190a323e0a8.jpg')
GO
INSERT [dbo].[ThemeImage] ([ImageId], [ImageName]) VALUES (3, N'50c6b819-1cdf-4c11-9841-7a31bda8d60b.jpg')
GO
INSERT [dbo].[ThemeImage] ([ImageId], [ImageName]) VALUES (4, N'58246fba-320f-4be0-89d6-8a6fc50e48b2.jpg')
GO
INSERT [dbo].[ThemeImage] ([ImageId], [ImageName]) VALUES (5, N'fb8805b9-1809-46ea-b15b-c149c31e57cb.jpg')
GO
INSERT [dbo].[ThemeImage] ([ImageId], [ImageName]) VALUES (6, N'b2fa8199-b1bf-40d8-98f3-862177b19bf8.jpg')
GO
INSERT [dbo].[ThemeImage] ([ImageId], [ImageName]) VALUES (7, N'0cc8c7cc-7e91-4171-b323-a648f4d09994.jpg')
GO
INSERT [dbo].[ThemeImage] ([ImageId], [ImageName]) VALUES (8, N'0c2c974b-3a5d-47e5-a5ff-a796efb23ac3.jpg')
GO
INSERT [dbo].[ThemeImage] ([ImageId], [ImageName]) VALUES (9, N'16b83158-42c0-4348-8fea-a1ba907ba677.jpg')
GO
INSERT [dbo].[ThemeImage] ([ImageId], [ImageName]) VALUES (10, N'b97ab3b1-1379-4cc9-8ed3-8ed7de810517.jpg')
GO
SET IDENTITY_INSERT [dbo].[ThemeImage] OFF
GO
SET IDENTITY_INSERT [dbo].[Themes] ON 

GO
INSERT [dbo].[Themes] ([ThemeId], [CategoryId], [SubCategoryId], [Title], [ImageId], [Description], [DemoLink], [DownloadLink], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsTrending], [IsActive]) VALUES (17, 4, 5, N'Theme', 7, N'http://localhost:50609/Theme/Theme', N'http://localhost:50609/Theme/Theme', N'http://localhost:50609/Theme/Theme', 0, NULL, 0, NULL, 1, NULL)
GO
INSERT [dbo].[Themes] ([ThemeId], [CategoryId], [SubCategoryId], [Title], [ImageId], [Description], [DemoLink], [DownloadLink], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsTrending], [IsActive]) VALUES (18, 4, 5, N'ShoingKart', 7, NULL, NULL, NULL, NULL, CAST(N'2017-07-30 19:44:09.853' AS DateTime), NULL, NULL, 1, NULL)
GO
INSERT [dbo].[Themes] ([ThemeId], [CategoryId], [SubCategoryId], [Title], [ImageId], [Description], [DemoLink], [DownloadLink], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsTrending], [IsActive]) VALUES (19, 5, 6, N'Plain Shoping Template', 8, N'http://localhost:50609/Theme/Theme', N'http://localhost:50609/Theme/Theme/Test', N'http://localhost:50609/Theme/Theme', 0, CAST(N'2017-08-09 22:38:30.263' AS DateTime), 0, NULL, 0, NULL)
GO
INSERT [dbo].[Themes] ([ThemeId], [CategoryId], [SubCategoryId], [Title], [ImageId], [Description], [DemoLink], [DownloadLink], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsTrending], [IsActive]) VALUES (20, 2, 1, N'ImageTest', 9, N'sss', N'http://localhost:50609/Theme/Theme', N'http://localhost:50609/Theme/Theme', 0, CAST(N'2017-08-30 00:16:32.863' AS DateTime), 0, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Themes] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteThemeById]    Script Date: 8/30/2017 8:34:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_DeleteThemeById]
(
@ThemeId int,
@ImageName varchar(300) out
)
AS
		declare	@ThemeImage varchar(300)
	BEGIN
		Select @ThemeImage=(Select ImageName from ThemeImage where ThemeImage.ImageId=Themes.ImageId) from Themes where ThemeId=@ThemeId

		Delete from Themes where ThemeId=@ThemeId

		Delete from AdvancedTheme where ThemeId=@ThemeId

		Select @ThemeImage
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_MasterCategory]    Script Date: 8/30/2017 8:34:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[sp_MasterCategory]
(
@CategoryId int,
@CategoryName varchar(50),
@CreatedBy smallint,
@ModifiedBy smallint,
@CSSClass varchar(50)
)
As 
	BEGIN
	if(@CategoryId=0)
	BEGIN
	if exists(select 'exists' from MasterCategory where CategoryName=@CategoryName)
		select -1;
	else
		begin
			Insert into MasterCategory(CategoryName,CreatedBy,CSSClass) values(@CategoryName,@CreatedBy,@CSSClass);
			select 1;
		end
	END
	Else
	BEGIN
	update MasterCategory set CategoryName=@CategoryName,ModifiedBy=@ModifiedBy,CSSClass=@CSSClass where CategoryID=@CategoryId
	select 2;
	END
		
	END



GO
/****** Object:  StoredProcedure [dbo].[sp_MasterSubCategory]    Script Date: 8/30/2017 8:34:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_MasterSubCategory]
(
@SubCategoryId int,
@SubCategoryName varchar(50),
@CategoryID smallint,
@CreatedBy smallint,
@ModifiedBy smallint
)
As 
	BEGIN
		if(@SubCategoryId=0)
			BEGIN
				if exists(Select 'exists' from MasterSubCategory where CategoryID=@CategoryID and SubCategoryName=@SubCategoryName)
					SELECT -1;
				else
					begin
				Insert into MasterSubCategory(SubCategoryName,CategoryID,CreatedBy,ModifiedBy)
						 values(@SubCategoryName,@CategoryID,@CreatedBy,@ModifiedBy)
					end
			END
		else
			BEGIN
				update MasterSubCategory set SubCategoryName=@SubCategoryName,CategoryID=@CategoryID,CreatedBy=@CreatedBy,
				ModifiedBy=@ModifiedBy where SubCategoryID=@SubCategoryId
			END
	END




GO
/****** Object:  StoredProcedure [dbo].[sp_Themes]    Script Date: 8/30/2017 8:34:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_Themes]
(
@ThemeId int ,
@CategoryId int,
@SubCategoryId int,
@Title varchar(300),
@ImageName varchar(100),
@Description varchar(max),
@DemoLink varchar(300),
@DownloadLink varchar(300),
@CreatedBy smallint,
@ModifiedBy smallint,
@RelatedLink1 varchar(300),
@RelatedLink2 varchar(300),
@RelatedLink3 varchar(300),
@RelatedLink4 varchar(300),
@RelatedLink5 varchar(300)
)
AS
	declare @ImageId int, @ThemesId int
  BEGIN
	if(@ThemeId=0)
		begin
			Insert into ThemeImage(ImageName) values(@ImageName)

			set @ImageId= SCOPE_IDENTITY()

			Insert into Themes(CategoryId,SubCategoryId,Title,ImageId,Description,DemoLink,DownloadLink,CreatedBy,ModifiedBy)
			values(@CategoryId,@SubCategoryId,@Title,@ImageId,@Description,@DemoLink,@DownloadLink,@CreatedBy,@ModifiedBy)

			set @ThemesId= SCOPE_IDENTITY()
			Insert into AdvancedTheme(ThemeId,RelatedLink1,RelatedLink2,RelatedLink3,RelatedLink4,RelatedLink5) 
						values(@ThemesId,@RelatedLink1,@RelatedLink2,@RelatedLink3,@RelatedLink4,@RelatedLink5)
		end
	else
		begin
			Update Themes set CategoryId=@CategoryId,SubCategoryId=@SubCategoryId,Title=@Title,Description=@Description,
			DemoLink=@DemoLink,DownloadLink=@DownloadLink,ModifiedBy=@ModifiedBy where ThemeId=@ThemeId

			Update AdvancedTheme set RelatedLink1=@RelatedLink1,
			RelatedLink2=RelatedLink2,RelatedLink3=@RelatedLink3,RelatedLink4=@RelatedLink4,RelatedLink5=@RelatedLink5 where ThemeId=@ThemeId
		end
  END


GO
/****** Object:  StoredProcedure [dbo].[spChangeFogortPassword]    Script Date: 8/30/2017 8:34:44 PM ******/
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
/****** Object:  StoredProcedure [dbo].[spValidateLogin]    Script Date: 8/30/2017 8:34:44 PM ******/
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
