namespace DataLibrary.Models.NewFolder1
{
    using System;
    using System.Web;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_TinTuc
    {
        [Key]
         public int TinTucID { get; set; }

        public string NoiDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayViet { get; set; }

        [StringLength(250)]
        public string TieuDe { get; set; }

        public string ImagePath { get; set; }
    }
    
}
