using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperForest.IDAL
{
    public interface ILoginDAL
    {
        string ValidateLogin(string email, string password);
        string ForgetPassword(string Email);
    }
}
