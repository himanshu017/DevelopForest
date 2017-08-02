using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperForest.Model;
using System.Text;
using DeveloperForest.BLL;
namespace Front.Models
{
    public class Header
    {
        public List<CategoryModel> MainCategories { get; set; }

        public string SubCategories(int categoryid)
        {
            Category obj = new Category();
            List<CategoryModel> list = obj.GetSubCategories();
            List<CategoryModel> childlist = list.Where(x => x.CategoryId.Equals(categoryid)).ToList();
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul class=\"subnav__box\">");
            for (int i = 0; i < childlist.Count; i++)
            {
                sb.Append("<li class=\"subnav__list hoverdropdownlik\">");
                sb.Append("<a class=\"subnav__link\" href=\"javascript: void(0)\" data-parentid=\"" + categoryid + "\" data-id=\"" + childlist[i].SubCategoryId + "\">" + childlist[i].SubCategoryName + "</a>");
                sb.Append(" </li>");
            }

            sb.Append("</ul>");


            return sb.ToString();
        }

        public CategoryModel SubCategoriesByID(int categoryid)
        {
            Category obj = new Category();
            List<CategoryModel> list = obj.GetSubCategories();
            List<CategoryModel> childlist = list.Where(x => x.CategoryId.Equals(categoryid)).ToList();
            CategoryModel model = new CategoryModel();
            if (childlist.Count > 0)
            {
                model.CategoryName = childlist[0].CategoryName;
                model.CategoryId = childlist[0].CategoryId;
            }
            model.ModelList = childlist;
            return model;
        }

    }
}