namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idinaccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "IdentityThroughYears", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "IdentityThroughYears");
        }
    }
}
