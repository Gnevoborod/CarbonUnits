using CarbonUnits.Models;
using CarbonUnits.Models.MemberPath;
using CarbonUnits.Models.AccountPath;
using CarbonUnits.Models.Dictionaries;
namespace CarbonUnits.ViewModel
{
    public class CommonModel
    {
        public CarbonUnitsContext Context { get; set; }
        public List<Member> Member { get; set; }
        public List<ContactPerson> ContactPerson { get; set; }
        public List<PersonDocumentsTypes> PersonDocumentsTypes { get; set; }
        public List<OrganizationType> OrganizationTypes { get; set; }
        public List<MemberType> MemberTypes { get; set; }

    }
}
