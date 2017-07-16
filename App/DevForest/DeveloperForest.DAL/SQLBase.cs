using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperForest.DAL
{
  public static  class SQLBase
    {
        public static string SQL_GET_Categories = "Select CategoryId,CategoryName from MasterCategory";
        public static string SQL_DeleteCategoriesByID = "Delete  from MasterCategory where CategoryId=@CategoryId";
    }
}
