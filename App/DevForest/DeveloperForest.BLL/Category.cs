using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperForest.IDAL;
using DeveloperForest.DAL;
using DeveloperForest.Model;

namespace DeveloperForest.BLL
{
    public class Category
    {
        public int InsertCategory(CategoryModel model)
        {
            IDAL.ICategoryDAL obj = new CategoryDAL();
            return obj.InsertCategory(model);
        }


        public List<CategoryModel> GetCategories()
        {
            ICategoryDAL obj = new CategoryDAL();
            return obj.CategoryList();
        }
        public int DeleteCategory(int CategoryID)
        {
            ICategoryDAL obj = new CategoryDAL();
            return obj.DeleteCategory(CategoryID);
        }

        public int InsertSubCategory(CategoryModel model)
        {
            ICategoryDAL obj = new CategoryDAL();
            return obj.InsertSubCategory(model);
        }
        public List<CategoryModel> GetSubCategories()
        {
            ICategoryDAL obj = new CategoryDAL();
            return obj.SubCategoryList();
        }
        public int DeleteSubCategory(int SubCategoryID)
        {
            ICategoryDAL obj = new CategoryDAL();
            return obj.DeleteSubCategory(SubCategoryID);
        }

        public bool UpdateCategoryIndex(List<CategoryModel> list)
        {
            IDAL.ICategoryDAL obj = new CategoryDAL();
            for (Int16 i = 0; i < list.Count; i++)
            {
                int j = i;
                CategoryModel model = new CategoryModel();
                model.CategoryId = list[i].CategoryId;
                model.CurrentIndex = Convert.ToInt16(j + 1);
                obj.UpdateCategoryIndex(model);
            }
            return true;
        }

        public void UpdateThemeTrends(bool IsTrending, int ThemeID)
        {
            ICategoryDAL obj = new CategoryDAL();
            obj.UpdateThemeTrends(IsTrending, ThemeID);
        }
    }
}
