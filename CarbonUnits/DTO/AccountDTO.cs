using System.ComponentModel.DataAnnotations;
using CarbonUnits.Models.AccountPath;
using CarbonUnits.Models.MemberPath;
using CarbonUnits.Models.Dictionaries;
using CarbonUnits.Models.OrderPath;
namespace CarbonUnits.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        [MaxLength(10)]
        public string Identity { get; set; }//Номер счета
        public int? AccountStatesId { get; set; }
        public AccountStates AccountStates { get; set; }
        public DateTime? DateOpen { get; set; }//Дата открытия

        public int? OrderToOpenId { get; set; }
        public Order OrderToOpen { get; set; }
        public DateTime? DateClose { get; set; }//Дата закрытия
        public int? OrderToCloseId { get; set; }
        public Order OrderToClose { get; set; }
        [MaxLength(10)]
        public string Agreement { get; set; }//Номер договора, заключенного с участником, в рамках которого открыт счет.
        public DateTime? AgreementOpenDate { get; set; }//Дата заключения
        public DateTime? AgreementCloseDate { get; set; }//Дата расторжения договора с участником.

        public string FullName { get; set; }

        public AccountDTO()
        {

        }

        public AccountDTO(Account account)
        {
            this.Id = account.Id;
            this.MemberId = account.MemberId;
            this.Member= account.Member;
            this.Identity = account.Identity;
            this.AccountStatesId = account.AccountStatesId;
            this.DateOpen = account.DateOpen;
            this.OrderToOpenId = account.OrderToOpenId;
            this.DateClose = account.DateClose;
            this.OrderToCloseId = account.OrderToCloseId;
            this.Agreement = account.Agreement;
            this.AgreementOpenDate = account.AgreementOpenDate;
            this.AgreementCloseDate = account.AgreementCloseDate;
            this.AccountStates = account.AccountStates;
            this.OrderToClose= account.OrderToClose;
            this.OrderToOpen= account.OrderToOpen;

            //заглушка чтобы не выплёвывало null при загрузке данных по счетам. ведь документа-основания может не быть
            //на этапе разработки - только для orderToOpen, а на этапе пром эксплуатации уже только для orderToClose
            this.FullName=Member.FullName?? Member.LastName + " " + Member.FirstName + " " + Member.Patronymic;
            if (this.OrderToOpen==null)
            {
                this.OrderToOpen = new Order();
                this.OrderToOpen.Identity = "-";
            }
            if (this.OrderToClose == null)
            {
                this.OrderToClose = new Order();
                this.OrderToClose.Identity = "-";
            }
        }

        public List<AccountDTO> GetListOfAccountDTO(List<Account> accounts)
        {
            List<AccountDTO> result = new List<AccountDTO>();
            foreach (Account account in accounts)
            {
                result.Add(new AccountDTO(account));
            }
            return result;
        }
        public Account GetAccount(AccountDTO accountDTO)
        {
            return null;
        }

    }
}