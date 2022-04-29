using CarbonUnits.Models;
using CarbonUnits.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CarbonUnits.Controllers
{
    public class OrderController : Controller
    {
        public CarbonUnitsContext _context;
        public OrderController()
        {
            _context = new CarbonUnitsContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            //base.Dispose(disposing);
        }
        public IActionResult Index()
        {
            OrderSearchPage searchPage = new OrderSearchPage();

            var orders = _context.Orders;
            var ioDocuments = _context.IODocumentsTypes;
            var orderStateDescription = _context.OrderStateDescription;
            var serviceCodes=_context.ServiceCodes;
            var servicePurposes= _context.ServicePurposes;
            

            searchPage.Orders = orders.ToList();
            searchPage.IODocumentsTypes = ioDocuments.ToList();
            searchPage.OrderStateDescriptions= orderStateDescription.ToList();
            searchPage.ServiceCodes= serviceCodes.ToList();
            searchPage.ServicePurposes= servicePurposes.ToList();

            return View(searchPage);
     
        }
    }
}
