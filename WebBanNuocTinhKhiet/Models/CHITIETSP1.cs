using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanNuocTinhKhiet.Models
{
    public class CHITIETSP1
    {
        [Key]
        public int MaChiTietSP { get; set; }
        public string LoaiSP { get; set; }
    }
}