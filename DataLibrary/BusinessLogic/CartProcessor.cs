using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Models;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class CartProcessor
    {
        public static List<CartModel> LoadCart()
        {
            string sql = @"SELECT * FROM dbo.tbl_GioHang";
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.LoadData<CartModel>(sql);
        }
        public static List<CartModel> LoadCart(int num)
        {
            string sql = String.Format("SELECT TOP ({0}) * FROM dbo.tbl_GioHang", num);
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.LoadData<CartModel>(sql);
        }
        public static CartModel LoadOneCart(int id)
        {
            string sql = String.Format("SELECT TOP (1) * FROM dbo.tbl_GioHang WHERE GioHangID = {0}", id);
            List<CartModel> cart = SqlDataAccess.LoadData<CartModel>(sql);
            System.Diagnostics.Debug.WriteLine(sql);
            if (cart.Count > 0)
            {
                return cart[0];
            }
            else
            {
                return null;
            }
        }
        public static CartModel LoadOneCartByUser(int id)
        {
            string sql = String.Format("SELECT TOP (1) * FROM dbo.tbl_GioHang WHERE UserID = {0}", id);
            List<CartModel> cart = SqlDataAccess.LoadData<CartModel>(sql);
            System.Diagnostics.Debug.WriteLine(sql);
            if (cart.Count > 0)
            {
                return cart[0];
            }
            else
            {
                return null;
            }
        }
        public static int CreateCart(int _UserID)
        {
            CartModel data = new CartModel
            {
                UserID = _UserID
            };
            string sql = @"insert into dbo.tbl_GioHang (UserID)
                            values(@UserID)";
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
