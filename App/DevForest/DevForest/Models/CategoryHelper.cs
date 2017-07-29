using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperForest.BLL;
using DeveloperForest.Model;

namespace DevForest.Models
{
    public class CategoryHelper
    {
        public int InsertCategory(CategoryModel model)
        {
            DeveloperForest.Model.CategoryModel ob = new DeveloperForest.Model.CategoryModel();
            ob.CategoryName = model.CategoryName;
            ob.CategoryId = model.CategoryId;
            ob.CreatedBy = model.CreatedBy;
            ob.ModifiedBy = model.ModifiedBy;
            ob.CSSClass = model.CSSClass;
            Category objBll = new Category();
            return objBll.InsertCategory(ob);
        }

        public int InsertSubCategory(CategoryModel model)
        {
            DeveloperForest.Model.CategoryModel ob = new DeveloperForest.Model.CategoryModel();
            ob.SubCategoryName = model.SubCategoryName;
            ob.SubCategoryId = model.SubCategoryId;
            ob.CategoryId = model.CategoryId;
            ob.CreatedBy = model.CreatedBy;
            ob.ModifiedBy = model.ModifiedBy;
            Category objBLL = new Category();
            return objBLL.InsertSubCategory(ob);
        }

        public List<DeveloperForest.Model.CategoryModel> GetCategories()
        {
            Category objBll = new Category();
            return objBll.GetCategories();
        }

        public int DeleteCategoryByID(int CategoryID)
        {
            Category objBll = new Category();
            return objBll.DeleteCategory(CategoryID);
        }
        public List<DeveloperForest.Model.CategoryModel> GetSubCategories()
        {
            Category objBll = new Category();
            return objBll.GetSubCategories();
        }
        public int DeleteSubCategoryByID(int SubCategoryID)
        {
            Category objBll = new Category();
            return objBll.DeleteSubCategory(SubCategoryID);
        }
    }
}