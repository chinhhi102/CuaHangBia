namespace DataLibrary.Models.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Users
    {
        [Key]
        [Column(Order = 0)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public int Role { get; set; }
    }
}
