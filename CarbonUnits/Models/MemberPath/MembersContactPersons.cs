using CarbonUnits.Models;

namespace CarbonUnits.Models.MemberPath
{
    public class MembersContactPersons
    {
        public int Id { get; set; }
        List<ContactPerson> contactPersons { get; set; }
        List<Member> members { get; set; }
    }
}
