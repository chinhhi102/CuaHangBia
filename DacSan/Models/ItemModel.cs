using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DacSan.Models
{
    public class ItemModel
    {
        public ProductModel Product { get; set; }
        public int SL { get; set; }
        public DateTime NgayThem { get; set; }
    }
}