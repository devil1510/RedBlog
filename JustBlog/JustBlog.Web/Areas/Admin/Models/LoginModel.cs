using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JustBlog.Web.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required.")]
        [Display(Name = "User Name(*)")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password(*)")]
        public string Password { get; set; }
    }
}