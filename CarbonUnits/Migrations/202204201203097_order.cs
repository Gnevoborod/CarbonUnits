namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Accounts", "OrderToOpenId");
            CreateIndex("dbo.Accounts", "OrderToCloseId");
            AddForeignKey("dbo.Accounts", "OrderToCloseId", "dbo.Orders", "Id");
            AddForeignKey("dbo.Accounts", "OrderToOpenId", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "OrderToOpenId", "dbo.Orders");
            DropForeignKey("dbo.Accounts", "OrderToCloseId", "dbo.Orders");
            DropIndex("dbo.Accounts", new[] { "OrderToCloseId" });
            DropIndex("dbo.Accounts", new[] { "OrderToOpenId" });
            DropTable("dbo.Orders");
        }
    }
}
