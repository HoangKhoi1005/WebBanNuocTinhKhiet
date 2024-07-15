using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using WebBanNuocTinhKhiet.Models;

namespace WebBanNuocTinhKhiet.Identity
{
    public class AppUser : IdentityUser
    {
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public virtual GIOHANG1 GIOHANG { get; set; }
    }
}