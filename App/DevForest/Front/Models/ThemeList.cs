using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperForest.Model;
using DeveloperForest.BLL;

namespace Front.Models
{
    public class ThemeList
    {
        public ThemeModel ModelList { get; set; }
        public ThemeModel ThemeLatestById(int SubCategoryId)
        {
            Theme objBLL = new Theme();
            List<ThemeModel> list;
            if (SubCategoryId != 0)
            {
                list = objBLL.GetThemes().Where(x => x.SubCategoryId == SubCategoryId).OrderByDescending(x => x.ThemeId).Take(9).ToList();
            }
            else
            {
                list = objBLL.GetThemes().OrderByDescending(x => x.ThemeId).Take(9).ToList();
            }
            ThemeModel model = new ThemeModel();
            if (list.Count > 0)
            {
                model.ThemeId = list[0].ThemeId;
                model.Title = list[0].Title;
            }
            model.ModelList = list;
            return model;
        }

        public ThemeModel ThemeTrendingById(int SubCategoryId)
        {
            Theme objBLL = new Theme();
            List<ThemeModel> list;
            if (SubCategoryId != 0)
            {
                list = objBLL.GetThemes().Where(x => x.IsTrending == true && x.SubCategoryId==SubCategoryId).OrderByDescending(x => x.ThemeId).Take(9).ToList();
            }
            else
            {
                list = objBLL.GetThemes().Where(x => x.IsTrending == true).OrderByDescending(x => x.ThemeId).Take(9).ToList();
            }
            ThemeModel model = new ThemeModel();
            if (list.Count > 0)
            {
                model.ThemeId = list[0].ThemeId;
                model.Title = list[0].Title;
            }
            model.ModelList = list;
            return model;
        }
    }
}