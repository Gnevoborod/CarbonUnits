namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentsProcessV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderProcessStatuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusCode = c.Byte(nullable: false),
                        Name = c.String(maxLength: 200),
                        Description = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderStateDescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identity = c.String(maxLength: 10),
                        OrderStateDescriptionId = c.Int(nullable: false),
                        CurrentState = c.Boolean(nullable: false),
                        Description = c.String(),
                        UserId = c.Int(nullable: false),
                        SetDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderStateDescriptions", t => t.OrderStateDescriptionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.OrderStateDescriptionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);


            //SQL area

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderStates", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderStates", "OrderStateDescriptionId", "dbo.OrderStateDescriptions");
            DropIndex("dbo.OrderStates", new[] { "UserId" });
            DropIndex("dbo.OrderStates", new[] { "OrderStateDescriptionId" });
            DropTable("dbo.Users");
            DropTable("dbo.OrderStates");
            DropTable("dbo.OrderStateDescriptions");
            DropTable("dbo.OrderProcessStatuses");
        }
    }
}
