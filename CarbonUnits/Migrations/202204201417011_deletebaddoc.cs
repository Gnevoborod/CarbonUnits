namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletebaddoc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "PersonDocumentsTypes_Id", "dbo.PersonDocumentsTypes");
            DropIndex("dbo.Members", new[] { "PersonDocumentsTypes_Id" });
            DropColumn("dbo.Members", "PersonDocumentsTypes_Id");
            DropPrimaryKey("dbo.PersonDocumentsTypes");
            AlterColumn("dbo.Members", "PersonDocumentsTypesId", c => c.Int(nullable: false));
            AlterColumn("dbo.PersonDocumentsTypes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PersonDocumentsTypes", "Id");
            CreateIndex("dbo.Members", "PersonDocumentsTypesId");
            AddForeignKey("dbo.Members", "PersonDocumentsTypesId", "dbo.PersonDocumentsTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "PersonDocumentsTypesId", "dbo.PersonDocumentsTypes");
            DropIndex("dbo.Members", new[] { "PersonDocumentsTypesId" });
            DropPrimaryKey("dbo.PersonDocumentsTypes");
            AlterColumn("dbo.PersonDocumentsTypes", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Members", "PersonDocumentsTypesId", c => c.Byte());
            AddPrimaryKey("dbo.PersonDocumentsTypes_Id", "Id");
            AddColumn("dbo.Members", "PersonDocumentsTypesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "PersonDocumentsTypes_Id");
            AddForeignKey("dbo.Members", "PersonDocumentsTypes_Id", "dbo.PersonDocumentsTypes", "Id");
        }
    }
}
