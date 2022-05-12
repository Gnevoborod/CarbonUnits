using Microsoft.AspNetCore.Mvc;
using CarbonUnits.Models;
using CarbonUnits.ViewModel;
using CarbonUnits.Models.MemberPath;
using CarbonUnits.Models.AccountPath;

namespace CarbonUnits.Controllers
{
    public class AccountsController : Controller
    {
        public CarbonUnitsContext _context;
        public AccountsController()
        {
            _context = new CarbonUnitsContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            //base.Dispose(disposing);
        }
        
        public IActionResult Index()
        {
            AccountSearchPage searchPage = new AccountSearchPage();
            
           
            var accountStates=_context.AccountStates.ToList();
            searchPage.AccountStates = accountStates;
            var accounts=_context.Accounts.ToList();
            searchPage.Accounts= accounts;
            var members=_context.Members.ToList();
            searchPage.Members= members;
            var memberTypes =_context.MemberTypes.ToList();
            searchPage.MemberTypes= memberTypes;
            return View(searchPage);
        }


        public ActionResult Try()
        {
            Member member = new Member();
            DateTime date;
            DateTime.TryParse("11.01.1996", out date);
            member = member.CreateNewMember(0, 0, null, null, null, null, null, null, null, "21554352", null, null, null, null, "Леонид", "Винилов", "Васильевич", date, 21, "3324", "984204", null, "10324023423", "Москва");
            if (member == null)
                return Content("NeOkMember");
            Account account = new Account();

            account = account.CreateNewAccount(member, null, 0, null, null, null, null, null, null, null, null, null);
            if(account==null)
                return Content("NeOkAccount");
            return Content("Ok");
        }
    }
}//херня с созданием мемберов, оч странная, хм.
