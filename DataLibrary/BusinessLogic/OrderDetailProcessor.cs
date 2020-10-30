using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Models;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class OrderDetailProcessor
    {
        public static List<OrderDetailModel> LoadOrderDetail()
        {
            string sql = @"SELECT * FROM dbo.tbl_ChiTietDonDatHang";
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.LoadData<OrderDetailModel>(sql);
        }
        public static List<OrderDetailModel> LoadOrderDetailByOrderID(int OrderID)
        {
            string sql = String.Format("SELECT * FROM dbo.tbl_ChiTietDonDatHang WHERE DonDatHangID = {0}", OrderID);
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.LoadData<OrderDetailModel>(sql);
        }
        public static List<OrderDetailModel> LoadOrderDetail(int num)
        {
            string sql = String.Format("SELECT TOP ({0}) * FROM dbo.tbl_ChiTietDonDatHang", num);
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.LoadData<OrderDetailModel>(sql);
        }
        public static OrderDetailModel LoadOneLoaiSP(int id)
        {
            string sql = String.Format("SELECT TOP (1) * FROM dbo.tbl_ChiTietDonDatHang WHERE ChiTietDonDatHangID = {0}", id);
            List<OrderDetailModel> orderDetail = SqlDataAccess.LoadData<OrderDetailModel>(sql);
            System.Diagnostics.Debug.WriteLine(sql);
            if (orderDetail.Count > 0)
            {
                return orderDetail[0];
            }
            else
            {
                return null;
            }
        }
        public static int CreateOrderDetail(int _SanPhamID, int _SL, float _DonGia,
            int _DonDatHangID, DateTime _NgayDat)
        {
            OrderDetailModel data = new OrderDetailModel
            {
                SanPhamID = _SanPhamID,
                SL = _SL,
                DonGia = _DonGia,
                DonDatHangID = _DonDatHangID,
                NgayDat = _NgayDat
            };
            string sql = @"insert into dbo.tbl_ChiTietDonDatHang (SanPhamID, SL, DonGia, DonDatHangID, NgayDat)
                            values(@SanPhamID, @SL, @DonGia, @DonDatHangID, @NgayDat)";
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
