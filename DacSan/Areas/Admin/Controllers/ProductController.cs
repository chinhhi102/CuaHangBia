using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.Models;
using static DataLibrary.BusinessLogic.ProductProcessor;
using static DataLibrary.BusinessLogic.LoaiSPProcessor;
using static DataLibrary.BusinessLogic.DiaChiProcessor;
using static DataLibrary.BusinessLogic.ImageProcessor;
using System.IO;

namespace DacSan.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("Index", "Home");
            var products = LoadProducts();
            ViewBag.Title = "Quản Lý Sản Phẩm";
            ViewData["products"] = products;

            return View();
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("Index", "Home");
            var loaisp = LoadLoaiSP();
            ViewData["loaisp"] = loaisp;
            var diachi = LoadDiaChi();
            ViewData["diachi"] = diachi;
            ViewBag.Title = "Thêm Sản Phẩm";
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DacSan.Models.ProductModel product)
        {
            try
            {
                var loaisp = LoadLoaiSP();
                ViewData["loaisp"] = loaisp;
                var diachi = LoadDiaChi();
                ViewData["diachi"] = diachi;
                if (product.ImageFile == null)
                {
                    CreateProduct(product.TenSP, product.MoTa, product.LoaiSPID, product.DiaChiID, product.DonGia, null);
                }
                else
                {
                    string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                    string extension = Path.GetExtension(product.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    product.ImagePath = "/Images/" + fileName;
                    product.ImageFile.SaveAs(Path.Combine(Server.MapPath("~/Images/"), fileName));
                    CreateProduct(product.TenSP, product.MoTa, product.LoaiSPID, product.DiaChiID, product.DonGia, product.ImagePath);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.ToString();
                return View();
            }
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("Index", "Home");
            var loaisp = LoadLoaiSP();
            ViewData["loaisp"] = loaisp;
            var diachi = LoadDiaChi();
            ViewData["diachi"] = diachi;
            ViewBag.Title = "Sửa Sản Phẩm";
            var sp = LoadOneProduct(id);
            ViewData["sp"] = new DacSan.Models.ProductModel(sp);
            ViewData["EditID"] = id;
            return View();
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DacSan.Models.ProductModel product)
        {
            try
            {
                // TODO: Add update logic here
                var loaisp = LoadLoaiSP();
                ViewData["loaisp"] = loaisp;
                var diachi = LoadDiaChi();
                ViewData["diachi"] = diachi;
                if (product.ImageFile == null)
                {
                    UpdateProdcut(product.ProductID, product.TenSP, product.MoTa, product.LoaiSPID, product.DiaChiID, product.DonGia);
                }
                else
                {
                    string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                    string extension = Path.GetExtension(product.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    product.ImagePath = "/Images/" + fileName;
                    product.ImageFile.SaveAs(Path.Combine(Server.MapPath("~/Images/"), fileName));
                    UpdateProdcut(product.ProductID, product.TenSP, product.MoTa, product.LoaiSPID, product.DiaChiID, product.DonGia, product.ImagePath);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                DeleteProduct(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
