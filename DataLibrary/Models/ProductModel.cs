using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLibrary.Models
{
    public class ProductModel
    {
        public int SanPhamID { get; set; }
        public string TenSP { get; set; }
        public string MoTa { get; set; }
        public int LoaiSPID { get; set; }
        public int DiaChiID { get; set; }
        public float DonGia { get; set; }
        public string ImagePath { get; set; }
    }
}