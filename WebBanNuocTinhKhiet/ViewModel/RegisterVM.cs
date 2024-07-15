using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebBanNuocTinhKhiet.ViewModel
{
    public class RegisterVM
    {

        [Required(ErrorMessage = "Tên không được để trống.")]
        [RegularExpression(@"^[A-Za-z 0-9]*$", ErrorMessage = "Không thể dùng ký tự đặc biệt trong Tên")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password không được để trống.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,20}$", ErrorMessage = "Password phải chứa ít nhất một chữ cái thường, một chữ cái in hoa và một chữ số, và có độ dài từ 8 đến 15 ký tự.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfỉrmPassword không được để trống.")]
        [Compare("Password", ErrorMessage = "Nhập lại mật khẩu không đúng.")]
        public string ConfỉrmPassword { get; set; }

        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Không đúng định dạng.")]
        public string Email { get; set; }

        public string Mobile { get; set; }

    }
}