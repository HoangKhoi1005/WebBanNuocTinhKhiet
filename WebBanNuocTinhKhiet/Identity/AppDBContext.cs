using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using WebBanNuocTinhKhiet.Models;

namespace WebBanNuocTinhKhiet.Identity
{
    public class AppDBContext : IdentityDbContext<AppUser>
    {
        public AppDBContext() : base("SanPhamEntities1") { }

        public DbSet<GIOHANG1> GIOHANGs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // one-to-zero or one relationship between ApplicationUser and Customer
            // UserId column in Customers table will be foreign key
            modelBuilder.Entity<GIOHANG1>()
                .HasOptional(m => m.AspNetUser)
                .WithRequired(m => m.GIOHANG)
                .Map(p => p.MapKey("MaGH"));


        }
    }
}