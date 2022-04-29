using System.ComponentModel.DataAnnotations;
using CarbonUnits.Models.OrderPath;
using CarbonUnits.Models.MemberPath;
using CarbonUnits.Models.Dictionaries;
namespace CarbonUnits.Models.AccountPath
{
    public class AccountBusinessData
    {
        public CarbonUnitsContext _context;
        public int Id { get; set; }
        public Member Member { get; set; }//Участник
        public int MemberId { get; set; }
        [MaxLength(10)]
        public string Identity { get; set; }//Номер счета
        public AccountStates AccountStates { get; set; }   //Состояние 
        public int? AccountStatesId { get; set; }

        public DateTime? DateOpen { get; set; }//Дата открытия

        public Order OrderToOpen { get; set; }//Документ-основание открытия
        public int? OrderToOpenId { get; set; }

        public DateTime? DateClose { get; set; }//Дата закрытия
        public Order OrderToClose { get; set; }//Документ-основание закрытия
        public int? OrderToCloseId { get; set; }
        [MaxLength(10)]
        public string Agreement { get; set; }//Номер договора, заключенного с участником, в рамках которого открыт счет.
        public DateTime? AgreementOpenDate { get; set; }//Дата заключения
        public DateTime? AgreementCloseDate { get; set; }//Дата расторжения договора с участником.
    }
}
