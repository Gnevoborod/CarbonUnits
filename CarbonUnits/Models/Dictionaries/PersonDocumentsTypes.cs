using CarbonUnits.Models.UserPath;
using System.ComponentModel.DataAnnotations;
namespace CarbonUnits.Models.Dictionaries
{
    public class PersonDocumentsTypes
    {
        public int Id { get; set; }

        public int Code { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
