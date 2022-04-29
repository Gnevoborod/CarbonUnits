namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembersContactPersons : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembersContactPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MembersContactPersons");
        }
    }
}
