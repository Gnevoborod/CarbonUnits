using System.ComponentModel.DataAnnotations;
using CarbonUnits.Models.Dictionaries;
namespace CarbonUnits.Models.MemberPath
{
    public class Member
    {
        public CarbonUnitsContext _context;
      
        public int Id { get; set; }
        public MemberType MemberType { get; set; }//Тип лица - физическое, юридическое, ИП
        public int? MemberTypeId { get; set; }
        public MemberCitizen MemberCitizen { get; set; }////Признак лица: Российское или иностранное

        public int? MemberCitizenId { get; set; }
        public OrganizationType OrganizationType { get; set; }//ОПФ
        public int? OrganizationTypeId { get; set; }
        public string FullName { get; set; }//Полное наименование
        public string ShortName { get; set; }//Сокращенное наименование
        [StringLength(13)]
        public string OGRN { get; set; }//ОГРН
        public DateTime? OGRNCreationDate    { get; set; }//Дата присвоения ОГРН
        [MaxLength(100)]
        public string RegNumber { get; set; }//Регистрационный номер.Атрибут применим только для иностранного лица
        public DateTime? RegDate { get; set; }//Дата государственной регистрации. Если атрибут «Признак лица»имеет значение «Иностранное», то атрибут обязателен для заполнения.
        [StringLength(10)]
        public string INN { get; set; }//ИНН
        [StringLength(9)]
        public string KPP { get; set; }//КПП
        [StringLength(8)]
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
        public DateTime? BirthDate  { get; set; }//Дата рождения

        public PersonDocumentsTypes PersonDocumentsTypes { get; set; }
        public int PersonDocumentsTypesId { get; set; }//Тип ДУЛ
        [MaxLength(20)]
        public string DocSeries { get; set; }//Серия
        [MaxLength(25)]
        public string DocNumber { get; set; }//Номер
        public DateTime? IssueDate { get; set; }//Дата выдачи
        [StringLength(11)]
        public string SNILS     { get; set; }//СНИЛС
        [MaxLength(500)]
        public string LivingPlace { get; set; }//Место жительства
        
        public Member CreateNewMember(int MemberTypeId, 
            int? MemberCitizenId, 
            int? OrganizationTypeId,
            string FullName, 
            string ShortName, 
            string OGRN,
            DateTime? OGRNCreationDate,
            string RegNumber,
            DateTime? RegDate,
            string INN,
            string KPP,
            string OKVED,
            string LegalAddress,
            List<ContactPerson> ContactPerson,
            string FirstName,
            string LastName,
            string Patronymic,
            DateTime? BirthDate,
            int PersonDocumentsTypesId,
            string DocSeries,
            string DocNumber,
            DateTime? IssueDate,
            string SNILS,
            string LivingPlace)
        {
            try
            {
                _context = new CarbonUnitsContext();
                Member member = null;
                if (MemberTypeId == 1)
                    member = _context.Members.FirstOrDefault(m => m.INN == INN && m.OGRN == OGRN);
                else
                {//здесь и ниже осуществляем поиск по ИНН и СНИЛС (для СНИЛС стоит пометка - при наличии. 
                 //Если СНИЛС указан - ищем по ИНН и СНИЛС. Если по ИНН и СНИЛС не нашло - ищем только по ИНН.
                    if (SNILS != null)
                    {
                        member = _context.Members.FirstOrDefault(m => m.INN == INN && m.SNILS == SNILS);
                    }
                    if (member == null)//сюда приходим если СНИЛС не передавался на вход ИЛИ если по ИНН и СНИЛС ничего в БД не найдено.
                        member = _context.Members.FirstOrDefault(m => m.INN == INN);
                }

                if (member != null)
                {//пользователь уже существует. Вернём его. В будущем тут ещё и всякие манипуляции связанные с редактированием будем осуществлять.
                    _context.Dispose();
                    return member;
                }
                else
                {


                    int id = _context.Members.Count();
                    if (id == 0)
                        this.Id = 0;
                    else
                        this.Id = _context.Members.Max(w => w.Id) + 1;
                    this.MemberTypeId = MemberTypeId;
                    this.MemberCitizenId = MemberCitizenId;
                    this.OrganizationTypeId = OrganizationTypeId;
                    this.FullName = FullName;
                    this.ShortName = ShortName;
                    this.OGRN = OGRN;
                    this.OGRNCreationDate = OGRNCreationDate;
                    this.RegNumber = RegNumber;
                    this.RegDate = RegDate;
                    this.INN = INN;
                    this.KPP = KPP;
                    this.OKVED = OKVED;
                    this.LegalAddress = LegalAddress;
                    this.ContactPerson = ContactPerson;
                    this.FirstName = FirstName;
                    this.LastName = LastName;
                    this.Patronymic = Patronymic;
                    this.BirthDate = BirthDate;
                    this.PersonDocumentsTypesId = PersonDocumentsTypesId;
                    this.DocSeries = DocSeries;
                    this.DocNumber = DocNumber;
                    this.IssueDate = IssueDate;
                    this.SNILS = SNILS;
                    this.LivingPlace = LivingPlace;


                    MemberHash memberHash = new MemberHash();
                    memberHash.Member = this;
                    memberHash.MemberId = this.Id;
                    memberHash.HashNumber = this.GetHashCode();
                    _context.Members.Add(this);
                    _context.MemberHashes.Add(memberHash);
                    _context.SaveChanges();

                    _context.Dispose();
                }
                return this;
            }
            catch (Exception ex)
            {
                _context.Dispose();
                return null;
            }
        }


    }
}
