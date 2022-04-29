namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterdb : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER DATABASE [CarbonUnits.Models.CarbonUnitsContext] COLLATE Cyrillic_General_CI_AS; ");
            
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 1, 'Паспорт гражданина СССР')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 3, 'Свидетельство о рождении')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 5, 'Справка об освобождении из места лишения свободы')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 7, 'Военный билет')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 8, 'Временное удостоверение, выданное взамен военного билета')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 10, 'Паспорт иностранного гражданина')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 11, 'Свидетельство о рассмотрении ходатайства о признании лица беженцем на территории Российской Федерации по существу')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 12, 'Вид на жительство в Российской Федерации')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 13, 'Удостоверение беженца')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 14, 'Временное удостоверение личности гражданина Российской Федерации')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 15, 'Разрешение на временное проживание в Российской Федерации')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 18, 'Свидетельство о предоставлении временного убежища на территории Российской Федерации')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 21, 'Паспорт гражданина Российской Федерации'  )");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 23, 'Свидетельство о рождении, выданное уполномоченным органом иностранного государства')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 24, 'Удостоверение личности военнослужащего Российской Федерации')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 26, 'Паспорт моряка')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 27, 'Военный билет офицера запаса')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 60, 'Документы, подтверждающие факт регистрации по месту жительства')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 61, 'Свидетельство о регистрации по месту жительства')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 62, 'Вид на жительство иностранного гражданина')");
            Sql("INSERT INTO PersonDocumentsTypes (Id, Name) VALUES( 91,'Иные документы')");


        }

        public override void Down()
        {
        }
    }
}
