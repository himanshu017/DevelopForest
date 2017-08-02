﻿using System;
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
        public ActionResult Index(Header model)
        {
            Category objbll = new Category();
            List<CategoryModel> ob = objbll.GetCategories();
            model.MainCategories = ob;
            return View(model);
        }
        [HttpPost]
        public ActionResult GETSubCategoriesMenu(int categoryid)
        {
            Header obj = new Header();
            DeveloperForest.Model.CategoryModel model = new DeveloperForest.Model.CategoryModel();
            model = obj.SubCategoriesByID(categoryid);

            return PartialView(@"~/Views/Shared/_SubCategories.cshtml", model);
        }

        [HttpPost]
        public ActionResult GetThemeLatest(int SubCategoryId)
        {
            ThemeList obj = new ThemeList();
            ThemeModel model = new ThemeModel();
            model = obj.ThemeLatestById(SubCategoryId);
            return PartialView(@"~/Views/Shared/_ThemesLatest.cshtml", model);
        }

        [HttpPost]
        public ActionResult GetThemeTrending(int SubCategoryId)
        {
            ThemeList obj = new ThemeList();
            ThemeModel model = new ThemeModel();
            model = obj.ThemeTrendingById(SubCategoryId);
            return PartialView(@"~/Views/Shared/_ThemeTrending.cshtml", model);
        }
    }
}