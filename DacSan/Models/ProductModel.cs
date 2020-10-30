using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.Models;
using static DataLibrary.BusinessLogic.LoaiSPProcessor;

namespace DacSan.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Bạn cần phải nhập tên sản phẩm")]
        public string TenSP { get; set; }

        [Display(Name = "Mô tả sản phẩm")]
        [Required(ErrorMessage = "Bạn cần phải nhập mô tả sản phẩm")]
        [MinLength(50, ErrorMessage = "Mô tả phải chứa ít nhất phải chứa ít nhất 50 kí tự")]
        [DataType(DataType.MultilineText)]
        public string MoTa { get; set; }

        [Display(Name = "Loại sản phẩm")]
        public int LoaiSPID { get; set; }

        [Display(Name = "Xuất xứ")]
        public int DiaChiID { get; set; }

        [Display(Name = "Đơn giá (VNĐ): ")]
        [DisplayFormat(DataFormatString= "{0:C}")]
        public float DonGia { get; set; }
        public int ImagesID { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        [Display(Name = "Upload File")]
        public string ImagePath { get; set; }
        public ProductModel() { }
        public ProductModel(DataLibrary.Models.ProductModel product)
        {
            this.ProductID = product.SanPhamID;
            this.TenSP = product.TenSP;
            this.MoTa = product.MoTa;
            this.LoaiSPID = product.LoaiSPID;
            this.DiaChiID = product.DiaChiID;
            this.DonGia = product.DonGia;
            this.ImagePath = product.ImagePath;
        }

    }
}