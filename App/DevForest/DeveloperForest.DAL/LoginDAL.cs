using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperForest.IDAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Web.Security;
using System.Web;
using System.Security.Cryptography;

namespace DeveloperForest.DAL
{
    public class LoginDAL : ILoginDAL
    {
        public static string config = ConfigurationManager.ConnectionStrings["connStr"].ToString();
        string ILoginDAL.ForgetPassword(string Email)
        {
            byte[] saltBytes = new byte[8];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(saltBytes);
            string ConfirmPwd = "test@123", ResetCode="";
            string PasswordHash = ENCDEC.ComputeHash(ConfirmPwd, "MD5", saltBytes);
            string PasswordSalt = Convert.ToBase64String(saltBytes);

            bool value = ChangeFogortPassword(Email, ResetCode, PasswordHash, PasswordSalt);
            if (value)
                return "success";
            else
                return "error";

        }

        string ILoginDAL.ValidateLogin(string email, string password)
        {
            Database db = new SqlDatabase(config);
            DbCommand dbCommand = db.GetStoredProcCommand("spValidateLogin");

            db.AddInParameter(dbCommand, "email", DbType.String, email);

            string result = "";

            using (IDataReader reader = db.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    if (reader["Status"].ToString() == "1")
                    {
                        if (reader["passwordSalt"] != DBNull.Value)
                        {
                            byte[] saltBytes = new byte[8];

                            saltBytes = Convert.FromBase64String(reader["passwordSalt"].ToString());

                            if (ENCDEC.ComputeHash(password, "MD5", saltBytes) == reader["passwordHash"].ToString())
                            {
                                bool RememberMe = false;
                                SignIn(reader["UserID"].ToString(), reader["Name"].ToString(), reader["UserType"].ToString(), reader["Imagename"].ToString(), reader["AgencyLogo"].ToString(), RememberMe);
                                result = reader["UserType"].ToString();
                            }
                            else
                            {
                                result = "2";
                            }
                        }
                    }
                    else
                    {
                        result = "2";
                    }
                }
            }
            return result;
        }

        
       

        #region FormAuth
        public void SignIn(string UserID, string userName, string Usertype, string Imagename, string AgencyLogo, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);

            DateTime expiration = DateTime.Now.AddMinutes(30);
            expiration = DateTime.Now.AddMonths(1);
            String strCookie = "";
            strCookie = UserID + "," + userName + "," + Usertype + ","  + Imagename + "," + AgencyLogo;
            FormsAuthenticationTicket tk = new FormsAuthenticationTicket(1, userName, DateTime.Now, expiration, createPersistentCookie, strCookie, "/");
            String st = FormsAuthentication.Encrypt(tk);
            HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName, st);
            HttpContext.Current.Response.Cookies.Add(ck);
        }
        public void SignOut()
        {
            FormsAuthentication.SignOut();
            // HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
        }

        #endregion


        #region ForgotPWD
        public bool CheckEmail(string email, string Code)
        {
            Database db = new SqlDatabase(config);
            DbCommand dbCommand = db.GetStoredProcCommand("spCheckEmail");

            db.AddInParameter(dbCommand, "EMAIL", DbType.String, email);
            db.AddInParameter(dbCommand, "Code", DbType.String, Code);
            String str = db.ExecuteScalar(dbCommand).ToString();
            if (str == "1")
            {
                return true;
            }
            else
                return false;
        }

        public bool ChangeFogortPassword(string email, string Code, string pwdHash, string PwdSalt)
        {
            Database db = new SqlDatabase(config);
            DbCommand dbCommand = db.GetStoredProcCommand("spChangeFogortPassword");
            db.AddInParameter(dbCommand, "EMAIL", DbType.String, email);
            //db.AddInParameter(dbCommand, "Code", DbType.String, Code);
            db.AddInParameter(dbCommand, "PasswordHash", DbType.String, pwdHash);
            db.AddInParameter(dbCommand, "PasswordSalt", DbType.String, PwdSalt);
            String str = db.ExecuteScalar(dbCommand).ToString();
            if (str == "1")
            {
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
