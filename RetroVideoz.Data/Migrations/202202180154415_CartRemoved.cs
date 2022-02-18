namespace RetroVideoz.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartRemoved : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Cart");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CartID);
            
        }
    }
}
