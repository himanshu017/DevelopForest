USE [DeveloperForest]
GO
/****** Object:  StoredProcedure [dbo].[sp_MasterCategory]    Script Date: 7/16/2017 5:53:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_MasterCategory]
(
@CategoryId int,
@CategoryName varchar(50),
@CreatedBy smallint,
@ModifiedBy smallint
)
As 
	BEGIN
	if(@CategoryId=0)
	BEGIN
	if exists(select 'exists' from MasterCategory where CategoryName=@CategoryName)
		select -1;
	else
		begin
			Insert into MasterCategory(CategoryName,CreatedBy) values(@CategoryName,@CreatedBy);
			select 1;
		end
	END
	Else
	BEGIN
	update MasterCategory set CategoryName=@CategoryName,ModifiedBy=@ModifiedBy where CategoryID=@CategoryId
	select 2;
	END
		
	END



GO
/****** Object:  StoredProcedure [dbo].[sp_MasterSubCategory]    Script Date: 7/16/2017 5:53:25 PM ******/
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
