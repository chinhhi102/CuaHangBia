namespace DataLibrary.Models.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ChiTietGioHang
    {
        [Key]
        public int ChiTietGioHangID { get; set; }

        public int? SanPhamID { get; set; }

        public int? SL { get; set; }

        public double? DonGia { get; set; }

        public int GioHangID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThem { get; set; }
    }
}
