USE [DeveloperForest]
GO
/****** Object:  StoredProcedure [dbo].[sp_MasterCategory]    Script Date: 7/16/2017 1:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_MasterCategory]
(
@CategoryName varchar(50),
@CreatedBy smallint,
@ModifiedBy smallint
)
As 
	BEGIN
		Insert into MasterCategory(CategoryName,CreatedBy,ModifiedBy) values(@CategoryName,@CreatedBy,@ModifiedBy)
	END


GO
/****** Object:  StoredProcedure [dbo].[sp_MasterSubCategory]    Script Date: 7/16/2017 1:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_MasterSubCategory]
(
@SubCategoryName varchar(50),
@CategoryID smallint,
@CreatedBy smallint,
@ModifiedBy smallint
)
As 
	BEGIN
		Insert into MasterSubCategory(SubCategoryName,CategoryID,CreatedBy,ModifiedBy)
				 values(@SubCategoryName,@CategoryID,@CreatedBy,@ModifiedBy)
	END


GO
