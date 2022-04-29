using CarbonUnits.Models.OrderPath;
using CarbonUnits.Models.Dictionaries;
namespace CarbonUnits.ViewModel
{
    public class OrderSearchPage
    {
        public List<Order> Orders { get; set; }
        public List<IODocumentsTypes> IODocumentsTypes { get; set; }
        public Order Order { get; set; }
        public List<string> InOrOut = new List<string>() { "Входящий", "Исходящий" };
        public List<ServiceCodes> ServiceCodes { get; set; }
        public List<ServicePurposes> ServicePurposes { get; set; }
        public List<OrderStateDescription> OrderStateDescriptions { get; set; }
        public List<OrderStates> OrderStates { get; set; }
        public OrderStates OrderState { get; set; }
    }
}
