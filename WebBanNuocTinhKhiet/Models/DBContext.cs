using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebBanNuocTinhKhiet.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base("SanPhamEntities1") { }
        public DbSet<SANPHAM1> SANPHAM1s { get; set; }

        public DbSet<CHITIETSP1> CHITIETSP1s { get; set; }

        public DbSet<THUONGHIEU1> THUONGHIEU1s { get; set; }

        public DbSet<GIOHANG1> GIOHANG1s { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // one-to-zero or one relationship between ApplicationUser and Customer
            // UserId column in Customers table will be foreign key
            modelBuilder.Entity<GIOHANG1>()
                .HasOptional(m => m.AspNetUser)
                .WithRequired(m => m.GIOHANG)
                .Map(p => p.MapKey("MaGH"));

            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => new { l.UserId, l.LoginProvider, l.ProviderKey });
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

        }
    }
}