using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperForest.BLL;
using DevForest.Models;

namespace DevForest.Models
{
    public class ThemeHelper
    {
        Theme objBLL = new Theme();
        public int InsertTheme(ThemeModel model, string ImageName)
        {
            DeveloperForest.Model.ThemeModel obj = new DeveloperForest.Model.ThemeModel();
            obj.ThemeId = model.ThemeId;
            obj.CategoryId = model.CategoryId;
            obj.SubCategoryId = model.SubCategoryId;
            obj.Title = model.Title;
            obj.Description = model.Description;
            obj.Downloadlink = model.Downloadlink;
            obj.DemoLink = model.DemoLink;
            obj.CreatedBy = model.UserID;
            obj.ModifiedBy = model.UserID;
            obj.ImageName = ImageName;
            return objBLL.InsertTheme(obj);
        }

        public List<DeveloperForest.Model.ThemeModel> GetThemes()
        {

            List<DeveloperForest.Model.ThemeModel> ob = objBLL.GetThemes();
            return ob;
        }
        public DeveloperForest.Model.ThemeModel GetThemes(int ThemeId)
        {
            DeveloperForest.Model.ThemeModel ob = objBLL.GetThemes().Where(x => x.ThemeId == ThemeId).FirstOrDefault();
            return ob;
        }
        public string DeleteThemeById(int id)
        {
            return objBLL.DeleteThemeById(id);
        }
    }
}