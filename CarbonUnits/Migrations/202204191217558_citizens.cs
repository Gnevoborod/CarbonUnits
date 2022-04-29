namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class citizens : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT MemberCitizens ON");
            Sql("INSERT INTO MemberCitizens (Id, Name) Values (0, 'Российское')");
            Sql("INSERT INTO MemberCitizens (Id, Name) Values (1, 'Иностранное')");
            Sql("SET IDENTITY_INSERT MemberCitizens OFF");
        }
        
        public override void Down()
        {
        }
    }
}
