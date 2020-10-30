using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class OrderDetailModel
    {
        public int ChiTietDonDatHangID { get; set; }
        public int SanPhamID { get; set; }
        public int SL { get; set; }
        public float DonGia { get; set; }
        public int DonDatHangID { get; set; }
        public DateTime NgayDat { get; set; }
    }
}
