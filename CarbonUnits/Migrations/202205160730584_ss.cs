namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceCodes", "UserId", "dbo.Users");
            DropForeignKey("dbo.ServicePurposes", "UserId", "dbo.Users");
            DropIndex("dbo.ServiceCodes", new[] { "UserId" });
            DropIndex("dbo.ServicePurposes", new[] { "UserId" });
            AddColumn("dbo.PersonDocumentsTypes", "Code", c => c.Int(nullable: false));
            AddColumn("dbo.PersonDocumentsTypes", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.PersonDocumentsTypes", "Updated", c => c.DateTime());
            AddColumn("dbo.PersonDocumentsTypes", "UserId", c => c.Int());
            AddColumn("dbo.IODocumentsTypes", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.IODocumentsTypes", "Updated", c => c.DateTime());
            AddColumn("dbo.IODocumentsTypes", "UserId", c => c.Int());
            AlterColumn("dbo.PersonDocumentsTypes", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.ServiceCodes", "UserId", c => c.Int());
            AlterColumn("dbo.ServicePurposes", "UserId", c => c.Int());
            CreateIndex("dbo.PersonDocumentsTypes", "UserId");
            CreateIndex("dbo.IODocumentsTypes", "UserId");
            CreateIndex("dbo.ServiceCodes", "UserId");
            CreateIndex("dbo.ServicePurposes", "UserId");
            AddForeignKey("dbo.PersonDocumentsTypes", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.IODocumentsTypes", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.ServiceCodes", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.ServicePurposes", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServicePurposes", "UserId", "dbo.Users");
            DropForeignKey("dbo.ServiceCodes", "UserId", "dbo.Users");
            DropForeignKey("dbo.IODocumentsTypes", "UserId", "dbo.Users");
            DropForeignKey("dbo.PersonDocumentsTypes", "UserId", "dbo.Users");
            DropIndex("dbo.ServicePurposes", new[] { "UserId" });
            DropIndex("dbo.ServiceCodes", new[] { "UserId" });
            DropIndex("dbo.IODocumentsTypes", new[] { "UserId" });
            DropIndex("dbo.PersonDocumentsTypes", new[] { "UserId" });
            AlterColumn("dbo.ServicePurposes", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.ServiceCodes", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.PersonDocumentsTypes", "Name", c => c.String());
            DropColumn("dbo.IODocumentsTypes", "UserId");
            DropColumn("dbo.IODocumentsTypes", "Updated");
            DropColumn("dbo.IODocumentsTypes", "Created");
            DropColumn("dbo.PersonDocumentsTypes", "UserId");
            DropColumn("dbo.PersonDocumentsTypes", "Updated");
            DropColumn("dbo.PersonDocumentsTypes", "Created");
            DropColumn("dbo.PersonDocumentsTypes", "Code");
            CreateIndex("dbo.ServicePurposes", "UserId");
            CreateIndex("dbo.ServiceCodes", "UserId");
            AddForeignKey("dbo.ServicePurposes", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ServiceCodes", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
