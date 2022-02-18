namespace RetroVideoz.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartLineItem",
                c => new
                    {
                        CartItemID = c.Int(nullable: false, identity: true),
                        TotalQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VideoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartItemID)
                .ForeignKey("dbo.Video", t => t.VideoID, cascadeDelete: true)
                .Index(t => t.VideoID);
            
            CreateTable(
                "dbo.Video",
                c => new
                    {
                        VideoID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Genre = c.Int(nullable: false),
                        Format = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Image = c.Binary(),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.VideoID);
            
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CartID);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        ReviewHeader = c.String(nullable: false),
                        ReviewText = c.String(nullable: false),
                        StarRating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WouldRecommend = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        VideoID = c.Int(nullable: false),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Video", t => t.VideoID, cascadeDelete: true)
                .Index(t => t.VideoID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Review", "VideoID", "dbo.Video");
            DropForeignKey("dbo.CartLineItem", "VideoID", "dbo.Video");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Review", new[] { "VideoID" });
            DropIndex("dbo.CartLineItem", new[] { "VideoID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Review");
            DropTable("dbo.Cart");
            DropTable("dbo.Video");
            DropTable("dbo.CartLineItem");
        }
    }
}
