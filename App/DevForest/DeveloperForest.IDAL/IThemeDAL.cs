using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperForest.Model;

namespace DeveloperForest.IDAL
{
    public interface IThemeDAL
    {
        int InsertTheme(ThemeModel model);

        List<ThemeModel> ThemeList();

        string DeleteThemeById(int id);
    }
}
