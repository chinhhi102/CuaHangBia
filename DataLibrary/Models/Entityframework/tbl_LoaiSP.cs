namespace DataLibrary.Models.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_LoaiSP
    {
        [Key]
        public int LoaiSPID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenLoaiSP { get; set; }
    }
}
