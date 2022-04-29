namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Member_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Member_Id)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberTypeId = c.Int(),
                        MemberCitizenId = c.Int(),
                        OrganizationTypeId = c.Int(),
                        FullName = c.String(),
                        ShortName = c.String(),
                        OGRN = c.String(maxLength: 13),
                        OGRNCreationDate = c.DateTime(),
                        RegNumber = c.String(maxLength: 100),
                        RegDate = c.DateTime(),
                        INN = c.String(maxLength: 10),
                        KPP = c.String(maxLength: 9),
                        OKVED = c.String(maxLength: 8),
                        LegalAddress = c.String(maxLength: 500),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Patronymic = c.String(maxLength: 100),
                        BirthDate = c.DateTime(),
                        PersonDocumentsTypesId = c.Int(nullable: false),
                        DocSeries = c.String(maxLength: 20),
                        DocNumber = c.String(maxLength: 25),
                        IssueDate = c.DateTime(),
                        SNILS = c.String(maxLength: 11),
                        LivingPlace = c.String(maxLength: 500),
                        PersonDocumentsTypes_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MemberCitizens", t => t.MemberCitizenId)
                .ForeignKey("dbo.MemberTypes", t => t.MemberTypeId)
                .ForeignKey("dbo.OrganizationTypes", t => t.OrganizationTypeId)
                .ForeignKey("dbo.PersonDocumentsTypes", t => t.PersonDocumentsTypes_Id)
                .Index(t => t.MemberTypeId)
                .Index(t => t.MemberCitizenId)
                .Index(t => t.OrganizationTypeId)
                .Index(t => t.PersonDocumentsTypes_Id);
            
            CreateTable(
                "dbo.MemberCitizens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MemberTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrganizationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonDocumentsTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "PersonDocumentsTypes_Id", "dbo.PersonDocumentsTypes");
            DropForeignKey("dbo.Members", "OrganizationTypeId", "dbo.OrganizationTypes");
            DropForeignKey("dbo.Members", "MemberTypeId", "dbo.MemberTypes");
            DropForeignKey("dbo.Members", "MemberCitizenId", "dbo.MemberCitizens");
            DropForeignKey("dbo.ContactPersons", "Member_Id", "dbo.Members");
            DropIndex("dbo.Members", new[] { "PersonDocumentsTypes_Id" });
            DropIndex("dbo.Members", new[] { "OrganizationTypeId" });
            DropIndex("dbo.Members", new[] { "MemberCitizenId" });
            DropIndex("dbo.Members", new[] { "MemberTypeId" });
            DropIndex("dbo.ContactPersons", new[] { "Member_Id" });
            DropTable("dbo.PersonDocumentsTypes");
            DropTable("dbo.OrganizationTypes");
            DropTable("dbo.MemberTypes");
            DropTable("dbo.MemberCitizens");
            DropTable("dbo.Members");
            DropTable("dbo.ContactPersons");
        }
    }
}
