using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanNuocTinhKhiet.Models
{
    public class SANPHAM1
    {
        [Key]
        public int MaSP { get; set; }
        [Required]
        public string TenSP { get; set; }
        [Required]
        public decimal GiaCu { get; set; }
        [Required]
        public decimal GiaDB { get; set; }
        public string Anh { get; set; }
        [Required]
        public string MoTa { get; set; }
        [Required]
        public System.DateTime NgaySX { get; set; }
        public string Anh2 { get; set; }
        [Required]
        public string DungTichSP { get; set; }
        [Required]
        public Nullable<int> MaThuongHieu { get; set; }
        [Required]
        public Nullable<int> MaChiTietSP { get; set; }

        public virtual CHITIETSP1 CHITIETSP { get; set; }
        public virtual THUONGHIEU1 THUONGHIEU { get; set; }
    }
}