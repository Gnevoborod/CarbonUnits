namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountsInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identity = c.String(maxLength: 10),
                        AccountStatesId = c.Int(nullable: false),
                        DateOpen = c.DateTime(nullable: false),
                        OrderToOpenId = c.Int(nullable: false),
                        DateClose = c.DateTime(nullable: false),
                        OrderToCloseId = c.Int(nullable: false),
                        Agreement = c.String(maxLength: 10),
                        AgreementOpenDate = c.DateTime(nullable: false),
                        AgreementCloseDate = c.DateTime(nullable: false),
                        Member_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountStates", t => t.AccountStatesId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.Member_Id)
                .Index(t => t.AccountStatesId)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.AccountStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.Accounts", "AccountStatesId", "dbo.AccountStates");
            DropIndex("dbo.Accounts", new[] { "Member_Id" });
            DropIndex("dbo.Accounts", new[] { "AccountStatesId" });
            DropTable("dbo.AccountStates");
            DropTable("dbo.Accounts");
        }
    }
}
