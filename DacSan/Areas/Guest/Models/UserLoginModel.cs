using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DacSan.Areas.Admin.Models
{
    public class UserLoginModel
    {
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Bạn cần phải nhập tài khoản")]
        public string Username { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn cần phải nhập mật khẩu")]
        [RegularExpression("^[a-zA-Z0-9!@#$%^&*]+$", ErrorMessage = "Mật khẩu không hợp lệ")]
        public string Password { get; set; }
    }
}