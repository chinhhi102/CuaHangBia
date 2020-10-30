using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DacSan.Areas.Admin.Models;
using DacSan.Models;
using static DataLibrary.BusinessLogic.UsersProcessor;
using static DataLibrary.BusinessLogic.CartProcessor;

namespace DacSan.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Đăng Nhập Hệ Thống";
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
                var AdminUser = GetUser(user.Username, user.Password);
                System.Diagnostics.Debug.WriteLine(AdminUser);
                if (AdminUser != null)
                {
                    Session["UserID"] = AdminUser.UserID;
                    Session["UserName"] = AdminUser.Username;
                    Session["UserRole"] = AdminUser.Role;
                    var CartID = LoadOneCartByUser(AdminUser.UserID);
                    int id;
                    if (CartID == null)
                    {
                        id = CreateCart(AdminUser.UserID);
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
                    TempData["Error"] = "Đăng nhập thất bại";
                    System.Diagnostics.Debug.WriteLine(TempData["Error"]);
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}