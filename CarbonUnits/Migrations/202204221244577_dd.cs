namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServicePurposes", "IODocumentsTypesID", "dbo.IODocumentsTypes");
            DropIndex("dbo.ServicePurposes", new[] { "IODocumentsTypesID" });
            AlterColumn("dbo.ServicePurposes", "IODocumentsTypesID", c => c.Int());
            CreateIndex("dbo.ServicePurposes", "IODocumentsTypesID");
            AddForeignKey("dbo.ServicePurposes", "IODocumentsTypesID", "dbo.IODocumentsTypes", "Id");



            //SQL area

            Sql("SET IDENTITY_INSERT OrderStateDescriptions ON");

            Sql("INSERT INTO OrderStateDescriptions (Id,  Name) values(0,'Добавлен. Не пройдены проверки')");
            Sql("INSERT INTO OrderStateDescriptions (Id,  Name) values(1,'Добавлен. Требуется передача на верификацию')");
            Sql("INSERT INTO OrderStateDescriptions (Id,  Name) values(2,'Добавлен. Требуется верификация')");
            Sql("INSERT INTO OrderStateDescriptions (Id,  Name) values(3,'Добавлен. Не верифицирован')");
            Sql("INSERT INTO OrderStateDescriptions (Id,  Name) values(4,'Добавлен. Требуется передача на исполнение')");
            Sql("INSERT INTO OrderStateDescriptions (Id,  Name) values(5,'Передан на отклонение. Требуется верификация')");
            Sql("INSERT INTO OrderStateDescriptions (Id,  Name) values(6,'Передан на отклонение. Не верифицирован')");
            Sql("INSERT INTO OrderStateDescriptions (Id,  Name) values(7,'Передан на исполнение. Требуется верификация')");
            Sql("INSERT INTO OrderStateDescriptions (Id,  Name) values(8,'Передан на исполнение. Не верифицирован')");
            Sql("INSERT INTO OrderStateDescriptions (Id,  Name) values(9,'На исполнении')");
            Sql("INSERT INTO OrderStateDescriptions (Id,  Name) values(10,'Отклонен')");
            Sql("INSERT INTO OrderStateDescriptions (Id,  Name) values(11,'Исполнен')");

            Sql("SET IDENTITY_INSERT OrderStateDescriptions OFF");

            Sql("SET IDENTITY_INSERT ServiceCodes ON");
            Sql("INSERT INTO ServiceCodes (Id, ServiceCode, Description) values(0,'000001','Заключение договора с оператором реестра и открытие счета участника обращения углеродных единиц')");
            Sql("INSERT INTO ServiceCodes (Id, ServiceCode, Description) values(1,'000002','Изменение данных об участнике обращения углеродных единиц')");
            Sql("INSERT INTO ServiceCodes (Id, ServiceCode, Description) values(2,'000003','Расторжение договора с оператором реестра и закрытие счета участника обращения углеродных единиц')");
            Sql("INSERT INTO ServiceCodes (Id, ServiceCode, Description) values(3,'000004','Регистрация климатического проекта')");
            Sql("INSERT INTO ServiceCodes (Id, ServiceCode, Description) values(4,'000005','Изменение данных о климатическом проекте')");
            Sql("INSERT INTO ServiceCodes (Id, ServiceCode, Description) values(5,'000006','Исключение данных о климатическом проекте')");
            Sql("INSERT INTO ServiceCodes (Id, ServiceCode, Description) values(6,'000007','Регистрация и зачисление углеродных единиц')");
            Sql("INSERT INTO ServiceCodes (Id, ServiceCode, Description) values(7,'000008','Передача углеродных единиц')");
            Sql("INSERT INTO ServiceCodes (Id, ServiceCode, Description) values(8,'000009','Зачет углеродных единиц')");
            Sql("INSERT INTO ServiceCodes (Id, ServiceCode, Description) values(9,'000010','Вывод углеродных единиц к организатору торговли')");
            Sql("INSERT INTO ServiceCodes (Id, ServiceCode, Description) values(10,'000011','Вывод углеродных единиц от организатора торговли')");
            Sql("INSERT INTO ServiceCodes (Id, ServiceCode, Description) values(11,'000012','Получение выписки из реестра')");
            Sql("INSERT INTO ServiceCodes (Id, ServiceCode, Description) values(12,'000013','Обременение углеродных единиц')");
            Sql("INSERT INTO ServiceCodes (Id, ServiceCode, Description) values(13,'000014','Снятие обременения c углеродных единиц')");
            Sql("INSERT INTO ServiceCodes (Id, ServiceCode, Description) values(14,'000015','Получение отчета по климатическим проектам, выпущенным, переданным и зачтенным углеродным единицам')");
            Sql("INSERT INTO ServiceCodes (Id, ServiceCode, Description) values(15,'000016','Предоставление отчета по климатическим проектам, выпущенным, переданным и зачтенным углеродным единицам')");
            Sql("INSERT INTO ServiceCodes (Id, ServiceCode, Description) values(16,'000017','Приостановка операций по счету')");
            Sql("INSERT INTO ServiceCodes (Id, ServiceCode, Description) values(17,'000018','Отмена приостановки операций по счету')");
            Sql("SET IDENTITY_INSERT ServiceCodes OFF");


            Sql("SET IDENTITY_INSERT ServicePurposes ON");
            Sql("INSERT INTO ServicePurposes (Id, ServiceCodesId, ServicePurposeCode,Description,IODocumentsTypesID) values(0,0,'00000101','Заключение договора с оператором реестра и открытие счета участника обращения углеродных единиц',0)");
            Sql("INSERT INTO ServicePurposes (Id, ServiceCodesId, ServicePurposeCode,Description,IODocumentsTypesID) values(1,1,'00000201','Изменение данных об участнике обращения углеродных единиц',1)");
            Sql("INSERT INTO ServicePurposes (Id, ServiceCodesId, ServicePurposeCode,Description,IODocumentsTypesID) values(2,2,'00000301','Расторжение договора с оператором реестра и закрытие счета участника обращения углеродных единиц',2)");
            Sql("INSERT INTO ServicePurposes (Id, ServiceCodesId, ServicePurposeCode,Description,IODocumentsTypesID) values(3,3,'00000401','Регистрация климатического проекта',3)");
            Sql("INSERT INTO ServicePurposes (Id, ServiceCodesId, ServicePurposeCode,Description,IODocumentsTypesID) values(4,4,'00000501','Изменение данных о климатическом проекте',4)");
            Sql("INSERT INTO ServicePurposes (Id, ServiceCodesId, ServicePurposeCode,Description,IODocumentsTypesID) values(5,5,'00000601','Исключение данных о климатическом проекте',5)");
            Sql("INSERT INTO ServicePurposes (Id, ServiceCodesId, ServicePurposeCode,Description,IODocumentsTypesID) values(6,6,'00000701','Регистрация и зачисление углеродных единиц',6)");
            Sql("INSERT INTO ServicePurposes (Id, ServiceCodesId, ServicePurposeCode,Description,IODocumentsTypesID) values(7,7,'00000801','Передача углеродных единиц',7)");
            Sql("INSERT INTO ServicePurposes (Id, ServiceCodesId, ServicePurposeCode,Description,IODocumentsTypesID) values(8,8,'00000901','Зачет углеродных единиц',8)");
            Sql("INSERT INTO ServicePurposes (Id, ServiceCodesId, ServicePurposeCode,Description,IODocumentsTypesID) values(9,9,'00001001','Вывод углеродных единиц к организатору торговли',9)");
            Sql("INSERT INTO ServicePurposes (Id, ServiceCodesId, ServicePurposeCode,Description,IODocumentsTypesID) values(10,10,'00001101','Вывод углеродных единиц от организатора торговли',10)");
            Sql("INSERT INTO ServicePurposes (Id, ServiceCodesId, ServicePurposeCode,Description,IODocumentsTypesID) values(11,11,'00001201','Получение выписки из реестра',11)");
            Sql("INSERT INTO ServicePurposes (Id, ServiceCodesId, ServicePurposeCode,Description,IODocumentsTypesID) values(12,12,'00001301','Обременение углеродных единиц',12)");
            Sql("INSERT INTO ServicePurposes (Id, ServiceCodesId, ServicePurposeCode,Description,IODocumentsTypesID) values(13,13,'00001401','Снятие обременения c углеродных единиц',13)");
            Sql("INSERT INTO ServicePurposes (Id, ServiceCodesId, ServicePurposeCode,Description,IODocumentsTypesID) values(14,14,'00001501','Получение отчета по климатическим проектам, выпущенным, переданным и зачтенным углеродным единицам',14)");
            Sql("INSERT INTO ServicePurposes (Id, ServiceCodesId, ServicePurposeCode,Description,IODocumentsTypesID) values(15,15,'00001601','Предоставление отчета по климатическим проектам, выпущенным, переданным и зачтенным углеродным единицам',null)");
            Sql("INSERT INTO ServicePurposes (Id, ServiceCodesId, ServicePurposeCode,Description,IODocumentsTypesID) values(16,16,'00001701','Приостановка операций по счету',null)");
            Sql("INSERT INTO ServicePurposes (Id, ServiceCodesId, ServicePurposeCode,Description,IODocumentsTypesID) values(17,17,'00001801','Отмена приостановки операций по счету',null)");
            Sql("SET IDENTITY_INSERT ServicePurposes OFF");

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServicePurposes", "IODocumentsTypesID", "dbo.IODocumentsTypes");
            DropIndex("dbo.ServicePurposes", new[] { "IODocumentsTypesID" });
            AlterColumn("dbo.ServicePurposes", "IODocumentsTypesID", c => c.Int(nullable: false));
            CreateIndex("dbo.ServicePurposes", "IODocumentsTypesID");
            AddForeignKey("dbo.ServicePurposes", "IODocumentsTypesID", "dbo.IODocumentsTypes", "Id", cascadeDelete: true);
        }
    }
}
