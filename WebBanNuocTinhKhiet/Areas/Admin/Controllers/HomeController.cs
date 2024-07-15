using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanNuocTinhKhiet.Models;

namespace WebBanNuocTinhKhiet.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DBContext sp = new DBContext();
            List<SANPHAM1> dsSP = sp.SANPHAM1s.ToList();
            return View(dsSP);
        }
    }
}