namespace WebBanNuocTinhKhiet.IdentityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GIOHANG1",
                c => new
                    {
                        MaGH = c.Int(nullable: false, identity: true),
                        TongTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaSP = c.Int(),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaGH)
                .ForeignKey("dbo.SANPHAM1", t => t.MaSP)
                .Index(t => t.MaSP);
            
            //CreateTable(
            //    "dbo.SANPHAM1",
            //    c => new
            //        {
            //            MaSP = c.Int(nullable: false, identity: true),
            //            TenSP = c.String(nullable: false),
            //            GiaCu = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            GiaDB = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Anh = c.String(),
            //            MoTa = c.String(nullable: false),
            //            NgaySX = c.DateTime(nullable: false),
            //            Anh2 = c.String(),
            //            DungTichSP = c.String(nullable: false),
            //            MaThuongHieu = c.Int(nullable: false),
            //            MaChiTietSP = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.MaSP)
            //    .ForeignKey("dbo.CHITIETSP1", t => t.MaChiTietSP, cascadeDelete: true)
            //    .ForeignKey("dbo.THUONGHIEU1", t => t.MaThuongHieu, cascadeDelete: true)
            //    .Index(t => t.MaThuongHieu)
            //    .Index(t => t.MaChiTietSP);
            
            //CreateTable(
            //    "dbo.CHITIETSP1",
            //    c => new
            //        {
            //            MaChiTietSP = c.Int(nullable: false, identity: true),
            //            LoaiSP = c.String(),
            //        })
            //    .PrimaryKey(t => t.MaChiTietSP);
            
            //CreateTable(
            //    "dbo.THUONGHIEU1",
            //    c => new
            //        {
            //            MaThuongHieu = c.Int(nullable: false, identity: true),
            //            TenThuongHieu = c.String(),
            //        })
            //    .PrimaryKey(t => t.MaThuongHieu);
            
            //AddColumn("dbo.AspNetUsers", "MaGH", c => c.Int(nullable: false));
            //CreateIndex("dbo.AspNetUsers", "MaGH");
            //AddForeignKey("dbo.AspNetUsers", "MaGH", "dbo.GIOHANG1", "MaGH");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GIOHANG1", "MaSP", "dbo.SANPHAM1");
            DropForeignKey("dbo.SANPHAM1", "MaThuongHieu", "dbo.THUONGHIEU1");
            DropForeignKey("dbo.SANPHAM1", "MaChiTietSP", "dbo.CHITIETSP1");
            DropForeignKey("dbo.AspNetUsers", "MaGH", "dbo.GIOHANG1");
            DropIndex("dbo.SANPHAM1", new[] { "MaChiTietSP" });
            DropIndex("dbo.SANPHAM1", new[] { "MaThuongHieu" });
            DropIndex("dbo.AspNetUsers", new[] { "MaGH" });
            DropIndex("dbo.GIOHANG1", new[] { "MaSP" });
            DropColumn("dbo.AspNetUsers", "MaGH");
            DropTable("dbo.THUONGHIEU1");
            DropTable("dbo.CHITIETSP1");
            DropTable("dbo.SANPHAM1");
            DropTable("dbo.GIOHANG1");
        }
    }
}
