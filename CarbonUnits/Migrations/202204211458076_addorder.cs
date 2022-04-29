namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountBusinessDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        Identity = c.String(maxLength: 10),
                        AccountStatesId = c.Int(),
                        DateOpen = c.DateTime(),
                        OrderToOpenId = c.Int(),
                        DateClose = c.DateTime(),
                        OrderToCloseId = c.Int(),
                        Agreement = c.String(maxLength: 10),
                        AgreementOpenDate = c.DateTime(),
                        AgreementCloseDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountStates", t => t.AccountStatesId)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderToCloseId)
                .ForeignKey("dbo.Orders", t => t.OrderToOpenId)
                .Index(t => t.MemberId)
                .Index(t => t.AccountStatesId)
                .Index(t => t.OrderToOpenId)
                .Index(t => t.OrderToCloseId);
            
            CreateTable(
                "dbo.IODocumentsTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 20),
                        Name = c.String(maxLength: 4000),
                        isIn = c.Boolean(nullable: false),
                        Process = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceCode = c.String(maxLength: 20),
                        Description = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServicePurposes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceCodesId = c.Int(nullable: false),
                        ServicePurposeCode = c.String(maxLength: 20),
                        Description = c.String(maxLength: 4000),
                        IODocumentsTypesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IODocumentsTypes", t => t.IODocumentsTypesID, cascadeDelete: false)
                .ForeignKey("dbo.ServiceCodes", t => t.ServiceCodesId, cascadeDelete: false)
                .Index(t => t.ServiceCodesId)
                .Index(t => t.IODocumentsTypesID);
            
            CreateTable(
                "dbo.MemberBusinessDatas",
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MemberCitizens", t => t.MemberCitizenId)
                .ForeignKey("dbo.MemberTypes", t => t.MemberTypeId)
                .ForeignKey("dbo.OrganizationTypes", t => t.OrganizationTypeId)
                .ForeignKey("dbo.PersonDocumentsTypes", t => t.PersonDocumentsTypesId, cascadeDelete: true)
                .Index(t => t.MemberTypeId)
                .Index(t => t.MemberCitizenId)
                .Index(t => t.OrganizationTypeId)
                .Index(t => t.PersonDocumentsTypesId);
            
            AddColumn("dbo.ContactPersons", "MemberBusinessData_Id", c => c.Int());
            AddColumn("dbo.Orders", "IODocumentsTypesId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "isIn", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "RegDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "ExternalIdentity", c => c.String());
            AddColumn("dbo.Orders", "ExternalRegDate", c => c.DateTime());
            AddColumn("dbo.Orders", "ServiceCodeNotInDicti", c => c.String());
            AddColumn("dbo.Orders", "ServiceCodeId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ServicePurposeNotInDicti", c => c.String());
            AddColumn("dbo.Orders", "ServicePurposeId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "RegistrationRegime", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "Channel", c => c.Boolean(nullable: false));
            CreateIndex("dbo.ContactPersons", "MemberBusinessData_Id");
            CreateIndex("dbo.Orders", "IODocumentsTypesId");
            CreateIndex("dbo.Orders", "ServiceCodeId");
            CreateIndex("dbo.Orders", "ServicePurposeId");
            AddForeignKey("dbo.Orders", "IODocumentsTypesId", "dbo.IODocumentsTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ServiceCodeId", "dbo.ServiceCodes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ServicePurposeId", "dbo.ServicePurposes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ContactPersons", "MemberBusinessData_Id", "dbo.MemberBusinessDatas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MemberBusinessDatas", "PersonDocumentsTypesId", "dbo.PersonDocumentsTypes");
            DropForeignKey("dbo.MemberBusinessDatas", "OrganizationTypeId", "dbo.OrganizationTypes");
            DropForeignKey("dbo.MemberBusinessDatas", "MemberTypeId", "dbo.MemberTypes");
            DropForeignKey("dbo.MemberBusinessDatas", "MemberCitizenId", "dbo.MemberCitizens");
            DropForeignKey("dbo.ContactPersons", "MemberBusinessData_Id", "dbo.MemberBusinessDatas");
            DropForeignKey("dbo.AccountBusinessDatas", "OrderToOpenId", "dbo.Orders");
            DropForeignKey("dbo.AccountBusinessDatas", "OrderToCloseId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ServicePurposeId", "dbo.ServicePurposes");
            DropForeignKey("dbo.ServicePurposes", "ServiceCodesId", "dbo.ServiceCodes");
            DropForeignKey("dbo.ServicePurposes", "IODocumentsTypesID", "dbo.IODocumentsTypes");
            DropForeignKey("dbo.Orders", "ServiceCodeId", "dbo.ServiceCodes");
            DropForeignKey("dbo.Orders", "IODocumentsTypesId", "dbo.IODocumentsTypes");
            DropForeignKey("dbo.AccountBusinessDatas", "MemberId", "dbo.Members");
            DropForeignKey("dbo.AccountBusinessDatas", "AccountStatesId", "dbo.AccountStates");
            DropIndex("dbo.MemberBusinessDatas", new[] { "PersonDocumentsTypesId" });
            DropIndex("dbo.MemberBusinessDatas", new[] { "OrganizationTypeId" });
            DropIndex("dbo.MemberBusinessDatas", new[] { "MemberCitizenId" });
            DropIndex("dbo.MemberBusinessDatas", new[] { "MemberTypeId" });
            DropIndex("dbo.ServicePurposes", new[] { "IODocumentsTypesID" });
            DropIndex("dbo.ServicePurposes", new[] { "ServiceCodesId" });
            DropIndex("dbo.Orders", new[] { "ServicePurposeId" });
            DropIndex("dbo.Orders", new[] { "ServiceCodeId" });
            DropIndex("dbo.Orders", new[] { "IODocumentsTypesId" });
            DropIndex("dbo.ContactPersons", new[] { "MemberBusinessData_Id" });
            DropIndex("dbo.AccountBusinessDatas", new[] { "OrderToCloseId" });
            DropIndex("dbo.AccountBusinessDatas", new[] { "OrderToOpenId" });
            DropIndex("dbo.AccountBusinessDatas", new[] { "AccountStatesId" });
            DropIndex("dbo.AccountBusinessDatas", new[] { "MemberId" });
            DropColumn("dbo.Orders", "Channel");
            DropColumn("dbo.Orders", "RegistrationRegime");
            DropColumn("dbo.Orders", "ServicePurposeId");
            DropColumn("dbo.Orders", "ServicePurposeNotInDicti");
            DropColumn("dbo.Orders", "ServiceCodeId");
            DropColumn("dbo.Orders", "ServiceCodeNotInDicti");
            DropColumn("dbo.Orders", "ExternalRegDate");
            DropColumn("dbo.Orders", "ExternalIdentity");
            DropColumn("dbo.Orders", "RegDate");
            DropColumn("dbo.Orders", "isIn");
            DropColumn("dbo.Orders", "IODocumentsTypesId");
            DropColumn("dbo.ContactPersons", "MemberBusinessData_Id");
            DropTable("dbo.MemberBusinessDatas");
            DropTable("dbo.ServicePurposes");
            DropTable("dbo.ServiceCodes");
            DropTable("dbo.IODocumentsTypes");
            DropTable("dbo.AccountBusinessDatas");
        }
    }
}
