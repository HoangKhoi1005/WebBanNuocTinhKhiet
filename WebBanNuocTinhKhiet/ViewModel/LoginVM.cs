using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanNuocTinhKhiet.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Tên không được để trống.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password không được để trống.")]
        public string Password { get; set; }
    }
}