﻿using System;
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
            ob.CreatedBy = model.CreatedBy;
            ob.ModifiedBy = model.ModifiedBy;
            Category objBll = new Category();
            return objBll.InsertCategory(ob);
        }

        public int InsertSubCategory(CategoryModel model)
        {
            DeveloperForest.Model.CategoryModel ob = new DeveloperForest.Model.CategoryModel();
            ob.SubCategoryName = model.SubCategoryName;
            ob.CategoryId = model.CategoryId;
            ob.CreatedBy = model.CreatedBy;
            ob.ModifiedBy = model.ModifiedBy;
            Category objBLL = new Category();
            return objBLL.InsertSubCategory(ob);
        }
    }
}