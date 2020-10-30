using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DacSan.Models;
using DacSan.Areas.Guest.Models;
using DataLibrary.Models;
using static DataLibrary.BusinessLogic.UsersProcessor;
using static DataLibrary.BusinessLogic.LoaiSPProcessor;
using static DataLibrary.BusinessLogic.CartProcessor;
using static DataLibrary.BusinessLogic.CartDetailProcessor;
using static DataLibrary.BusinessLogic.ProductProcessor;

namespace DacSan.Areas.Guest.Controllers
{
    public class AccountController : Controller
    {
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
        // GET: Guest/Account
        public ActionResult Index()
        {
            __construct();
            return View();
        }

        public ActionResult Login()
        {
            __construct();
            if (Session["UserID"] != null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginModel user)
        {
            if (ModelState.IsValid)
            {
                var GuestUser = GetUser(user.Username, user.Password, 2);
                if (GuestUser != null)
                {
                    Session["UserID"] = GuestUser.UserID;
                    Session["UserName"] = GuestUser.Username;
                    Session["UserRole"] = GuestUser.Role;
                    var CartID = LoadOneCartByUser(GuestUser.UserID);
                    int id;
                    if(CartID == null)
                    {
                        id = CreateCart(GuestUser.UserID);
                    }
                    else
                    {
                        id = CartID.GioHangID;
                    }
                    Session["CartID"] = id;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Error"] = "Sai tài khoản hoặc mật khẩu";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public ActionResult Register()
        {

            __construct();
            if (Session["UserID"] != null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(DacSan.Models.UsersModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var GuestUser = GetUser(user.Username);
                    if (GuestUser == null)
                    {
                        CreateUser(user.Username, user.Password, user.FirstName, user.LastName, user.EmailAddress, user.PhoneNumber, 1);
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        TempData["Error"] = "Tài khoản đã được đăng ký";
                        return RedirectToAction("Register");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    TempData["Error"] = "Đăng ký thất bại, Mất kết nối cơ sở dữ liệu";
                    return RedirectToAction("Register");
                }
            }
            return View();
        }

        public ActionResult ResetPassword()
        {

            __construct();
            if (Session["UserID"] == null)
            {
                TempData["Error"] = "Bạn chưa đăng nhập";
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public ActionResult Info()
        {

            __construct();
            if (Session["UserID"] == null)
            {
                TempData["Error"] = "Bạn chưa đăng nhập";
                return RedirectToAction("Login", "Account");
            }
            var GuestUser = GetUser((String)Session["UserName"]);
            var guest = new DacSan.Models.UsersModel(GuestUser);
            return View(guest);
        }

        public ActionResult Logout()
        {

            __construct();
            if (Session["UserID"] == null)
            {
                TempData["Error"] = "Bạn chưa đăng nhập";
                return RedirectToAction("Login", "Account");
            }
            Session.Clear();
            return RedirectToAction("Login");
        }

    }
}