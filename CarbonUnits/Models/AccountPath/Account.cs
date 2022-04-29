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
        public Account CreateNewAccount(
            Member Member,
            string Identity,
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
