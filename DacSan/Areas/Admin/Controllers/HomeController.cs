using DacSan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.UsersProcessor;

namespace DacSan.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private void __construct()
        {
            ViewBag.Title = "Trang Quản Trị";
            if (Session["UserID"] != null)
            {
                if ((int)Session["UserRole"] == 1)
                {
                    Session.Clear();
                }
                else
                {
                    ViewBag.UserID = Session["UserID"];
                    ViewBag.UserName = Session["UserName"];
                    ViewBag.UserRole = Session["UserRole"];
                }
            }
        }


        // GET: Admin/Home
        public ActionResult Index()
        {
            __construct();
            if (Session["UserID"] == null)
                return RedirectToAction("Login", "Account");
            return View();
        }
    }
}