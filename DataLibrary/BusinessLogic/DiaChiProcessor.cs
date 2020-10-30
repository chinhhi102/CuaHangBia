using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Models;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class DiaChiProcessor
    {
        public static List<Object> GetScopeDiaChiIdentity()
        {
            return SqlDataAccess.GetScopeIdentity();
        }
        public static List<DiaChiModel> LoadDiaChi()
        {
            string sql = @"SELECT * FROM dbo.tbl_DiaChi";
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.LoadData<DiaChiModel>(sql);
        }
    }
}
