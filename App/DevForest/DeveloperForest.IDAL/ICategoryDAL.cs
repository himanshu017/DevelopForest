using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperForest.Model;

namespace DeveloperForest.IDAL
{
    public interface ICategoryDAL
    {
        int InsertCategory(CategoryModel model);
        int InsertSubCategory(CategoryModel model);

        CategoryModel CategoryList();
    }
}
