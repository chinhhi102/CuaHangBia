namespace DataLibrary.Models.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Images
    {
        [Key]
        public int ImageID { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        public string ImagePath { get; set; }
    }
}
