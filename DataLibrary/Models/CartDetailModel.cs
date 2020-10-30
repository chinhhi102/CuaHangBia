using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class CartDetailModel
    {
        public int ChiTietGioHangID { get; set; }
        public int SanPhamID { get; set; }
        public int SL { get; set; }
        public float DonGia { get; set; }
        public int GioHangID { get; set; }
        public DateTime NgayThem { get; set; }
    }
}
