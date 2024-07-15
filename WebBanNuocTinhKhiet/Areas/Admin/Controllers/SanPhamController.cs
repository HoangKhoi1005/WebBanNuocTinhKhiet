using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebBanNuocTinhKhiet.Models;

namespace WebBanNuocTinhKhiet.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: Admin/SanPham
        public ActionResult Index(string sortColumn = "Id", int page = 1, string Search = "")
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
            else if (sortColumn == "GiaCu")
                sp = sp.OrderBy(row => row.GiaCu).ToList();
            else if (sortColumn == "GiaDB")
                sp = sp.OrderBy(row => row.GiaDB).ToList();
            else if (sortColumn == "DungTichSP")
                sp = sp.OrderBy(row => row.DungTichSP).ToList();


            //Paging
            int RecordPerPage = 5;
            int Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sp.Count)) / Convert.ToDouble(RecordPerPage));
            int Skip = (page - 1) * RecordPerPage;
            ViewBag.page = page;
            ViewBag.Pages = Pages;
            sp = sp.Skip(Skip).Take(RecordPerPage).ToList();
            return View(sp);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(SANPHAM1 product, HttpPostedFileBase imageFile1, HttpPostedFileBase imageFile2)
        {
            if (ModelState.IsValid)
            {
                DBContext db = new DBContext();

                // Handling Image 1
                if (imageFile1 != null && imageFile1.ContentLength > 0)
                {
                    if (imageFile1.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("Anh", "Kích thước file phải nhỏ hơn 2MB.");
                        return View();
                    }

                    var allowEx = new[] { ".jpg", ".png" };
                    var fileEx = Path.GetExtension(imageFile1.FileName).ToLower();
                    if (!allowEx.Contains(fileEx))
                    {
                        ModelState.AddModelError("Anh", "Chỉ chấp nhận file ảnh jpg hoặc png.");
                        return View();
                    }

                    product.Anh = "";
                    db.SANPHAM1s.Add(product);
                    db.SaveChanges();

                    SANPHAM1 pro = db.SANPHAM1s.ToList().Last();

                    var fileName = pro.MaSP.ToString() + "_1" + fileEx;
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    imageFile1.SaveAs(path);

                    string link = "/Images/" + fileName;
                    pro.Anh = link;
                    db.SaveChanges();
                }

                // Handling Image 2
                if (imageFile2 != null && imageFile2.ContentLength > 0)
                {
                    if (imageFile2.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("Anh2", "Kích thước file phải nhỏ hơn 2MB.");
                        return View();
                    }

                    var allowEx = new[] { ".jpg", ".png" };
                    var fileEx = Path.GetExtension(imageFile2.FileName).ToLower();
                    if (!allowEx.Contains(fileEx))
                    {
                        ModelState.AddModelError("Anh2", "Chỉ chấp nhận file ảnh jpg hoặc png.");
                        return View();
                    }

                    product.Anh2 = "";
                    db.SANPHAM1s.Add(product);
                    db.SaveChanges();

                    SANPHAM1 pro = db.SANPHAM1s.ToList().Last();

                    var fileName = pro.MaSP.ToString() + "_2" + fileEx;
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    imageFile2.SaveAs(path);

                    string link = "/Images/" + fileName;
                    pro.Anh2 = link;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Update(int id)
        {
            DBContext db = new DBContext();
            SANPHAM1 sp = db.SANPHAM1s.Where(row => row.MaSP == id).FirstOrDefault();
            return View(sp);
        }

        [HttpPost]

        public ActionResult Update(int id, SANPHAM1 pro, HttpPostedFileBase imageFile1, HttpPostedFileBase imageFile2)
        {
            DBContext db = new DBContext();
            SANPHAM1 sp = db.SANPHAM1s.Where(row => row.MaSP == id).FirstOrDefault();

            if (sp != null)
            {
                sp.TenSP = pro.TenSP;
                sp.GiaCu = pro.GiaCu;
                sp.GiaDB = pro.GiaDB;
                sp.MoTa = pro.MoTa;
                sp.NgaySX = pro.NgaySX;
                sp.MaThuongHieu = pro.MaThuongHieu;
                sp.MaChiTietSP = pro.MaChiTietSP;

                // Handling Image 1
                if (imageFile1 != null && imageFile1.ContentLength > 0)
                {
                    if (imageFile1.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("Anh", "Kích thước file phải nhỏ hơn 2MB.");
                        return View();
                    }

                    var allowEx = new[] { ".jpg", ".png" };
                    var fileEx = Path.GetExtension(imageFile1.FileName).ToLower();
                    if (!allowEx.Contains(fileEx))
                    {
                        ModelState.AddModelError("Anh", "Chỉ chấp nhận file ảnh jpg hoặc png.");
                        return View();
                    }

                    sp.Anh = ""; // Assuming 'Anh' is the property for the first image
                    var fileName = sp.MaSP.ToString() + "_1" + fileEx;
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    imageFile1.SaveAs(path);

                    string link = "/Images/" + fileName;
                    sp.Anh = link;
                }

                // Handling Image 2
                if (imageFile2 != null && imageFile2.ContentLength > 0)
                {
                    if (imageFile2.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("Anh2", "Kích thước file phải nhỏ hơn 2MB.");
                        return View();
                    }

                    var allowEx = new[] { ".jpg", ".png" };
                    var fileEx = Path.GetExtension(imageFile2.FileName).ToLower();
                    if (!allowEx.Contains(fileEx))
                    {
                        ModelState.AddModelError("Anh2", "Chỉ chấp nhận file ảnh jpg hoặc png.");
                        return View();
                    }

                    sp.Anh2 = ""; // Assuming 'Anh2' is the property for the second image
                    var fileName = sp.MaSP.ToString() + "_2" + fileEx;
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    imageFile2.SaveAs(path);

                    string link = "/Images/" + fileName;
                    sp.Anh2 = link;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound(); // Product with the specified ID not found
            }
        }


        public ActionResult Remove(int id)
        {
            DBContext db = new DBContext();
            SANPHAM1 pro = db.SANPHAM1s.Where(row => row.MaSP == id).FirstOrDefault();
            return View(pro);
        }

        [HttpPost]

        public ActionResult Remove(int id, SANPHAM1 h)
        {
            DBContext db = new DBContext();
            SANPHAM1 pro = db.SANPHAM1s.Where(row => row.MaSP == id).FirstOrDefault();
            db.SANPHAM1s.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            DBContext db = new DBContext();
            SANPHAM1 sp = db.SANPHAM1s.Where(row => row.MaSP == id).FirstOrDefault();
            return View(sp);
        }
    }
}