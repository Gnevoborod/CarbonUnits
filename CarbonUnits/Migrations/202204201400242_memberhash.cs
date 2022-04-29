namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class memberhash : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberHashes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        HashNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MemberHashes", "MemberId", "dbo.Members");
            DropIndex("dbo.MemberHashes", new[] { "MemberId" });
            DropTable("dbo.MemberHashes");
        }
    }
}
