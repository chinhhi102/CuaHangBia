using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Models;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class OrderProcessor
    {
        public static List<OrderModel> LoadOrder()
        {
            string sql = @"SELECT * FROM dbo.tbl_DonDatHang";
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.LoadData<OrderModel>(sql);
        }
        public static List<OrderModel> LoadOrder(int num)
        {
            string sql = String.Format("SELECT TOP ({0}) * FROM dbo.tbl_DonDatHang", num);
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.LoadData<OrderModel>(sql);
        }
        public static OrderModel LoadOneOder(int id)
        {
            string sql = String.Format("SELECT TOP (1) * FROM dbo.tbl_DonDatHang WHERE DonDatHangID = {0}", id);
            List<OrderModel> order = SqlDataAccess.LoadData<OrderModel>(sql);
            System.Diagnostics.Debug.WriteLine(sql);
            if (order.Count > 0)
            {
                return order[0];
            }
            else
            {
                return null;
            }
        }
        public static int DeleteOrder(int DonDatHangID)
        {
            string sql = String.Format("DELETE FROM dbo.tbl_DonDatHang WHERE DonDatHangID = {0}", DonDatHangID);
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.DeleteData(sql);
        }
        public static int CreateOrder(int _KhachHangID, int _LoaiKhachHang, int _TrangThai)
        {
            OrderModel data = new OrderModel
            {
                KhachHangID = _KhachHangID,
                LoaiKhachHang = _LoaiKhachHang,
                TrangThai = _TrangThai
            };
            string sql = @"insert into dbo.tbl_DonDatHang (KhachHangID, LoaiKhachHang, TrangThai)
                            values(@KhachHangID, @LoaiKhachHang, @TrangThai)";
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
