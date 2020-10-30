using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.Models;
using static DataLibrary.BusinessLogic.ProductProcessor;
using static DataLibrary.BusinessLogic.LoaiSPProcessor;
using static DataLibrary.BusinessLogic.DiaChiProcessor;
using static DataLibrary.BusinessLogic.OrderProcessor;
using static DataLibrary.BusinessLogic.OrderDetailProcessor;

namespace DacSan.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("Index", "Home");
            var orders = LoadOrder();
            ViewBag.Title = "Quản Lý Đơn Hàng";
            ViewData["orders"] = orders;
            return View();
        }
        public ActionResult Details(int id)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("Index", "Home");
            var listOrderDetail = LoadOrderDetailByOrderID(id);
            ViewData["OrderID"] = id;
            return View(listOrderDetail);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                DeleteOrder(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}