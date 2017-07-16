using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DeveloperForest.Model;
namespace DevForest.Models
{
    public class LoginModel:Base
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string contact { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}