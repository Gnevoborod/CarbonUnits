using Microsoft.AspNetCore.Mvc;
using CarbonUnits.Models;
using CarbonUnits.ViewModel;
using CarbonUnits.Models.MemberPath;
namespace CarbonUnits.Controllers
{
    public class MemberController : Controller
    {
        public CarbonUnitsContext _context;
        public MemberController()
        {
            _context = new CarbonUnitsContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            //base.Dispose(disposing);
        }
        [HttpPost]
        public IActionResult Search(MemberSearchPage msp)
        {
            if (msp.Member == null)
             {   
               return RedirectToAction("Index",-1);
                
            }
            return RedirectToAction("Index", new { id = msp.Member.Id });
        }
        public IActionResult Index(int id=-1)
        {
               
            MemberSearchPage viewModel = new MemberSearchPage();
            var memberTypes = _context.MemberTypes;
            var memberCitizens = _context.MemberCitizens;
            var personDocumentsTypes=_context.PersonDocumentsTypes;
            var members=id<0?_context.Members:_context.Members.Where(m=>m.Id==id);
            var accounts = _context.Accounts;
            viewModel.PersonDocumentsTypes = personDocumentsTypes.ToList();
            viewModel.MemberCitizens = memberCitizens.ToList();
            viewModel.MemberTypes = memberTypes.ToList();
            viewModel.Members = members.ToList();
            viewModel.Accounts = accounts.ToList();

            return View(viewModel);
        }

      public ActionResult Try()
        {
            Member member = new Member();
            DateTime date;
            DateTime.TryParse("01.01.1980", out date);
            member =member.CreateNewMember(0,0, null, null, null, null, null, null, null, "34356652", null, null, null, null, "Пётр", "Столешников", "Васильевич", date, 21, "4394", "643234", null, "54230523423","Москва");
            if (member == null)
                return Content("NeOk");
            return Content("Ok");
        }
    }
}
