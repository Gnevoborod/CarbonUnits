﻿using Microsoft.AspNetCore.Mvc;
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
            DateTime.TryParse("12.12.1979", out date);
            member = member.CreateNewMember(0, 0, null, null, null, null, null, null, null, "14354352", null, null, null, null, "Анатолий", "Гришин", "Александрович", date, 21, "1524", "333204", null, "53424023423", "Москва");
            if (member == null)
                return Content("NeOkMember");
            Account account = new Account();
            account = account.CreateNewAccount(member, "000000", null, 0, null, null, null, null, null, null, null, null, null);
            if(account==null)
                return Content("NeOkAccount");
            return Content("Ok");
        }
    }
}//херня с созданием мемберов, оч странная, хм.
