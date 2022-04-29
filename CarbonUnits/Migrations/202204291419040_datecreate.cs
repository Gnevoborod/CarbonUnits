namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datecreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "DateCreate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "DateCreate");
        }
    }
}
