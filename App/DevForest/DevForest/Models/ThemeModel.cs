using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperForest.Model;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace DevForest.Models
{
    public class ThemeModel : Base
    {
        public int ThemeId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SubCategoryId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required(ErrorMessage="The Image field is required")]
        public HttpPostedFileBase ImageName { get; set; }

        [Required(ErrorMessage = "The Image field is required")]
        public HttpPostedFileBase ThumbImageName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Downloadlink { get; set; }

        [Required]
        public string DemoLink { get; set; }
        public SelectList CategoryList { get; set; }
        public SelectList SubCategoryList { get; set; }

        public string PreImageName { get; set; }

        public string RelatedLink1 { get; set; }
        public string RelatedLink2 { get; set; }
        public string RelatedLink3 { get; set; }
        public string RelatedLink4 { get; set; }
        public string RelatedLink5 { get; set; }
    }
}