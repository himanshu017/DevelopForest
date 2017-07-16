using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DeveloperForest.BLL;
using DeveloperForest;
using System.Web.Security;

namespace DevForest.Models
{
    public class LoginHelper
    {
       public string ValidateLogin(LoginModel model)
        {
            Login objBLL = new Login();
            return objBLL.ValidateLogin(model.Email,model.Password);
        }
        public void SignOut()
        {
            FormsAuthentication.SignOut();
            // HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
        }
    }
}