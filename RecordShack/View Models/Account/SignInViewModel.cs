using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordShack.Models;

namespace RecordShack.View_Models.Account
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "User Name is required")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be longer than 8 characters")]
        [DataType("Password")]
        public string Password { get; set; }
            
        [Display(Name = "Remember Me?")]
        public bool RemeberMe { get; set; }
    }
}