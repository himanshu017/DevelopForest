using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperForest.Model
{
    public class CategoryModel : Base
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int SubCategoryId { get; set; }

        public string SubCategoryName { get; set; }

        public string CSSClass { get; set; }

        public Int16 CurrentIndex { get; set; }

        public List<CategoryModel> ModelList{ get; set; }
}
}
