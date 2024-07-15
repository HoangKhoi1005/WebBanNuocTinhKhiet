namespace WebBanNuocTinhKhiet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SANPHAM1", "MaChiTietSP", "dbo.CHITIETSP1");
            DropForeignKey("dbo.SANPHAM1", "MaThuongHieu", "dbo.THUONGHIEU1");
            DropIndex("dbo.SANPHAM1", new[] { "MaThuongHieu" });
            DropIndex("dbo.SANPHAM1", new[] { "MaChiTietSP" });
            AlterColumn("dbo.SANPHAM1", "TenSP", c => c.String(nullable: false));
            AlterColumn("dbo.SANPHAM1", "MoTa", c => c.String(nullable: false));
            AlterColumn("dbo.SANPHAM1", "DungTichSP", c => c.String(nullable: false));
            AlterColumn("dbo.SANPHAM1", "MaThuongHieu", c => c.Int(nullable: false));
            AlterColumn("dbo.SANPHAM1", "MaChiTietSP", c => c.Int(nullable: false));
            CreateIndex("dbo.SANPHAM1", "MaThuongHieu");
            CreateIndex("dbo.SANPHAM1", "MaChiTietSP");
            AddForeignKey("dbo.SANPHAM1", "MaChiTietSP", "dbo.CHITIETSP1", "MaChiTietSP", cascadeDelete: true);
            AddForeignKey("dbo.SANPHAM1", "MaThuongHieu", "dbo.THUONGHIEU1", "MaThuongHieu", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SANPHAM1", "MaThuongHieu", "dbo.THUONGHIEU1");
            DropForeignKey("dbo.SANPHAM1", "MaChiTietSP", "dbo.CHITIETSP1");
            DropIndex("dbo.SANPHAM1", new[] { "MaChiTietSP" });
            DropIndex("dbo.SANPHAM1", new[] { "MaThuongHieu" });
            AlterColumn("dbo.SANPHAM1", "MaChiTietSP", c => c.Int());
            AlterColumn("dbo.SANPHAM1", "MaThuongHieu", c => c.Int());
            AlterColumn("dbo.SANPHAM1", "DungTichSP", c => c.String());
            AlterColumn("dbo.SANPHAM1", "MoTa", c => c.String());
            AlterColumn("dbo.SANPHAM1", "TenSP", c => c.String());
            CreateIndex("dbo.SANPHAM1", "MaChiTietSP");
            CreateIndex("dbo.SANPHAM1", "MaThuongHieu");
            AddForeignKey("dbo.SANPHAM1", "MaThuongHieu", "dbo.THUONGHIEU1", "MaThuongHieu");
            AddForeignKey("dbo.SANPHAM1", "MaChiTietSP", "dbo.CHITIETSP1", "MaChiTietSP");
        }
    }
}
