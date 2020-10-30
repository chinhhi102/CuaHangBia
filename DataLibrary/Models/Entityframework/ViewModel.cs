using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Models.NewFolder1;
using System.Web;

namespace DataLibrary.Models.NewFolder1
{
    public class ViewModel
    {
    }
    public class CreateTinTuc
    {
        public tbl_TinTuc tintuc { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
