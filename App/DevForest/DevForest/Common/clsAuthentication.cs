using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DevForest.Common
{
    public class clsAuthentication
    {
        public bool UserIsAuthenticated
        {
            get;
            set;
        }
        public Int32 UserID
        {
            get;
            set;
        }
        public String UserName
        {
            get;
            set;
        }
        public String RoleName
        {
            get;
            set;
        }
        public string LoggedAgencyID
        {
            get;
            set;
        }
        public string LoggedAgencyName
        {
            get;
            set;
        }
        public string LoggedUserImage
        {
            get;
            set;
        }
        public string LoggedAgencyLogo
        {
            get;
            set;
        }
        public void CheckAuthentication()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.User.IsInRole("Admin") || HttpContext.Current.User.IsInRole("AgencyOwner") || HttpContext.Current.User.IsInRole("AgencyManager") || HttpContext.Current.User.IsInRole("UnitManager") || HttpContext.Current.User.IsInRole("SaleAgent"))
                {
                    FormsIdentity id = (FormsIdentity)(HttpContext.Current.User.Identity);
                    string s = id.Ticket.UserData;
                    string[] r = s.Split(',');
                    if (r.Length == 5)
                    {
                        UserID = int.Parse(r[0].ToString());
                        UserName = r[1].ToString();
                        RoleName = r[2].ToString();
                        //LoggedAgencyID = r[3].ToString();
                       // LoggedAgencyName = r[4].ToString();
                        UserID = r[0].ToString().Trim() == "" ? 0 : int.Parse(r[0].ToString());
                        LoggedUserImage = r[3].ToString();
                        LoggedAgencyLogo = r[4].ToString();
                        UserIsAuthenticated = true;

                    }
                }
                else
                {
                    UserIsAuthenticated = false;
                    HttpContext.Current.Session.Abandon();
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
            else
            {
                UserIsAuthenticated = false;
                HttpContext.Current.Session.Abandon();
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}