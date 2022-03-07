using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DellyShop.Domain.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        //[Display(Name = "Şifre")]
        public string Password { get; set; }

        //[Display(Name = "Beni hatırla?")]
        public bool RememberMe { get; set; }
    }
}
