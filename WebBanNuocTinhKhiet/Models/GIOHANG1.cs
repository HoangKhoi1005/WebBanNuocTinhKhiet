using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebBanNuocTinhKhiet.Identity;

namespace WebBanNuocTinhKhiet.Models
{
    public class GIOHANG1
    {
        [Key]
        public int MaGH { get; set; }

        public decimal TongTien { get; set; }

        public Nullable<int> MaSP { get; set; }

        public int SoLuong { get; set; }

        //public string MaUser { get; set; }

        //[foreignkey("MaUser")]
        public virtual AppUser AspNetUser { get; set; }

        public virtual SANPHAM1 SANPHAM { get; set; }


    }
}