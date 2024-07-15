using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanNuocTinhKhiet.Models
{
    public class THUONGHIEU1
    {
        [Key]
        public int MaThuongHieu { get; set; }
        public string TenThuongHieu { get; set; }
    }
}