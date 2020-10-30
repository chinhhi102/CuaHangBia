using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.Models.NewFolder1;
using PagedList;


namespace DacSan.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        Model1 db = new Model1();
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
        // GET: Admin/News
        public ActionResult Index(int page=1,int pageSize = 7)
        {
            __construct();
            if (Session["UserID"] == null)
                return RedirectToAction("Login", "Account");
            List<tbl_TinTuc> tintuc = db.tbl_TinTuc.ToList();
            
            PagedList<tbl_TinTuc> view = new PagedList<tbl_TinTuc>(tintuc, page, pageSize);
            return View(view);
        }
        public ActionResult Create()
        {
            __construct();
            if (Session["UserID"] == null)
                return RedirectToAction("Login", "Account");
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_TinTuc tintuc, HttpPostedFileBase ImageFile)
        {
            if(ImageFile != null) { 
            string fileName= ImageFile.FileName;
            fileName =  DateTime.Now.ToString("yymmssfff") + fileName;
            tintuc.ImagePath = "/Images/" + fileName;
            ImageFile.SaveAs(Path.Combine(Server.MapPath("~/Images/"), fileName));
            }
           
            tintuc.NgayViet = DateTime.Now;
            db.tbl_TinTuc.Add(tintuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id=1)
        {
            __construct();
            if (Session["UserID"] == null)
                return RedirectToAction("Login", "Account");
            tbl_TinTuc tintuc = db.tbl_TinTuc.Find(id);
            return View(tintuc);
        }
        [HttpPost]
        public ActionResult Edit(tbl_TinTuc tintuc, HttpPostedFileBase ImageFile)
        {
            tbl_TinTuc item = db.tbl_TinTuc.Find(tintuc.TinTucID);

            if (ImageFile != null)
            {
                string fileName = ImageFile.FileName;
                fileName = DateTime.Now.ToString("yymmssfff") + fileName;
                item.ImagePath = "/Images/" + fileName;
                ImageFile.SaveAs(Path.Combine(Server.MapPath("~/Images/"), fileName));
            }
            item.NoiDung = tintuc.NoiDung;
            item.TieuDe = tintuc.TieuDe;
           
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            tbl_TinTuc tintuc = db.tbl_TinTuc.Find(id);
            db.tbl_TinTuc.Remove(tintuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}