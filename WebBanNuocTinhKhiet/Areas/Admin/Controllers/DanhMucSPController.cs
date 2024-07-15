using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanNuocTinhKhiet.Models;

namespace WebBanNuocTinhKhiet.Areas.Admin.Controllers
{
    public class DanhMucSPController : Controller
    {
        // GET: DanhMucSP
        public ActionResult Index(string sortColumn = "Id", int page = 1, string Search = "", string loaiSP = "")
        {
            DBContext db = new DBContext();
            //List<Employee> emp = db.Employee.ToList();

            //Search
            List<SANPHAM1> sp = db.SANPHAM1s.Where(row => row.TenSP.Contains(Search)).ToList();


            //Sort
            ViewBag.sortColumn = sortColumn;
            if (sortColumn == "MaSP")
                sp = sp.OrderBy(row => row.MaSP).ToList();
            else if (sortColumn == "TenSP")
                sp = sp.OrderBy(row => row.TenSP).ToList();
            else if (sortColumn == "TenSPGiam")
                sp = sp.OrderByDescending(row => row.TenSP).ToList();
            else if (sortColumn == "GiaTang")
                sp = sp.OrderBy(row => row.GiaCu).ToList();
            else if (sortColumn == "GiaGiam")
                sp = sp.OrderByDescending(row => row.GiaCu).ToList();
            else if (sortColumn == "NgayMoi")
                sp = sp.OrderBy(row => row.NgaySX).ToList();
            else if (sortColumn == "NgayCu")
                sp = sp.OrderByDescending(row => row.NgaySX).ToList();

            ViewBag.loaiSP = loaiSP;
            if (loaiSP == "SanPhamBanChay")
                sp = db.SANPHAM1s.Where(row => row.MaChiTietSP == 1).ToList();
            else if (loaiSP == "SanPhamNoiBat")
                sp = db.SANPHAM1s.Where(row => row.MaChiTietSP == 2).ToList();
            else if (loaiSP == "SanPhamMoi")
                sp = db.SANPHAM1s.Where(row => row.MaChiTietSP == 3).ToList();

            return View(sp);
        }

        public ActionResult SanPhamBanChay(string sortColumn = "Id")
        {
            DBContext db = new DBContext();
            List<SANPHAM1> sp = db.SANPHAM1s.Where(row => row.MaChiTietSP == 1).ToList();

            ViewBag.loaiSP = "SanPhamBanChay";
            ViewBag.sortColumn = sortColumn;
            if (sortColumn == "MaSP")
                sp = sp.OrderBy(row => row.MaSP).ToList();
            else if (sortColumn == "TenSP")
                sp = sp.OrderBy(row => row.TenSP).ToList();
            else if (sortColumn == "TenSPGiam")
                sp = sp.OrderByDescending(row => row.TenSP).ToList();
            else if (sortColumn == "GiaTang")
                sp = sp.OrderBy(row => row.GiaCu).ToList();
            else if (sortColumn == "GiaGiam")
                sp = sp.OrderByDescending(row => row.GiaCu).ToList();
            else if (sortColumn == "NgayMoi")
                sp = sp.OrderBy(row => row.NgaySX).ToList();
            else if (sortColumn == "NgayCu")
                sp = sp.OrderByDescending(row => row.NgaySX).ToList();


            return View(sp);
        }

        public ActionResult SanPhamNoiBat(string sortColumn = "Id")
        {
            DBContext db = new DBContext();
            List<SANPHAM1> sp = db.SANPHAM1s.Where(row => row.MaChiTietSP == 1).ToList();

            ViewBag.loaiSP = "SanPhamNoiBat";
            ViewBag.sortColumn = sortColumn;
            if (sortColumn == "MaSP")
                sp = sp.OrderBy(row => row.MaSP).ToList();
            else if (sortColumn == "TenSP")
                sp = sp.OrderBy(row => row.TenSP).ToList();
            else if (sortColumn == "TenSPGiam")
                sp = sp.OrderByDescending(row => row.TenSP).ToList();
            else if (sortColumn == "GiaTang")
                sp = sp.OrderBy(row => row.GiaCu).ToList();
            else if (sortColumn == "GiaGiam")
                sp = sp.OrderByDescending(row => row.GiaCu).ToList();
            else if (sortColumn == "NgayMoi")
                sp = sp.OrderBy(row => row.NgaySX).ToList();
            else if (sortColumn == "NgayCu")
                sp = sp.OrderByDescending(row => row.NgaySX).ToList();


            return View(sp);
        }

        public ActionResult SanPhamMoi(string sortColumn = "Id")
        {
            DBContext db = new DBContext();
            List<SANPHAM1> sp = db.SANPHAM1s.Where(row => row.MaChiTietSP == 1).ToList();

            ViewBag.loaiSP = "SanPhamMoi";
            ViewBag.sortColumn = sortColumn;
            if (sortColumn == "MaSP")
                sp = sp.OrderBy(row => row.MaSP).ToList();
            else if (sortColumn == "TenSP")
                sp = sp.OrderBy(row => row.TenSP).ToList();
            else if (sortColumn == "TenSPGiam")
                sp = sp.OrderByDescending(row => row.TenSP).ToList();
            else if (sortColumn == "GiaTang")
                sp = sp.OrderBy(row => row.GiaCu).ToList();
            else if (sortColumn == "GiaGiam")
                sp = sp.OrderByDescending(row => row.GiaCu).ToList();
            else if (sortColumn == "NgayMoi")
                sp = sp.OrderBy(row => row.NgaySX).ToList();
            else if (sortColumn == "NgayCu")
                sp = sp.OrderByDescending(row => row.NgaySX).ToList();


            return View(sp);
        }

        public ActionResult Search(string Search = "", int page = 1)
        {
            DBContext db = new DBContext();
            List<SANPHAM1> sp = db.SANPHAM1s.Where(row => row.TenSP.Contains(Search)).ToList();

            int RecordPerPage = 5;
            int Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sp.Count)) / Convert.ToDouble(RecordPerPage));
            int Skip = (page - 1) * RecordPerPage;
            ViewBag.page = page;
            ViewBag.Pages = Pages;
            sp = sp.Skip(Skip).Take(RecordPerPage).ToList();

            return View(sp);
        }
    }
}