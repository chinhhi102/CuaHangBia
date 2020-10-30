using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DacSan.Areas.Guest.Models
{
    public class LienHeModel
    {
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Bạn cần phải nhập tên của mình")]
        public string HoTen { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Bạn cần phải nhập email")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Bạn cần phải nhập số điện thoại")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string SDT { get; set; }

        [Display(Name = "Lời nhắn")]
        [Required(ErrorMessage = "Bạn cần phải viết lời nhắn")]
        [DataType(DataType.MultilineText)]
        [StringLength(255, ErrorMessage = "Số ký tự phải lớn hơn 10", MinimumLength = 10)]
        public string LoiNhan { get; set; }
    }
}