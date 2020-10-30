namespace DataLibrary.Models.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_DiaChiNhanHang
    {
        [Key]
        public int DiaChiNhanHangID { get; set; }

        [StringLength(50)]
        public string Huyen { get; set; }

        [StringLength(50)]
        public string Tinh { get; set; }

        public int? UserID { get; set; }
    }
}
