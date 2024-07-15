using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanNuocTinhKhiet.Models;

namespace WebBanNuocTinhKhiet.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            DBContext db = new DBContext();
            SANPHAM1 sp = db.SANPHAM1s.Where(row => row.MaSP == id).FirstOrDefault();
            return View(sp);
        }
    }
}