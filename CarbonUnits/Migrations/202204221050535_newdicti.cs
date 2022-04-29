namespace CarbonUnits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdicti : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT IODocumentsTypes ON");
            Sql("INSERT INTO IODocumentsTypes (Id, Code, Name, isIn, Process) values(0,'ЗаявлОткрытиеСчета','Заявление о заключении договора с оператором реестра и открытии счета участника обращения углеродных единиц',1,'ОткрытиеСчета')");
            Sql("INSERT INTO IODocumentsTypes (Id, Code, Name, isIn, Process) values(1,'ЗаявлРегистрацияКП','Заявление о регистрации климатического проекта',1,'РегистрацияКП')");
            Sql("INSERT INTO IODocumentsTypes (Id, Code, Name, isIn, Process) values(2,'РаспЗачислениеУЕ','Распоряжение о регистрации и зачислении углеродных единиц',1,'ЗачислениеУЕ')");
            Sql("INSERT INTO IODocumentsTypes (Id, Code, Name, isIn, Process) values(3,'ЗаявлИзмУчастника','Заявление об изменении данных об участнике обращения углеродных единиц',1,'')");
            Sql("INSERT INTO IODocumentsTypes (Id, Code, Name, isIn, Process) values(4,'ЗаявлИзмКП','Заявление об изменении данных о климатическом проекте',1,'')");
            Sql("INSERT INTO IODocumentsTypes (Id, Code, Name, isIn, Process) values(5,'ЗаявлИсклКП','Заявление об исключении данных о климатическом проекте',1,'')");
            Sql("INSERT INTO IODocumentsTypes (Id, Code, Name, isIn, Process) values(6,'РаспПередачаУЕ','Распоряжение о передаче углеродных единиц',1,'')");
            Sql("INSERT INTO IODocumentsTypes (Id, Code, Name, isIn, Process) values(7,'РаспЗачетУЕ','Распоряжение о зачете углеродных единиц',1,'')");
            Sql("INSERT INTO IODocumentsTypes (Id, Code, Name, isIn, Process) values(8,'ЗаявлКОргТорговли','Заявление о выводе углеродных единиц к организатору торговли',1,'')");
            Sql("INSERT INTO IODocumentsTypes (Id, Code, Name, isIn, Process) values(9,'ЗаявлОтОргТорговли','Заявление о выводе углеродных единиц от организатора торговли',1,'')");
            Sql("INSERT INTO IODocumentsTypes (Id, Code, Name, isIn, Process) values(10,'ЗаявлОбремУЕ','Заявление об обременении углеродных единиц',1,'')");
            Sql("INSERT INTO IODocumentsTypes (Id, Code, Name, isIn, Process) values(11,'ЗаявлСнятОбремУЕ','Заявление о снятии обременения с углеродных единиц',1,'')");
            Sql("INSERT INTO IODocumentsTypes (Id, Code, Name, isIn, Process) values(12,'ЗаявлЗакрытиеСчета','Заявление (распоряжение) на расторжение договора с оператором реестра и закрытие счета участника',1,'')");
            Sql("INSERT INTO IODocumentsTypes (Id, Code, Name, isIn, Process) values(13,'ЗаявлПолучВыписки','Заявление о получении выписки из реестра',1,'')");
            Sql("INSERT INTO IODocumentsTypes (Id, Code, Name, isIn, Process) values(14,'ЗаявлПолучОтчета','Заявление о получении отчета по климатическим проектам, выпущенным, переданным и зачтенным углеродным единицам',1,'')");
            Sql("INSERT INTO IODocumentsTypes (Id, Code, Name, isIn, Process) values(15,'ДокументОператора','Документ оператора реестра',1,'')");

            Sql("SET IDENTITY_INSERT IODocumentsTypes OFF");
        }

        public override void Down()
        {
        }
    }
}
