using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DeveloperForest.Model;
using System.Web.Mvc;
namespace DevForest.Models
{
    public class CategoryModel : Base
    {
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public int SubCategoryId { get; set; }

        [Required]
        public string SubCategoryName { get; set; }

        public SelectList CategoryList { get; set; }  
    }
}