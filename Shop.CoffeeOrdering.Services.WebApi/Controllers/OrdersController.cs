using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.CoffeeOrdering.Domain.Entity;
using Shop.CoffeeOrdering.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.CoffeeOrdering.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersDomain _ordersDomain;
        public OrdersController(IOrdersDomain ordersDomain)
        {
            _ordersDomain = ordersDomain;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _ordersDomain.GetAllOrders());
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrder([FromBody] Orders order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            if (order.OrderLines == null || !order.OrderLines.Any())
            {
                ModelState.AddModelError("OrderLines", "It is needed to add at least one order line");
            }
            else
            {
                if (order.OrderLines.Where(a => a.Item == null || String.IsNullOrEmpty(a.Item.ItemId) || a.Quantity == 0).Any())
                {
                    ModelState.AddModelError("OrderLines", "The Item and the Quantity must be specified in the Order Lines");
                }
            }

            if (order.User == null || order.User.UserId == null)
            {
                ModelState.AddModelError("User", "The Order User should not be empty");
            }

            await _ordersDomain.InsertOrder(order);

            return Created("Created", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            await _ordersDomain.DeleteOrder(id);

            return NoContent();
        }
    }
}
