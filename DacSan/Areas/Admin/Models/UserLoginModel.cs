using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DacSan.Areas.Guest.Models
{
    public class UserLoginModel
    {
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Bạn cần phải nhập tài khoản")]
        public string Username { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn cần phải nhập mật khẩu")]
        public string Password { get; set; }
    }
}