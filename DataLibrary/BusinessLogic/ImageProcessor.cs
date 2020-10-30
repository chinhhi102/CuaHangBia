using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Models;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class ImageProcessor
    {
        public static List<Object> GetScopeImageIdentity()
        {
            return SqlDataAccess.GetScopeIdentity();
        }
        public static int CreateImage(string _Title, string _ImagePath)
        {
            ImageModel data = new ImageModel
            {
                Title = _Title,
                ImagePath = _ImagePath
            };
            string sql = @"insert into dbo.tbl_Images (Title, ImagePath)
                            values(@Title, @ImagePath)";
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.SaveData(sql, data);
        }
        public static ImageModel LoadOneImage(int ImageID)
        {
            string sql = String.Format("SELECT TOP(1) * FROM dbo.tbl_Images WHERE ImageID = {0}", ImageID);
            List<ImageModel> list = SqlDataAccess.LoadData<ImageModel>(sql);
            System.Diagnostics.Debug.WriteLine(sql);
            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }
    }
}
