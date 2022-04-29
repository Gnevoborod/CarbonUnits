using CarbonUnits.Models.UserPath;
using System.ComponentModel.DataAnnotations;
namespace CarbonUnits.Models.OrderPath
{
    public class OrderStates
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public string Identity { get; set; }//Идентификатор документа
        public OrderStateDescription OrderStateDescription { get; set; }
        public int OrderStateDescriptionId { get; set; }//Состояние
        public bool CurrentState { get; set; }//Признак, что состояние текущее
        public string Description { get; set; }//Комментарий к состоянию
        public User User { get; set; }
        public int UserId { get; set; }//Имя пользователя, который выполнил перевод документа в данное состояние.Пользователь может быть системным для автоматических процессов.
        public DateTime SetDate { get; set; }//Дата и время перевода в состояние

    }
}
