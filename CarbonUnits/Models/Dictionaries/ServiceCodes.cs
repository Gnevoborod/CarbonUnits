using System.ComponentModel.DataAnnotations;
namespace CarbonUnits.Models.Dictionaries
{
    public class ServiceCodes
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string ServiceCode { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }
    }
}
