namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableinaccount : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "AccountStatesId", "dbo.AccountStates");
            DropIndex("dbo.Accounts", new[] { "AccountStatesId" });
            AlterColumn("dbo.Accounts", "AccountStatesId", c => c.Int());
            AlterColumn("dbo.Accounts", "OrderToOpenId", c => c.Int());
            AlterColumn("dbo.Accounts", "OrderToCloseId", c => c.Int());
            CreateIndex("dbo.Accounts", "AccountStatesId");
            AddForeignKey("dbo.Accounts", "AccountStatesId", "dbo.AccountStates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "AccountStatesId", "dbo.AccountStates");
            DropIndex("dbo.Accounts", new[] { "AccountStatesId" });
            AlterColumn("dbo.Accounts", "OrderToCloseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Accounts", "OrderToOpenId", c => c.Int(nullable: false));
            AlterColumn("dbo.Accounts", "AccountStatesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Accounts", "AccountStatesId");
            AddForeignKey("dbo.Accounts", "AccountStatesId", "dbo.AccountStates", "Id", cascadeDelete: true);
        }
    }
}
