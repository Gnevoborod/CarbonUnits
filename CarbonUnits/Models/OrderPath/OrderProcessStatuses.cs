using CarbonUnits.Models.Dictionaries;
using System.ComponentModel.DataAnnotations;
namespace CarbonUnits.Models.OrderPath
{
    public class OrderProcessStatuses
    {
        public int Id { get; set; }
        public byte StatusCode { get; set; }//Код статуса
        [MaxLength(200)]
        public string Name { get; set; }//Описание статуса
        [MaxLength(4000)]
        public string Description { get; set; }//Текстовое описание исходящего статуса
    }
}
