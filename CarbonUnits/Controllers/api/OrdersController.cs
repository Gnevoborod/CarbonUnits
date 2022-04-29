using Microsoft.AspNetCore.Mvc;
using CarbonUnits.Models.OrderPath;
using CarbonUnits.Models;
using System.Web.Http;

namespace CarbonUnits.Controllers.api
{

    
    [ApiController]
    public class OrdersController : ControllerBase
    {
        CarbonUnitsContext _context = new CarbonUnitsContext();
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
        //get
        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]/{id}")]
        public IActionResult GetOrders(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(order);

        }
    }
}
