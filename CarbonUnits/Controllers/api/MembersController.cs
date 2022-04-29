using Microsoft.AspNetCore.Mvc;
using CarbonUnits.Models.MemberPath;
using CarbonUnits.Models;
using CarbonUnits.Models.AccountPath;
using System.Web.Http;
using CarbonUnits.DTO;
using System.Data.Entity;

namespace CarbonUnits.Controllers.api
{
    
    [ApiController]
    public class MembersController : ControllerBase
    {
        CarbonUnitsContext _context=new CarbonUnitsContext();
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
        //GET api/members
        public List<MemberDTO> GetMembers()
        {
            List<Member> member = _context.Members.Include(a=>a.MemberType).Include(b=>b.MemberCitizen).Include(c=>c.PersonDocumentsTypes).ToList();
            MemberDTO memberDTO = new MemberDTO();
            List<Account> account = _context.Accounts.Where(a => a.AccountStatesId == 0).ToList();
            List<MemberDTO> memberDTOList = memberDTO.GetListOfMemberDTO(member, account);

            return memberDTOList;
        }
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]/{id}")]
        //GET api/members/id
        public IActionResult GetMembers(int id)
        {
            var member = _context.Members.FirstOrDefault(x => x.Id == id);
            var account = _context.Accounts.FirstOrDefault(y=>y.MemberId==member.Id);
            if (member == null)
            {
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            MemberDTO memberDTO = new MemberDTO(member, account);

            return Ok(memberDTO);
            
        }
    }
}
