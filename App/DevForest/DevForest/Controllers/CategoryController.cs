using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevForest.Models;

namespace DevForest.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category()
        {
            return View();
        }

        public ActionResult InsertCategory(CategoryModel model)
        {
            CategoryHelper obj = new CategoryHelper();
            int result = obj.InsertCategory(model);
            if (result > 0)
            {
                return RedirectToAction("Category");
            }
            return View();
        }

        public ActionResult SubCategory()
        {

            return View();
        }
        public ActionResult InsertSubCategory(CategoryModel model)
        {
            CategoryHelper obj = new CategoryHelper();
            int result=obj.InsertSubCategory(model);
            if (result > 0)
            {
                return RedirectToAction("SubCategory");
            }
            return View();
        }
    }
}