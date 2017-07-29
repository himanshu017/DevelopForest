alter table Theme 
add IsTrending bit,IsActive bit

alter table MasterCategory
add CSSClass varchar(50)

GO


ALTER proc [dbo].[sp_MasterCategory]
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


