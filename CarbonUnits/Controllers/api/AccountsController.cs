using Microsoft.AspNetCore.Mvc;
using CarbonUnits.Models.AccountPath;
using CarbonUnits.Models;
using System.Web.Http;
using CarbonUnits.DTO;
using System.Data.Entity;

namespace CarbonUnits.Controllers.api
{

    [ApiController]
    public class AccountsController : ControllerBase
    {
        CarbonUnitsContext _context = new CarbonUnitsContext();
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
        public List<AccountDTO> GetAccounts()
        {
            List<Account> account = _context.Accounts.Include(a => a.Member).Include(aa=>aa.Member.MemberType).Include(b=>b.AccountStates).Include(c=>c.OrderToOpen).Include(d=>d.OrderToClose).ToList();
            AccountDTO accountDTO = new AccountDTO();
            List<AccountDTO> accountDTOList = accountDTO.GetListOfAccountDTO(account);

            return accountDTOList;
        }
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]/{id}")]
        public IActionResult GetAccounts(int id)
        {
            var account = _context.Accounts.Include(a=>a.Member).FirstOrDefault(x => x.Id == id);
            if (account == null)
            {
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(account);

        }
    }
}
