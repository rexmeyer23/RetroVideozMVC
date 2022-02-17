namespace RetroVideoz.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VideoMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartLineItem", "VideoID", "dbo.Video");
            DropIndex("dbo.CartLineItem", new[] { "VideoID" });
            AlterColumn("dbo.CartLineItem", "VideoID", c => c.Int());
            CreateIndex("dbo.CartLineItem", "VideoID");
            AddForeignKey("dbo.CartLineItem", "VideoID", "dbo.Video", "VideoID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartLineItem", "VideoID", "dbo.Video");
            DropIndex("dbo.CartLineItem", new[] { "VideoID" });
            AlterColumn("dbo.CartLineItem", "VideoID", c => c.Int(nullable: false));
            CreateIndex("dbo.CartLineItem", "VideoID");
            AddForeignKey("dbo.CartLineItem", "VideoID", "dbo.Video", "VideoID", cascadeDelete: true);
        }
    }
}
