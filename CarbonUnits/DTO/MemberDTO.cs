using System.ComponentModel.DataAnnotations;
using CarbonUnits.Models.MemberPath;
using CarbonUnits.Models.AccountPath;
using CarbonUnits.Models.Dictionaries;
namespace CarbonUnits.DTO
{
    public class MemberDTO
    { 
        public int Id { get; set; }
        public int? MemberTypeId { get; set; }
        public MemberType MemberType { get; set; }
        public int? MemberCitizenId { get; set; }
        public MemberCitizen MemberCitizen { get; set; }
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
        public List<ContactPersonDTO> ContactPerson { get; set; }//Контактные лица
        [MaxLength(100)]
        public string FirstName { get; set; }//Имя
        [MaxLength(100)]
        public string LastName { get; set; }//Фамилия
        [MaxLength(100)]
        public string Patronymic { get; set; }//Отчество
        public DateTime? BirthDate { get; set; }//Дата рождения
        public string DocumentInfo { get; set; }
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
        public Account Account { get; set; }
        public MemberDTO()
        {

        }
        public MemberDTO(Member member, Account account)
        {
            this.Id = member.Id;
            this.MemberTypeId = member.MemberTypeId;
            this.MemberCitizenId = member.MemberCitizenId;
            this.OrganizationTypeId = member.OrganizationTypeId;
            this.FullName = member.FullName;
            this.ShortName = member.ShortName;
            this.OGRN = member.OGRN;
            this.OGRNCreationDate = member.OGRNCreationDate;
            this.RegNumber = member.RegNumber;
            this.RegDate = member.RegDate;
            this.INN = member.INN;
            this.KPP = member.KPP;
            this.OKVED = member.OKVED;
            this.LegalAddress = member.LegalAddress;
            //this.ContactPerson = member.ContactPerson;
            this.FirstName = member.FirstName;
            this.LastName = member.LastName;
            this.Patronymic = member.Patronymic;
            this.BirthDate = member.BirthDate;
            this.PersonDocumentsTypesId = member.PersonDocumentsTypesId;
            this.DocSeries = member.DocSeries;
            this.DocNumber = member.DocNumber;
            this.IssueDate = member.IssueDate;
            this.SNILS = member.SNILS;
            this.LivingPlace = member.LivingPlace;
            this.MemberType=member.MemberType;
            this.MemberCitizen = member.MemberCitizen;
            this.Account = account;
            if(this.Account == null)
            {
                this.Account = new Account();
                this.Account.Identity = "";
            }
            if (this.FullName==null)
            {
                this.FullName = this.LastName+" "+this.FirstName + " " + this.Patronymic;
            }
            this.PersonDocumentsTypes = member.PersonDocumentsTypes;
            this.DocumentInfo = this.PersonDocumentsTypes.Name + " " + this.DocSeries + " " + this.DocNumber;
        }

        public List<MemberDTO> GetListOfMemberDTO(List<Member> members, List<Account> accounts)
        {
            List<MemberDTO> result = new List<MemberDTO>();
            foreach( Member member in members)
            {
                result.Add(new MemberDTO(member, accounts.SingleOrDefault(a=>a.MemberId==member.Id)));
            }
            return result;
        }
        public Member GetMember(MemberDTO memberDTO)
        {
            return null;
        }
    }
}
