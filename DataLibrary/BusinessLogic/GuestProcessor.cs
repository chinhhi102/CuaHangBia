using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Models;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class GuestProcessor
    {
        public static List<GuestModel> LoadGuest()
        {
            string sql = @"SELECT * FROM dbo.tbl_KhachHang";
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.LoadData<GuestModel>(sql);
        }
        public static List<GuestModel> LoadGuest(int num)
        {
            string sql = String.Format("SELECT TOP ({0}) * FROM dbo.tbl_KhachHang", num);
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.LoadData<GuestModel>(sql);
        }
        public static GuestModel LoadOneGuest(int id)
        {
            string sql = String.Format("SELECT TOP (1) * FROM dbo.tbl_KhachHang WHERE KhachHangID = {0}", id);
            System.Diagnostics.Debug.WriteLine(sql);
            List<GuestModel> order = SqlDataAccess.LoadData<GuestModel>(sql);
            if (order.Count > 0)
            {
                return order[0];
            }
            else
            {
                return null;
            }
        }
        public static int CreateGuest(string _HoTen, string _Email, string _SDT, string _SoNha, string _Duong, string _Xa, string _Tinh, string _Huyen)
        {
            GuestModel data = new GuestModel
            {
                HoTen = _HoTen, 
                Email = _Email,
                SDT = _SDT, 
                SoNha = _SoNha, 
                Duong = _Duong, 
                Xa = _Xa, 
                Tinh = _Tinh, 
                huyen = _Huyen
            };
            string sql = @"insert into dbo.tbl_KhachHang (HoTen, Email, SDT, SoNha, Duong, Xa, Tinh, huyen)
                            values(@HoTen, @Email, @SDT, @SoNha, @Duong, @Xa, @Tinh, @huyen)";
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
