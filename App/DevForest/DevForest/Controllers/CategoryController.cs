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
        [HttpPost]
        [AllowAnonymous]
        public ActionResult InsertCategory(CategoryModel model)
        {
            CategoryHelper obj = new CategoryHelper();
            int result = obj.InsertCategory(model);
            return Json(result.ToString(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult DeleteCategoryByID(int CategoryID)
        {
            CategoryHelper obj = new CategoryHelper();

            int res = obj.DeleteCategoryByID(CategoryID);

            return Json(res,JsonRequestBehavior.AllowGet);
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

        public JsonResult GetCategories(string order, int limit = 0, int offset = 0, string search = null, string sort = null)
        {
            try
            {
                CategoryHelper obj = new CategoryHelper();
                int count = 0;
                var Main = obj.GetCategories();
                if (!string.IsNullOrWhiteSpace(search))
                {

                    List<DeveloperForest.Model.CategoryModel> li = Main.Where(x => x.CategoryName.ToUpper().Contains(search.ToUpper())).ToList();
                    count = li.Count;
                    li = li.OrderBy(s => s.CategoryName).Skip(offset).Take(limit == 0 ? count : limit).ToList();
                    return Json(new { rows = li });
                }
                else
                {
                    count = Main.Count;
                    List<DeveloperForest.Model.CategoryModel> li = Main;
                    List<DeveloperForest.Model.CategoryModel> li2 = new List<DeveloperForest.Model.CategoryModel>();
                    if (sort != null)
                    {
                        var param = sort;
                        var propertyInfo = typeof(DeveloperForest.Model.CategoryModel).GetProperty(param);

                        if (order == "asc")
                        {
                            li2 = li.OrderBy(x => propertyInfo.GetValue(x, null)).Skip(offset).Take(limit == 0 ? count : limit).ToList();
                        }
                        else
                        {
                            li2 = li.OrderByDescending(x => propertyInfo.GetValue(x, null)).Skip(offset).Take(limit == 0 ? count : limit).ToList();
                        }
                    }
                    else
                    {
                        li2 = li.OrderBy(x => x.CategoryName).Skip(offset).Take(limit == 0 ? count : limit).ToList();
                    }

                    return Json(new { total = count, rows = li2 });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}