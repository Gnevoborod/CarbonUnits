using CarbonUnits.Models;
using CarbonUnits.Models.MemberPath;
using CarbonUnits.Models.AccountPath;
using CarbonUnits.Models.Dictionaries;
namespace CarbonUnits.ViewModel
{
    public class MemberSearchPage
    {
        public List<MemberCitizen> MemberCitizens { get; set; }
        public List<MemberType> MemberTypes { get; set; }

        public List<PersonDocumentsTypes> PersonDocumentsTypes { get; set; }
        public List<Member> Members { get; set; }
        public Member Member { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
