namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accstate : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT AccountStates ON");
            Sql("INSERT INTO AccountStates (Id, Name) VALUES (0,'Открыт')");
            Sql("INSERT INTO AccountStates (Id, Name) VALUES (1,'Закрыт')");
            Sql("SET IDENTITY_INSERT AccountStates OFF");
        }
        
        public override void Down()
        {
        }
    }
}
