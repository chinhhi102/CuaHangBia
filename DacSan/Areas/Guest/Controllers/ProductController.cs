using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.LoaiSPProcessor;
using static DataLibrary.BusinessLogic.ProductProcessor;
using static DataLibrary.BusinessLogic.CartDetailProcessor;
using static DataLibrary.BusinessLogic.CartProcessor;
using DataLibrary.Models;
using DacSan.Models;
using DataLibrary.Models.NewFolder1;
using PagedList;

namespace DacSan.Areas.Guest.Controllers
{
    public class ProductController : Controller
    {

        Model1 db = new Model1();
        private void __construct()
        {
            ViewBag.Title = "Trang Người dùng";
            try
            {
                Session["CurProduct"] = null;
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
                    ViewData[loai.LoaiSPID.ToString()] = LoadProductByCate(loai.LoaiSPID, 6);
                }
                var spnb = LoadProducts(3);
                ViewData["spnb"] = spnb;
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
        private void __LoadCart()
        {
            if (Session["UserID"] != null)
            {
                var check = LoadOneCartByUser((int)Session["UserID"]);
                int GioHangID;
                if (check == null)
                {
                    GioHangID = CreateCart((int)Session["UserID"]);
                }
                else
                {
                    GioHangID = check.GioHangID;
                }
                RemoveAllCartDetail(GioHangID);
                if (Session["cart"] != null)
                {
                    List<ItemModel> cart = (List<ItemModel>)Session["cart"];
                    foreach (ItemModel item in cart)
                    {
                        CreateCartDetail(item.Product.ProductID, item.SL, item.Product.DonGia, GioHangID, item.NgayThem);
                    }
                }
            }
        }
        // GET: Product
        public ActionResult Index()
        {
            __construct();
            return View();
        }

        public ActionResult Categories(int id)
        {
            __construct();
            try
            {
                var loaiSP = LoadOneLoaiSP(id);
                ViewData["loaispds"] = loaiSP;
                ViewData[loaiSP.LoaiSPID.ToString()] = LoadProductByCate(loaiSP.LoaiSPID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return View();
        }

        public ActionResult Details(int categoriesID, int productID)
        {
            __construct();
            try
            {
                Session["CurProduct"] = productID;
                var sp = LoadOneProduct(productID);
                var loaiSP = LoadOneLoaiSP(categoriesID);
                if (sp != null)
                {
                    ViewData["loaispds"] = ((LoaiSPModel)loaiSP).TenLoaiSP;
                    ViewData["spds"] = sp;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int sl)
        {
            if (Session["cart"] == null)
            {
                List<ItemModel> cart = new List<ItemModel>();
                var sp = new DacSan.Models.ProductModel(LoadOneProduct(Convert.ToInt32(Session["CurProduct"])));
                ItemModel item = new ItemModel() { Product = sp, SL = sl, NgayThem = DateTime.Now };
                cart.Add(item);
                Session["cart"] = cart;
            }
            else
            {
                List<ItemModel> cart = (List<ItemModel>)Session["cart"];
                int index = isExist(Convert.ToInt32(Session["CurProduct"]));
                if (index != -1)
                {
                    cart[index].SL += sl;
                }
                else
                {
                    var sp = new DacSan.Models.ProductModel(LoadOneProduct(Convert.ToInt32(Session["CurProduct"])));
                    ItemModel item = new ItemModel() { Product = sp, SL = sl, NgayThem = DateTime.Now };
                    cart.Add(item);
                }
                Session["cart"] = cart;
            }
            __LoadCart();
            return RedirectToAction("Index", "Cart");
        }

        private int isExist(int id)
        {
            List<ItemModel> cart = (List<ItemModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.ProductID.Equals(id))
                    return i;
            return -1;
        }
    }
}