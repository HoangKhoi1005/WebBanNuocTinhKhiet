namespace WebBanNuocTinhKhiet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart1 : DbMigration
    {
        public override void Up()
        {
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
        }
        
        public override void Down()
        {
        }
    }
}
