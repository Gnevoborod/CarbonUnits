namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Services : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceCodes", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.ServiceCodes", "Updated", c => c.DateTime());
            AddColumn("dbo.ServiceCodes", "UserId", c => c.Int(nullable: true));
            AddColumn("dbo.ServicePurposes", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.ServicePurposes", "Updated", c => c.DateTime());
            AddColumn("dbo.ServicePurposes", "UserId", c => c.Int(nullable: true));
            CreateIndex("dbo.ServiceCodes", "UserId");
            CreateIndex("dbo.ServicePurposes", "UserId");
            AddForeignKey("dbo.ServiceCodes", "UserId", "dbo.Users", "Id", cascadeDelete: false);
            AddForeignKey("dbo.ServicePurposes", "UserId", "dbo.Users", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServicePurposes", "UserId", "dbo.Users");
            DropForeignKey("dbo.ServiceCodes", "UserId", "dbo.Users");
            DropIndex("dbo.ServicePurposes", new[] { "UserId" });
            DropIndex("dbo.ServiceCodes", new[] { "UserId" });
            DropColumn("dbo.ServicePurposes", "UserId");
            DropColumn("dbo.ServicePurposes", "Updated");
            DropColumn("dbo.ServicePurposes", "Created");
            DropColumn("dbo.ServiceCodes", "UserId");
            DropColumn("dbo.ServiceCodes", "Updated");
            DropColumn("dbo.ServiceCodes", "Created");
        }
    }
}
