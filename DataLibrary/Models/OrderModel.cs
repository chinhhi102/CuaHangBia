using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class OrderModel
    {
        public int DonDatHangID { get; set; }
        public int KhachHangID { get; set; }
        public int LoaiKhachHang { get; set; }
        public int TrangThai { get; set; }
    }
}
