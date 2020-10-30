namespace DataLibrary.Models.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_KhuyenMai
    {
        [Key]
        public int KhuyenMaiID { get; set; }

        public int? SanPhamID { get; set; }

        [Required]
        public string Mota { get; set; }

        public double GiaGiam { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKT { get; set; }
    }
}
