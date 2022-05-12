namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "CarbonUsers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CarbonUsers", newName: "Users");
        }
    }
}
