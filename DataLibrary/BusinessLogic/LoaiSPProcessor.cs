using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Models;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class LoaiSPProcessor
    {
        public static List<Object> GetScopeLoaiSPIdentity()
        {
            return SqlDataAccess.GetScopeIdentity();
        }
        public static List<LoaiSPModel> LoadLoaiSP()
        {
            string sql = @"SELECT * FROM dbo.tbl_LoaiSP";
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.LoadData<LoaiSPModel>(sql);
        }
        public static List<LoaiSPModel> LoadLoaiSP(int num)
        {
            string sql = String.Format("SELECT TOP ({0}) * FROM dbo.tbl_LoaiSP", num);
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.LoadData<LoaiSPModel>(sql);
        }
        public static LoaiSPModel LoadOneLoaiSP(int id)
        {
            string sql = String.Format("SELECT TOP (1) * FROM dbo.tbl_LoaiSP WHERE LoaiSPID = {0}", id);
            List<LoaiSPModel> loaiSP = SqlDataAccess.LoadData<LoaiSPModel>(sql);
            System.Diagnostics.Debug.WriteLine(sql);
            if (loaiSP.Count > 0)
            {
                return loaiSP[0];
            }
            else
            {
                return null;
            }
        }
    }
}
