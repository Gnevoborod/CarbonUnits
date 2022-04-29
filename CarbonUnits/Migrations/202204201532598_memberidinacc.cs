namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class memberidinacc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "Member_Id", "dbo.Members");
            DropIndex("dbo.Accounts", new[] { "Member_Id" });
            RenameColumn(table: "dbo.Accounts", name: "Member_Id", newName: "MemberId");
            AlterColumn("dbo.Accounts", "MemberId", c => c.Int(nullable: false));
            CreateIndex("dbo.Accounts", "MemberId");
            AddForeignKey("dbo.Accounts", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "MemberId", "dbo.Members");
            DropIndex("dbo.Accounts", new[] { "MemberId" });
            AlterColumn("dbo.Accounts", "MemberId", c => c.Int());
            RenameColumn(table: "dbo.Accounts", name: "MemberId", newName: "Member_Id");
            CreateIndex("dbo.Accounts", "Member_Id");
            AddForeignKey("dbo.Accounts", "Member_Id", "dbo.Members", "Id");
        }
    }
}
