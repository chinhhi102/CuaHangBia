namespace DataLibrary.Models.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SanPham
    {
        [Key]
        public int SanPhamID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSP { get; set; }

        [Required]
        public string Mota { get; set; }

        public int LoaiSPID { get; set; }

        public int DiaChiID { get; set; }

        public double DonGia { get; set; }

        [StringLength(250)]
        public string ImagePath { get; set; }
    }
}
