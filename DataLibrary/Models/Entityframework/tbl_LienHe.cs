namespace DataLibrary.Models.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_LienHe
    {
        [Key]
        public int LienHeID { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        public string LoiNhan { get; set; }

        public int? TrangThai { get; set; }
    }
}
