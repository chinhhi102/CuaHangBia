namespace DataLibrary.Models.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_DiaChi
    {
        [Key]
        public int DiaChiID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTinh { get; set; }
    }
}
