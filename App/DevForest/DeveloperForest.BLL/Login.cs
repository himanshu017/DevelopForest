using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperForest.IDAL;
using DeveloperForest.DAL;

namespace DeveloperForest.BLL
{
   public class Login
    {
        public string ForgetPassword(string Email)
        {
            IDAL.ILoginDAL obj = new DAL.LoginDAL();
           return obj.ForgetPassword(Email);
        }

        public string ValidateLogin(string Email,string Password)
        {
            IDAL.ILoginDAL obj = new DAL.LoginDAL();
            return obj.ValidateLogin(Email,Password);
        }
    }
}
