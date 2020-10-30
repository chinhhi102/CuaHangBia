namespace DataLibrary.Models.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_KhachHang
    {
        [Key]
        public int KhachHangID { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(250)]
        public string SoNha { get; set; }

        [StringLength(250)]
        public string Duong { get; set; }

        [StringLength(250)]
        public string Xa { get; set; }

        [StringLength(250)]
        public string Tinh { get; set; }

        [StringLength(250)]
        public string Huyen { get; set; }
    }
}
