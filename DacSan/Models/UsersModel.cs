using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DataLibrary.Models;

namespace DacSan.Models
{
    public class UsersModel
    {
        public int UserID { get; set; }
        
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage ="Bạn cần phải nhập tài khoản")]
        public string Username { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Mật khẩu ít nhất phải chứa ít nhất 5 kí tự", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9!@#$%^&*]+$", ErrorMessage = "Mật khẩu không hợp lệ")]
        public string Password { get; set; }

        [Display(Name = "Nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Bạn cần phải nhập tên")]
        public string FirstName { get; set; }

        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Bạn cần phải nhập họ")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Bạn cần phải nhập email")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Email không hợp lệ")]
        public string EmailAddress { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Bạn cần phải nhập số điện thoại")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }
        public int Role { get; set; }
        public UsersModel(DataLibrary.Models.UsersModel _user)
        {
            this.UserID = _user.UserID;
            this.Username = _user.Username;
            this.Password = _user.Password;
            this.FirstName = _user.FirstName;
            this.LastName = _user.LastName;
            this.EmailAddress = _user.EmailAddress;
            this.PhoneNumber = _user.PhoneNumber;
        }

        public UsersModel() { }
    }
}