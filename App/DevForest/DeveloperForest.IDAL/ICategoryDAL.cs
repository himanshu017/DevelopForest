using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperForest.Model;

namespace DeveloperForest.IDAL
{
    public interface ICategoryDAL
    {
        int InsertCategory(CategoryModel model);
        int InsertSubCategory(CategoryModel model);

        List<CategoryModel> CategoryList();
        int DeleteCategory(int CategoryID);
        List<CategoryModel> SubCategoryList();

        int DeleteSubCategory(int SubCategory);

        bool UpdateCategoryIndex(CategoryModel list);
        void UpdateThemeTrends(bool IsTrending, int ThemeID);
    }
}
