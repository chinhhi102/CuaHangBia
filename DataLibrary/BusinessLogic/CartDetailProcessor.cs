using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Models;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class CartDetailProcessor
    {
        public static List<CartDetailModel> LoadCartDetail()
        {
            string sql = @"SELECT * FROM dbo.tbl_ChiTietGioHang";
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.LoadData<CartDetailModel>(sql);
        }

        public static List<CartDetailModel> LoadCartDetailByCartID(int id)
        {
            string sql = String.Format("SELECT * FROM dbo.tbl_ChiTietGioHang WHERE GioHangID = {0}", id);
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.LoadData<CartDetailModel>(sql);
        }

        public static List<CartDetailModel> LoadCartDetail(int num)
        {
            string sql = String.Format("SELECT TOP ({0}) * FROM dbo.tbl_ChiTietGioHang", num);
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.LoadData<CartDetailModel>(sql);
        }
        public static CartDetailModel LoadOneCartDetaiil(int id)
        {
            string sql = String.Format("SELECT TOP (1) * FROM dbo.tbl_ChiTietGioHang WHERE ChiTietGioHangID = {0}", id);
            List<CartDetailModel> CartDetail = SqlDataAccess.LoadData<CartDetailModel>(sql);
            System.Diagnostics.Debug.WriteLine(sql);
            if (CartDetail.Count > 0)
            {
                return CartDetail[0];
            }
            else
            {
                return null;
            }
        }
        public static int CreateCartDetail(int _SanPhamID, int _SL, float _DonGia,
            int _GioHangID, DateTime _NgayThem)
        {
            CartDetailModel data = new CartDetailModel
            {
                SanPhamID = _SanPhamID,
                SL = _SL,
                DonGia = _DonGia,
                GioHangID = _GioHangID,
                NgayThem = _NgayThem
            };
            string sql = @"insert into dbo.tbl_ChiTietGioHang (SanPhamID, SL, DonGia, GioHangID, NgayThem)
                            values(@SanPhamID, @SL, @DonGia, @GioHangID, @NgayThem)";
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.SaveData(sql, data);
        }
        public static int RemoveAllCartDetail(int GioHangID)
        {
            string sql = String.Format("DELETE FROM tbl_ChiTietGioHang WHERE GioHangID = {0}", GioHangID);
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.DeleteData(sql);
        }
    }
}
