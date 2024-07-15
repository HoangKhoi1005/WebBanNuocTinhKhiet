using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanNuocTinhKhiet.Identity;
using WebBanNuocTinhKhiet.Models;

namespace WebBanNuocTinhKhiet.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            DBContext db = new DBContext();
            List<GIOHANG1> cart = db.GIOHANG1s.ToList();
            return View(cart);
        }

        public ActionResult Add(int id = 0)
        {
            // Kiểm tra đăng nhập
            if (User.Identity.GetUserId() == null)
            {
                return RedirectToAction("Login", "Account");
            }

            string userId = User.Identity.GetUserId();

            if (id > 0)
            {
                DBContext db = new DBContext();

                // Kiểm tra giỏ hàng có sản phẩm với id đã cho chưa
                GIOHANG1 cartItem = db.GIOHANG1s.Where(cart => cart.MaSP == id).FirstOrDefault();

                // Lấy thông tin sản phẩm từ database
                SANPHAM1 sp = db.SANPHAM1s.FirstOrDefault(cart => cart.MaSP == id);

                if (cartItem != null)
                {
                    // Nếu sản phẩm đã có trong giỏ hàng, cập nhật thông tin
                    cartItem.SoLuong += 1;
                    cartItem.TongTien = cartItem.SoLuong * sp.GiaCu;
                }
                else
                {
                    // Nếu sản phẩm chưa có trong giỏ hàng, thêm mới
                    GIOHANG1 cart = new GIOHANG1();
                    cart.MaSP = id;
                    cart.SoLuong = 1;
                    cart.TongTien = sp.GiaCu;


                    db.GIOHANG1s.Add(cart);
                }

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }




        public ActionResult UpdateQuantity(int quan = 0, int proid = 0)
        {
            DBContext db = new DBContext();
            if (quan > 0)
            {
                GIOHANG1 cartItem = db.GIOHANG1s.Where(cart => cart.MaSP == proid).FirstOrDefault();
                SANPHAM1 sp = db.SANPHAM1s.Where(cart => cart.MaSP == proid).FirstOrDefault();
                if (cartItem != null)
                {
                    cartItem.SoLuong = quan;
                    cartItem.TongTien = sp.GiaCu;
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}