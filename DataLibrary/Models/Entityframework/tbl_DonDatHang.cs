namespace DataLibrary.Models.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_DonDatHang
    {
        [Key]
        public int DonDatHangID { get; set; }

        public int KhachHangID { get; set; }

        public int? LoaiKhachHang { get; set; }

        public int? TrangThai { get; set; }
    }
}
