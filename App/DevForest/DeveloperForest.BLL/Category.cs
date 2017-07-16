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

        public int InsertSubCategory(CategoryModel model)
        {
            ICategoryDAL obj = new CategoryDAL();
            return obj.InsertSubCategory(model);
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
    }
}
