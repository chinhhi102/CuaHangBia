using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.LoaiSPProcessor;
using static DataLibrary.BusinessLogic.ProductProcessor;
using static DataLibrary.BusinessLogic.CartDetailProcessor;
using DataLibrary.Models;
using DacSan.Models;
using DataLibrary.Models.NewFolder1;
using PagedList;

namespace DacSan.Areas.Guest.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        private void __construct()
        {
            ViewBag.Title = "Trang Người dùng";
            try
            {
                if (Session["UserID"] != null)
                {
                    ViewBag.UserID = Session["UserID"];
                    ViewBag.UserName = Session["UserName"];
                    ViewBag.UserRole = Session["UserRole"];
                    List<ItemModel> list = new List<ItemModel>();
                    var listCart = LoadCartDetailByCartID((int)Session["CartID"]);
                    foreach (CartDetailModel cd in listCart)
                    {
                        var product = LoadOneProduct(cd.SanPhamID);
                        if (product != null)
                        {
                            ItemModel item = new ItemModel() { SL = cd.SL, NgayThem = cd.NgayThem, Product = new DacSan.Models.ProductModel(product) };
                            list.Add(item);
                        }
                    }
                    Session["cart"] = list;
                }
                List<tbl_TinTuc> listtintuc = db.tbl_TinTuc.ToList();
                ViewData["listTinTuc"] = listtintuc;
                var loaisp = LoadLoaiSP(12);
                ViewData["loaisp"] = loaisp;
                foreach (LoaiSPModel loai in (IEnumerable<LoaiSPModel>)ViewData["loaisp"])
                {
                    var listsp = LoadProductByCate(loai.LoaiSPID, 6);
                    ViewData[loai.LoaiSPID.ToString()] = listsp;
                }
                if (Session["cart"] != null)
                {
                    ViewData["NumCart"] = ((List<ItemModel>)Session["cart"]).Count;
                }
                else
                {
                    ViewData["NumCart"] = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        // GET: Home
        public ActionResult Index()
        {
            __construct();
            return View();
        }

        // GET: Home/Tutorial
        public ActionResult Tutorial()
        {
            __construct();
            return View();
        }

        public ActionResult Introduct()
        {

            __construct();
            return View();
        }

        public ActionResult News(int page = 1, int pageSize = 7)
        {
            __construct();
            List<tbl_TinTuc> tintuc = db.tbl_TinTuc.ToList();

            PagedList<tbl_TinTuc> view = new PagedList<tbl_TinTuc>(tintuc, page, pageSize);
            return View("News", view);
        }
        public ActionResult NewsDetails(int id, int page = 1, int pageSize = 7)
        {
            __construct();
            tbl_TinTuc tintuc = db.tbl_TinTuc.Find(id);

            return View("NewsDetails", tintuc);
        }
        public ActionResult Contact()
        {
            __construct();
            return View();
        }
    }
}