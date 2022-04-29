using System.ComponentModel.DataAnnotations;
using CarbonUnits.Models.OrderPath;
using CarbonUnits.Models.Dictionaries;
using CarbonUnits.Models.MemberPath;
namespace CarbonUnits.Models.AccountPath
{
    public class Account
    {
        public CarbonUnitsContext _context;
        public int Id { get; set; }
        public Member Member { get; set; }//Участник
        public int MemberId { get; set; }
        public int IdentityThroughYears { get; set; }
        [StringLength(10)]
        public string Identity { get; set; }//Номер счета
        public AccountStates AccountStates { get; set; }   //Состояние 
        public int? AccountStatesId { get; set; }

        public DateTime? DateOpen { get; set; }//Дата открытия
        
        public Order OrderToOpen { get; set; }//Документ-основание открытия
        public int? OrderToOpenId { get; set; }

        public DateTime? DateClose { get; set; }//Дата закрытия
        public Order OrderToClose { get; set; }//Документ-основание закрытия
        public int? OrderToCloseId   { get; set; }
        [StringLength(10)]
        public string Agreement { get; set; }//Номер договора, заключенного с участником, в рамках которого открыт счет.
        public DateTime? AgreementOpenDate { get; set; }//Дата заключения
        public DateTime? AgreementCloseDate { get; set; }//Дата расторжения договора с участником.
        public DateTime DateCreate { get; set; }

        public string FormatIdentity(int id)
        {
            if (id < 10)
                return "000000" + id.ToString();
            if (id < 100)
                return "00000" + id.ToString();
            if (id < 1000)
                return "0000" + id.ToString();
            if (id < 10000)
                return "000" + id.ToString();
            if (id < 100000)
                return "00" + id.ToString();
            if (id < 1000000)
                return "0" + id.ToString();
            return id.ToString();
        }
        public Account CreateNewAccount(
            Member Member,
            AccountStates AccountStates,
            int? AccountStatesId,
            DateTime? DateOpen,
            Order OrderToOpen,
            int? OrderToOpenId,
            DateTime? DateClose,
            Order OrderToClose,
            int? OrderToCloseId,
            string Agreement,
            DateTime? AgreementOpenDate,
            DateTime? AgreementCloseDate)
        {
            try
            {

                
                _context = new CarbonUnitsContext();
                Account account = new Account();
                account = _context.Accounts.FirstOrDefault(a => a.MemberId == Member.Id && a.AccountStatesId == 0);
                if(account!=null)
                {
                    _context.Dispose();
                    return null;
                }
                string Identity;
                //int memberType = member.MemberType.Id == 0 ? 2 : member.MemberType.Id == 1 ? 1 : 3;
                int memberType = 2;
                string year = DateTime.Now.Year.ToString().Substring(2);
                int number;
                number = _context.Accounts.Max(n => n.IdentityThroughYears) + 1;
                Identity = memberType.ToString() + year + FormatIdentity(number);
                int id = _context.Accounts.Count();
                if (id==0)
                    this.Id = 0;
                else
                    this.Id = _context.Accounts.Max(w=>w.Id) + 1;
                this.Member = null;//Member;если добавить ссылку - то создаётся куча ненужных клонов мемберов в БД
                this.MemberId = Member.Id;
                this.Identity = Identity;
                this.AccountStates = AccountStates;
                this.AccountStatesId = AccountStatesId;
                this.DateOpen = DateOpen;
                this.OrderToOpen = OrderToOpen;
                this.OrderToOpenId = OrderToOpenId;
                this.DateClose = DateClose;
                this.OrderToClose = OrderToClose;
                this.OrderToCloseId = OrderToCloseId;
                this.Agreement = Agreement;
                this.AgreementOpenDate = AgreementOpenDate;
                this.AgreementCloseDate = AgreementCloseDate;
                this.DateCreate = DateTime.Now;
                this.IdentityThroughYears = _context.Accounts.Where(a=>1<(this.DateCreate.Year-a.DateCreate.Year)).Max(i => i.IdentityThroughYears) + 1;
                _context.Accounts.Add(this);
                _context.SaveChanges();
                _context.Dispose();
                return this;
            }
            catch (Exception ex)
            {
                _context.Dispose();
                return null;
            }
        }
    }
}
