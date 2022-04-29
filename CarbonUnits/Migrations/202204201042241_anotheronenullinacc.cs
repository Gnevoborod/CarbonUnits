namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotheronenullinacc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "DateOpen", c => c.DateTime());
            AlterColumn("dbo.Accounts", "DateClose", c => c.DateTime());
            AlterColumn("dbo.Accounts", "AgreementOpenDate", c => c.DateTime());
            AlterColumn("dbo.Accounts", "AgreementCloseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "AgreementCloseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Accounts", "AgreementOpenDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Accounts", "DateClose", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Accounts", "DateOpen", c => c.DateTime(nullable: false));
        }
    }
}
