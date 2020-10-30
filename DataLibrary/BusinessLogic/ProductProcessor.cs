using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Models;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class ProductProcessor
    {
        public static List<Object> GetScopeProductIdentity()
        {
            return SqlDataAccess.GetScopeIdentity();
        }
        public static int CreateProduct(string _TenSP, string _Mota, int _LoaiSPID, int _DiaChiID, float _DonGia, string _ImagePath)
        {
            ProductModel data = new ProductModel
            {
                TenSP = _TenSP,
                MoTa = _Mota,
                LoaiSPID = _LoaiSPID,
                DiaChiID = _DiaChiID,
                DonGia = _DonGia,
                ImagePath = _ImagePath
            };
            string sql = @"INSERT INTO dbo.tbl_SanPham VALUES(@TenSP, @MoTa, @LoaiSPID, @DiaChiID, @DonGia, @ImagePath)";
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.SaveData(sql, data);
        }
        public static int UpdateProdcut(int _SanPhamID, string _TenSP, string _Mota, int _LoaiSPID, int _DiaChiID, float _DonGia, string _ImagePath = "none")
        {
            if(_ImagePath == "none")
            {
                ProductModel data = new ProductModel
                {
                    SanPhamID = _SanPhamID,
                    TenSP = _TenSP,
                    MoTa = _Mota,
                    LoaiSPID = _LoaiSPID,
                    DiaChiID = _DiaChiID,
                    DonGia = _DonGia
                };
                string sql = @"UPDATE dbo.tbl_SanPham SET TenSP = @TenSP, MoTa = @MoTa, LoaiSPID = @LoaiSPID, DiaChiID = @DiaChiID, DonGia = @DonGia WHERE SanPhamID = @SanPhamID";
                System.Diagnostics.Debug.WriteLine(sql);
                return SqlDataAccess.SaveData(sql, data);
            }
            else
            {
                ProductModel data = new ProductModel
                {
                    SanPhamID = _SanPhamID,
                    TenSP = _TenSP,
                    MoTa = _Mota,
                    LoaiSPID = _LoaiSPID,
                    DiaChiID = _DiaChiID,
                    DonGia = _DonGia,
                    ImagePath = _ImagePath
                };
                string sql = @"UPDATE dbo.tbl_SanPham SET TenSP = @TenSP, MoTa = @MoTa, LoaiSPID = @LoaiSPID, DiaChiID = @DiaChiID, DonGia = @DonGia, ImagePath = @ImagePath WHERE SanPhamID = @SanPhamID";
                System.Diagnostics.Debug.WriteLine(sql);
                return SqlDataAccess.SaveData(sql, data);
            }
        }

        public static int DeleteProduct(int SanPhamID)
        {
            string sql = String.Format("DELETE FROM dbo.tbl_SanPham WHERE SanPhamID = {0}", SanPhamID);
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.DeleteData(sql);
        }
        public static List<ProductModel> LoadProducts()
        {
            string sql = @"SELECT * FROM dbo.tbl_SanPham";
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.LoadData<ProductModel>(sql);
        }

        public static List<ProductModel> LoadProducts(int num)
        {
            string sql = String.Format("SELECT TOP({0}) * FROM dbo.tbl_SanPham", num);

            System.Diagnostics.Debug.WriteLine(sql);

            return SqlDataAccess.LoadData<ProductModel>(sql);
        }

        public static List<ProductModel> LoadProductByCate(int LoaiSPID)
        {
            string sql = String.Format("SELECT * FROM dbo.tbl_SanPham WHERE LoaiSPID = {0}", LoaiSPID);

            System.Diagnostics.Debug.WriteLine(sql);

            return SqlDataAccess.LoadData<ProductModel>(sql);
        }

        public static List<ProductModel> LoadProductByCate(int LoaiSPID, int num)
        {
            string sql = String.Format("SELECT TOP({0}) * FROM dbo.tbl_SanPham WHERE LoaiSPID = {1}", num, LoaiSPID);
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.LoadData<ProductModel>(sql);
        }
        public static ProductModel LoadOneProduct(int SanPhamID)
        {
            string sql = String.Format("SELECT TOP(1) * FROM dbo.tbl_SanPham WHERE SanPhamID = {0}", SanPhamID);
            System.Diagnostics.Debug.WriteLine(sql);
            List<ProductModel> sps = SqlDataAccess.LoadData<ProductModel>(sql);
            if(sps.Count > 0)
            {
                return sps[0];
            }
            else
            {
                return null;
            }
        }
    }
}
