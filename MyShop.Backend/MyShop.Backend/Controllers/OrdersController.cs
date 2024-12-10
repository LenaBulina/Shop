using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public OrdersController(ApplicationContext context)
        {
            _context = context;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
           return await _context.Orders
                                .Include(or => or.Products)
                                .Include(or => or.Customer)
                                .ToListAsync();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Order orderToDelete = _context.Orders.Find(id);

            if (orderToDelete == null)
            {
                return NotFound("Order was not found");
            }

            _context.Remove(orderToDelete);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            if (order == null || order.Products.Count == 0)
            {
                return BadRequest("Order is null or Order doesn`t contain products.");
            }

            //Customer existedCustomer = _context.Customers.Local.Where(c => c.Email == order.Customer.Email).SingleOrDefault();
            //if (existedCustomer != null)
            //{
            //    _context.Customers.Remove(existedCustomer);
            //}                

            Customer newCustomer = new Customer()
            {
                Name = order.Customer.Name,
                Phone = order.Customer.Phone,
                Email = order.Customer.Email
            };

            _context.Customers.Add(newCustomer);
            _context.SaveChanges();

            Order newOrder = new Order()
            {
                DeliveryAddress = order.DeliveryAddress,
                Date = order.Date,
                Price = order.Price,
                Payment = order.Payment,
                CustomerId = newCustomer.Id
            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            var productIds = order.Products.Select(o => o.Id).ToArray();
      
            var productsToLink = _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToList();

            newOrder.Products = productsToLink;
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }



        [HttpGet("{id:int}")]
        public ActionResult<Order> GetById(int id)
        {
            Order order = _context.Orders.Find(id);
            if (order == null)
            {
                return BadRequest("Order is null.");
            }
            return Ok(order);
        }


    }
}
