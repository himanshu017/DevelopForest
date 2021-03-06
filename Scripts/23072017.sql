USE [DeveloperForest]
GO
/****** Object:  Table [dbo].[MasterSubCategory]    Script Date: 7/23/2017 12:01:07 PM ******/
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
/****** Object:  Table [dbo].[ThemeImage]    Script Date: 7/23/2017 12:01:08 PM ******/
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
/****** Object:  Table [dbo].[Themes]    Script Date: 7/23/2017 12:01:08 PM ******/
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
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [smallint] NULL,
	[ModifiedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ThemeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteThemeById]    Script Date: 7/23/2017 12:01:08 PM ******/
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

		Select @ThemeImage
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_MasterSubCategory]    Script Date: 7/23/2017 12:01:08 PM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_Themes]    Script Date: 7/23/2017 12:01:08 PM ******/
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
@ModifiedBy smallint
)
AS
	declare @ImageId int
  BEGIN
	if(@ThemeId=0)
		begin
			Insert into ThemeImage(ImageName) values(@ImageName)

			set @ImageId= SCOPE_IDENTITY()

			Insert into Themes(CategoryId,SubCategoryId,Title,ImageId,Description,DemoLink,DownloadLink,CreatedBy,ModifiedBy)
			values(@CategoryId,@SubCategoryId,@Title,@ImageId,@Description,@DemoLink,@DownloadLink,@CreatedBy,@ModifiedBy)
		end
	else
		begin
			Update Themes set CategoryId=@CategoryId,SubCategoryId=@SubCategoryId,Title=@Title,Description=@Description,
			DemoLink=@DemoLink,DownloadLink=@DownloadLink,ModifiedBy=@ModifiedBy where ThemeId=@ThemeId
		end
  END

GO
