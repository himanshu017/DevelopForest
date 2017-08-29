using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevForest.Models;
using System.IO;
namespace DevForest.Controllers
{
    public class ThemeController : Controller
    {
        ThemeHelper obj = new ThemeHelper();
        //
        // GET: /Theme/
        public ActionResult Theme()
        {
            CategoryHelper obj = new CategoryHelper();
            ThemeModel ob = new ThemeModel();
            ob.CategoryList = new SelectList(obj.GetCategories(), "CategoryId", "CategoryName");
            return View(ob);
        }
        [HttpPost]
        public ActionResult GetSubCategories(int id)
        {
            CategoryHelper obj = new CategoryHelper();
            var subCategory = obj.GetSubCategories().Where(x => x.CategoryId == id).ToList();
            return Json(subCategory, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult InsertTheme(ThemeModel model)
        {
            string fileName = "";
            if (string.IsNullOrEmpty(model.PreImageName))
            {
                Guid g = Guid.NewGuid();
                 fileName = g.ToString() + ".jpg";
            }
            else
            fileName = model.PreImageName;

            var image = Path.Combine(Server.MapPath("~/Upload/"), fileName);
            model.ImageName.SaveAs(image);
            var ThumbnailImage = Path.Combine(Server.MapPath("~/Upload/Thumbnail/"), fileName);
            model.ImageName.SaveAs(ThumbnailImage);
            obj.InsertTheme(model, fileName);
            return RedirectToAction("ThemeList");
        }

        public ActionResult ThemeList()
        {
            return View();
        }
        public JsonResult GetThemes(string order, int limit = 0, int offset = 0, string search = null, string sort = null)
        {
            try
            {
                ThemeHelper obj = new ThemeHelper();
                int count = 0;
                var Main = obj.GetThemes();
                if (!string.IsNullOrWhiteSpace(search))
                {

                    List<DeveloperForest.Model.ThemeModel> li = Main.Where(x => x.CategoryName.ToUpper().Contains(search.ToUpper())).ToList();
                    count = li.Count;
                    li = li.OrderBy(s => s.CategoryName).Skip(offset).Take(limit == 0 ? count : limit).ToList();
                    return Json(new { rows = li });
                }
                else
                {
                    count = Main.Count;
                    List<DeveloperForest.Model.ThemeModel> li = Main;
                    List<DeveloperForest.Model.ThemeModel> li2 = new List<DeveloperForest.Model.ThemeModel>();
                    if (sort != null)
                    {
                        var param = sort;
                        var propertyInfo = typeof(DeveloperForest.Model.ThemeModel).GetProperty(param);

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
                        li2 = li.OrderBy(x => x.ThemeId).Skip(offset).Take(limit == 0 ? count : limit).ToList();
                    }

                    return Json(new { total = count, rows = li2 });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult GetThemeById(int ThemeId)
        {
            ThemeHelper obj = new ThemeHelper();
            return Json(obj.GetThemes(ThemeId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteThemeByID(int ThemeId)
        {
            string res = obj.DeleteThemeById(ThemeId);
            string Imagepath = Server.MapPath("~/upload/" + res);
            string ThumbanailPath = Server.MapPath("~/upload/Thumbnail/" + res);
            if (System.IO.File.Exists(Imagepath))
            {
                System.IO.File.Delete(Imagepath);
            }
            if (System.IO.File.Exists(ThumbanailPath))
            {
                System.IO.File.Delete(ThumbanailPath);
            }
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateThemeTrends(bool IsTrend,int ThemeID)
        {
            DeveloperForest.BLL.Category obj = new DeveloperForest.BLL.Category();

            obj.UpdateThemeTrends(IsTrend,ThemeID);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}