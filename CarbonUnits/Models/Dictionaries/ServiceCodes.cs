using System.ComponentModel.DataAnnotations;
using CarbonUnits.Models.UserPath;
namespace CarbonUnits.Models.Dictionaries
{
    public class ServiceCodes
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string ServiceCode { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
