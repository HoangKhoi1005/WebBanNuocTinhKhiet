namespace WebBanNuocTinhKhiet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.GIOHANG1",
            //    c => new
            //        {
            //            MaGH = c.Int(nullable: false, identity: true),
            //            TongTien = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            MaSP = c.Int(),
            //            SoLuong = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.MaGH)
            //    .ForeignKey("dbo.SANPHAM1", t => t.MaSP)
            //    .Index(t => t.MaSP);

            CreateTable(
                "dbo.AppUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Birthday = c.DateTime(),
                    Address = c.String(),
                    City = c.String(),
                    Email = c.String(),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(),
                    MaGH = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GIOHANG1", t => t.MaGH)
                .Index(t => t.MaGH);

            //CreateTable(
            //    "dbo.IdentityUserClaims",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserId = c.String(),
            //            ClaimType = c.String(),
            //            ClaimValue = c.String(),
            //            AppUser_Id = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.AppUsers", t => t.AppUser_Id)
            //    .Index(t => t.AppUser_Id);

            //CreateTable(
            //    "dbo.IdentityUserLogins",
            //    c => new
            //        {
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            LoginProvider = c.String(nullable: false, maxLength: 128),
            //            ProviderKey = c.String(nullable: false, maxLength: 128),
            //            AppUser_Id = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
            //    .ForeignKey("dbo.AppUsers", t => t.AppUser_Id)
            //    .Index(t => t.AppUser_Id);

            //CreateTable(
            //    "dbo.IdentityUserRoles",
            //    c => new
            //        {
            //            RoleId = c.String(nullable: false, maxLength: 128),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            AppUser_Id = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.RoleId, t.UserId })
            //    .ForeignKey("dbo.AppUsers", t => t.AppUser_Id)
            //    .Index(t => t.AppUser_Id);

        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.GIOHANG1", "MaSP", "dbo.SANPHAM1");
            //DropForeignKey("dbo.AppUsers", "MaGH", "dbo.GIOHANG1");
            //DropForeignKey("dbo.IdentityUserRoles", "AppUser_Id", "dbo.AppUsers");
            //DropForeignKey("dbo.IdentityUserLogins", "AppUser_Id", "dbo.AppUsers");
            //DropForeignKey("dbo.IdentityUserClaims", "AppUser_Id", "dbo.AppUsers");
            //DropIndex("dbo.IdentityUserRoles", new[] { "AppUser_Id" });
            //DropIndex("dbo.IdentityUserLogins", new[] { "AppUser_Id" });
            //DropIndex("dbo.IdentityUserClaims", new[] { "AppUser_Id" });
            //DropIndex("dbo.AppUsers", new[] { "MaGH" });
            //DropIndex("dbo.GIOHANG1", new[] { "MaSP" });
            //DropTable("dbo.IdentityUserRoles");
            //DropTable("dbo.IdentityUserLogins");
            //DropTable("dbo.IdentityUserClaims");
            //DropTable("dbo.AppUsers");
            //DropTable("dbo.GIOHANG1");
        }
    }
}
