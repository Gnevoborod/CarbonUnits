using System.ComponentModel.DataAnnotations;
using CarbonUnits.Models.Dictionaries;
namespace CarbonUnits.Models.OrderPath
{
    public class Order
    {
        public int Id { get; set; }
        [StringLength(10)]
        public string Identity { get; set; }//Идентификатор документа
        public IODocumentsTypes DocumentTypes { get; set; }//Тип документа
        public int IODocumentsTypesId { get; set; }
        public bool isIn { get; set; }//Направление. true входящий документ, false исходящий
        public DateTime RegDate { get; set; }//Дата регистрации
        public string ExternalIdentity { get; set; }//Идентификатор сообщения во внешней системе
        public DateTime? ExternalRegDate { get; set; }//Дата сообщения во внешней системе
        public string ServiceCodeNotInDicti { get; set; }//Код услуги. Данный атрибут требуется для ситуации, когда по полученному во входящем сообщении коду не будет найдена услуга в справочнике услуг

        public ServiceCodes ServiceCode { get; set; }
        public int ServiceCodeId { get; set; }//Идентификатор услуги. Ссылка на найденную услугу в справочнике услуг.
        public string ServicePurposeNotInDicti { get; set; }//Код цели услуги. Данный атрибут требуется для ситуации, когда по полученному во входящем сообщении коду не будет найдена цель услуги в справочнике услуг
        public ServicePurposes ServicePurpose { get; set; }
        public int ServicePurposeId { get; set; }//Идентификатор цели услуги. Ссылка на найденную цель услугу в справочнике услуг.
        public bool RegistrationRegime { get; set; }//Режим регистрации. 0 - Автоматический 1 - Ручной
        public bool Channel { get; set; }//Канал. 0	- ЕПГУ 1 - СМЭВ

        //Тут должен был быть ещё набор бизнес-атрибутов, согласно ФТ.
        //но это не имеет смысла, лучше в отдельной таблице вести учёт какие бизнес-атрибуты соответствуют заявлению
        //так как они могут быть разными - это может быть регистрация счёта, или регистрация КП
        //куда смотреть можно будет определить по типу входящего документа. Пока интересует только ЗаявлОткрытиеСчета
    }
}
