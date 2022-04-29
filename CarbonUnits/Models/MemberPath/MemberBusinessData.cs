using System.ComponentModel.DataAnnotations;
using CarbonUnits.Models.Dictionaries;
namespace CarbonUnits.Models.MemberPath
{
    public class MemberBusinessData
    {
        public int Id { get; set; }
        public MemberType MemberType { get; set; }//Тип лица - физическое, юридическое, ИП
        public int? MemberTypeId { get; set; }
        public MemberCitizen MemberCitizen { get; set; }////Признак лица: Российское или иностранное

        public int? MemberCitizenId { get; set; }
        public OrganizationType OrganizationType { get; set; }//ОПФ
        public int? OrganizationTypeId { get; set; }
        public string FullName { get; set; }//Полное наименование
        public string ShortName { get; set; }//Сокращенное наименование
        [MaxLength(13)]
        public string OGRN { get; set; }//ОГРН
        public DateTime? OGRNCreationDate { get; set; }//Дата присвоения ОГРН
        [MaxLength(100)]
        public string RegNumber { get; set; }//Регистрационный номер.Атрибут применим только для иностранного лица
        public DateTime? RegDate { get; set; }//Дата государственной регистрации. Если атрибут «Признак лица»имеет значение «Иностранное», то атрибут обязателен для заполнения.
        [MaxLength(10)]
        public string INN { get; set; }//ИНН
        [MaxLength(9)]
        public string KPP { get; set; }//КПП
        [MaxLength(8)]
        public string OKVED { get; set; }//ОКВЭД
        [MaxLength(500)]
        public string LegalAddress { get; set; }//Юридический адрес
        public List<ContactPerson> ContactPerson { get; set; }//Контактные лица
        [MaxLength(100)]
        public string FirstName { get; set; }//Имя
        [MaxLength(100)]
        public string LastName { get; set; }//Фамилия
        [MaxLength(100)]
        public string Patronymic { get; set; }//Отчество
        public DateTime? BirthDate { get; set; }//Дата рождения

        public PersonDocumentsTypes PersonDocumentsTypes { get; set; }
        public int PersonDocumentsTypesId { get; set; }//Тип ДУЛ
        [MaxLength(20)]
        public string DocSeries { get; set; }//Серия
        [MaxLength(25)]
        public string DocNumber { get; set; }//Номер
        public DateTime? IssueDate { get; set; }//Дата выдачи
        [MaxLength(11)]
        public string SNILS { get; set; }//СНИЛС
        [MaxLength(500)]
        public string LivingPlace { get; set; }//Место жительства

    }
}
