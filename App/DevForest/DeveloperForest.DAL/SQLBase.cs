using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperForest.DAL
{
  public static  class SQLBase
    {
      public static string SQL_GET_Categories = "Select CategoryId,CategoryName,CSSClass,CurrentIndex from MasterCategory order by isnull(CurrentIndex,0) asc";
        public static string SQL_DeleteCategoriesByID = "Delete  from MasterCategory where CategoryId=@CategoryId";
        public static string SQL_GET_SubCategories = "Select SubCategoryID,SubCategoryName,CategoryId,(Select CategoryName from MasterCategory where CategoryId=MasterSubCategory.CategoryId) as CategoryName from MasterSubCategory order by SubCategoryID desc";
        public static string SQL_DeleteSubCategoriesById = "Delete from MasterSubCategory where SubCategoryID=@SubCategoryId";
        public static string SQL_GET_Themes = @"Select ThemeId,(Select CategoryName from MasterCategory where CategoryId= Themes.CategoryId) CategoryName,CategoryId,SubCategoryId,
                                            (Select SubCategoryName from MasterSubCategory where SubCategoryId= Themes.SubCategoryId) SubCategoryName,Title,Description,DemoLink,DownloadLink,(Select imageName from Themeimage where ImageId=Themes.ImageId) as ImageName from Themes order by ThemeId desc";
        public static string SQL_DeleteThemeById = "Delete from Themes where ThemeId=@ThemeId";
        public static string SQL_Update_Category_Index = "update MasterCategory set CurrentIndex=@Index where CategoryID=@CategoryID";
        public static string SQL_Update_ThemeTrends = "update Themes set IsTrending=@IsTrending where ThemeID=@ThemeID";
    }
}
