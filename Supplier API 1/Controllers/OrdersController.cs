using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supplier_API_1.Data;
using Supplier_API_1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplier_API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("place")]
        public async Task<ActionResult<Order>> PlaceOrder([FromBody] OrderRequest orderRequest)
        {
            var order = orderRequest.Order;
            var orderItems = orderRequest.Order.OrderItems;

            if (orderItems == null || !orderItems.Any())
            {
                return BadRequest("Order must contain at least one item.");
            }

            if (orderItems.Count > 10)
            {
                return BadRequest("An order cannot contain more than 10 items.");
            }

            var productCodes = orderItems.Select(item => item.ProductCode).ToList();

            var products = await _context.Products
            .Where(p => productCodes.Contains(p.ProductCode))
            .ToListAsync();

            if (products.Count != productCodes.Count)
            {
                return BadRequest("One or more products are not found.");
            }

            foreach (var item in orderItems)
            {
                var product = products.FirstOrDefault(p => p.ProductCode == item.ProductCode);

                if (product == null)
                {
                    return BadRequest($"Product with code {item.ProductCode} not found.");
                }

                if (product.Stock < item.Amount)
                {
                    return BadRequest($"Not enough stock for product {item.ProductCode}.");
                }

                product.Stock -= item.Amount; 
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await _context.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPut("update-status/{id}")]
        public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] string newStatus)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            order.Status = newStatus;
            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(o => o.OrderId == id);
        }
    }

}

public class OrderRequest
{
    public Order Order { get; set; }
}
