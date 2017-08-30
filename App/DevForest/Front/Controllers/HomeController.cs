using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeveloperForest.BLL;
using DeveloperForest.Model;
using Front.Models;
namespace Front.Controllers
{
    public class HomeController : Controller
    {
        ThemeList obj = new ThemeList();
        ThemeModel model = new ThemeModel();
        public ActionResult Index(Header model)
        {
            Category objbll = new Category();
            List<CategoryModel> ob = objbll.GetCategories();
            model.MainCategories = ob;
            return View(model);
        }
        [HttpPost]
        public ActionResult GETSubCategoriesMenu(int? categoryid)
        
        {
            Header obj = new Header();
            DeveloperForest.Model.CategoryModel model = new DeveloperForest.Model.CategoryModel();
            model = obj.SubCategoriesByID(categoryid);

            return PartialView(@"~/Views/Shared/_SubCategories.cshtml", model);
        }

        [HttpPost]
        public ActionResult GetThemeLatest(int SubCategoryId)
        {
            model = obj.ThemeLatestById(SubCategoryId);
            return PartialView(@"~/Views/Shared/_ThemesLatest.cshtml", model);
        }

        [HttpPost]
        public ActionResult GetThemeTrending(int SubCategoryId)
        {
            model = obj.ThemeTrendingById(SubCategoryId);
            return PartialView(@"~/Views/Shared/_ThemeTrending.cshtml", model);
        }
        [HttpPost]
        public ActionResult GetThemeRelated(int SubCategoryId)
        {
            model = obj.ThemeRelatedById(SubCategoryId);
            return PartialView(@"~/Views/Shared/_ThemeRelated.cshtml", model);
        }
        public ActionResult ThemeDetails(int ThemeId)
        {
            model = obj.GetThemeById(ThemeId);
            return View(model);
        }
    }
}