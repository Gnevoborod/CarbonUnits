namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class systemdictis : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT MemberTypes ON");
            Sql("INSERT INTO MemberTypes (Id, Name) Values (0, 'Физическое лицо')");
            Sql("INSERT INTO MemberTypes (Id, Name) Values (1, 'Юридическое лицо')");
            Sql("INSERT INTO MemberTypes (Id, Name) Values (2, 'Индивидуальный предприниматель')");
           
            Sql("SET IDENTITY_INSERT MemberTypes OFF");
        }
        
        public override void Down()
        {
        }
    }
}
