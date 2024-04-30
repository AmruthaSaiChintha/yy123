using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using YumYard.Models;

namespace YumYard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly Data _context;

        public OrdersController(Data context)
        {
            _context = context;
        }

        // POST: /api/orders
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Invalid order data.");
            }

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return Ok("Order received successfully.");
        }

        // GET: /api/orders/{orderId}
         [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrder(int orderId)
    {
        var order = await _context.Order
            .Include(o => o.Items) // Include the related items
            .FirstOrDefaultAsync(o => o.OrderId == orderId);

        if (order == null)
        {
            return NotFound("Order not found.");
        }

        return Ok(order);
    }
    }
}
