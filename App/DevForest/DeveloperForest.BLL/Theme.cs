using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperForest.DAL;
using DeveloperForest.IDAL;
using DeveloperForest.Model;

namespace DeveloperForest.BLL
{
    public class Theme
    {
        public int InsertTheme(ThemeModel model)
        {
            IThemeDAL obj = new ThemeDAL();
            return obj.InsertTheme(model);
        }

        public List<ThemeModel> GetThemes()
        {
            IThemeDAL obDll = new ThemeDAL();
            return obDll.ThemeList();
        }
        public string DeleteThemeById(int id)
        {
            IThemeDAL obj = new ThemeDAL();
            return obj.DeleteThemeById(id);
        }
    }
}
