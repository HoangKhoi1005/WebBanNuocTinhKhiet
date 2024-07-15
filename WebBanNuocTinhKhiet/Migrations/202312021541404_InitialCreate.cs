namespace WebBanNuocTinhKhiet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CHITIETSP1",
                c => new
                    {
                        MaChiTietSP = c.Int(nullable: false, identity: true),
                        LoaiSP = c.String(),
                    })
                .PrimaryKey(t => t.MaChiTietSP);
            
            CreateTable(
                "dbo.SANPHAM1",
                c => new
                    {
                        MaSP = c.Int(nullable: false, identity: true),
                        TenSP = c.String(),
                        GiaCu = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GiaDB = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Anh = c.String(),
                        MoTa = c.String(),
                        NgaySX = c.DateTime(nullable: false),
                        Anh2 = c.String(),
                        DungTichSP = c.String(),
                        MaThuongHieu = c.Int(),
                        MaChiTietSP = c.Int(),
                    })
                .PrimaryKey(t => t.MaSP)
                .ForeignKey("dbo.CHITIETSP1", t => t.MaChiTietSP)
                .ForeignKey("dbo.THUONGHIEU1", t => t.MaThuongHieu)
                .Index(t => t.MaThuongHieu)
                .Index(t => t.MaChiTietSP);
            
            CreateTable(
                "dbo.THUONGHIEU1",
                c => new
                    {
                        MaThuongHieu = c.Int(nullable: false, identity: true),
                        TenThuongHieu = c.String(),
                    })
                .PrimaryKey(t => t.MaThuongHieu);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SANPHAM1", "MaThuongHieu", "dbo.THUONGHIEU1");
            DropForeignKey("dbo.SANPHAM1", "MaChiTietSP", "dbo.CHITIETSP1");
            DropIndex("dbo.SANPHAM1", new[] { "MaChiTietSP" });
            DropIndex("dbo.SANPHAM1", new[] { "MaThuongHieu" });
            DropTable("dbo.THUONGHIEU1");
            DropTable("dbo.SANPHAM1");
            DropTable("dbo.CHITIETSP1");
        }
    }
}
