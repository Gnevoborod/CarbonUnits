namespace CarbonUnits.DTO
{
    public class ContactPersonDTO
    {
        public int Id { get; set; }
        public List<string> FullName { get; set; }//ФИО контактного лица
        public List<string> Email { get; set; }//Электронная почта
        public List<string> Phone { get; set; }//Телефон
    }
}
