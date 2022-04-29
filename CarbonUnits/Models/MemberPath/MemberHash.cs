
namespace CarbonUnits.Models.MemberPath
{
    public class MemberHash
    {
        public int Id { get; set; } 
        public int MemberId { get; set; }
        public int HashNumber { get; set; }
        public Member Member { get; set; }
    }
}
