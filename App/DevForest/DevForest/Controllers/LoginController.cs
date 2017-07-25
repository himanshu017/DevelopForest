using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeveloperForest.Model;
using DeveloperForest.BLL;
using DevForest.Models;

namespace DevForest.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            ViewBag.Status = "success";
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public JsonResult ResetCode(string Mail)
        {
            DeveloperForest.BLL.Login obj = new DeveloperForest.BLL.Login();
            obj.ForgetPassword(Mail);
            return Json(true, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ValidateUser(LoginModel model)
        {
            LoginHelper obj = new LoginHelper();
            string result = obj.ValidateLogin(model);
            if (result != "2")
            {

                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                ViewBag.Status = "Invalid Username or Password";
                return View("Login");
            }
        }

        [AllowAnonymous]
        public ActionResult LogOff(string returnUrl)
        {
            LoginHelper obj = new LoginHelper();
            obj.SignOut();

            if (returnUrl != null && returnUrl != "")
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
    }


}