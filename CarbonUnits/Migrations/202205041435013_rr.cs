namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rr : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CarbonUsers", newName: "Users");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Users", newName: "CarbonUsers");
        }
    }
}
