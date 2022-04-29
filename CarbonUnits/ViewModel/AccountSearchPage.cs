using CarbonUnits.Models;
using CarbonUnits.Models.OrderPath;
using CarbonUnits.Models.MemberPath;
using CarbonUnits.Models.AccountPath;
using CarbonUnits.Models.Dictionaries;
namespace CarbonUnits.ViewModel
{
    public class AccountSearchPage
    {
        public Account Account { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Order> Orders { get; set; }
        public List<AccountStates> AccountStates { get; set; }

        public List<Member> Members { get; set; }
        public List<MemberType> MemberTypes { get; set; }
    }
}
