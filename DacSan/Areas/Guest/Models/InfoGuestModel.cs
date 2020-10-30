using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DacSan.Areas.Guest.Models
{
    public class InfoGuestModel
    {
        public int KhachHangID { get; set; }
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

        [Display(Name = "Số nhà")]
        public string SoNha { get; set; }

        [Display(Name = "Đường")]
        public string Duong { get; set; }

        [Display(Name = "Phường/Xã")]
        public string Xa { get; set; }

        [Display(Name = "Tỉnh/TP")]
        [Required(ErrorMessage = "Bạn phải ghi tỉnh/thành phố")]
        public string Tinh { get; set; }

        [Display(Name = "Quận/Huyện")]
        [Required(ErrorMessage = "Bạn phải ghi quận/huyện")]
        public string huyen { get; set; }
    }
}