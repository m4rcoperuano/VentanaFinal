using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VentanaFinal.Models.Account
{
    public class RegisterModel
    {
        [Email]
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "Passwords do not match")]
        public string Password { get; set; }

        [Required]
        [Display(Name="Password Again")]
        public string ConfirmPassword { get; set; }
    }
}