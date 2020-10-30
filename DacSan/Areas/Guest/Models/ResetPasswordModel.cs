using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DacSan.Areas.Admin.Models
{
    public class ResetPasswordModel
    {   
        [Display(Name = "Mật khẩu cũ")]
        [Required(ErrorMessage = "Bạn cần phải nhập mật khẩu")]
        public string OldPassword { get; set; }

        [Display(Name = "Mật khẩu mới")]
        [Required(ErrorMessage = "Bạn cần phải nhập mật khẩu mới")]
        [RegularExpression("^[a-zA-Z0-9!@#$%^&*]+$", ErrorMessage = "Mật khẩu không hợp lệ")]
        public string NewPassword { get; set; }

        [Display(Name = "Nhập lại mật khẩu mới")]
        [Compare("NewPassword", ErrorMessage = "Bạn cần phải nhập lại mật khẩu mới")]
        [RegularExpression("^[a-zA-Z0-9!@#$%^&*]+$", ErrorMessage = "Mật khẩu không hợp lệ")]
        public string ConfigNewPassword { get; set; }
    }
}