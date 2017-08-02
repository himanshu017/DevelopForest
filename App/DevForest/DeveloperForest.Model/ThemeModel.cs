using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DeveloperForest.Model
{
    public class ThemeModel : Base
    {
        public int ThemeId { get; set; }
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int SubCategoryId { get; set; }

        public string SubCategoryName { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public string Downloadlink { get; set; }
        public string DemoLink { get; set; }

        public bool IsTrending { get; set; }

        public List<ThemeModel> ModelList { get; set; }
    }
}
