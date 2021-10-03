using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Shop.CoffeeOrdering.Domain.Entity;
using Shop.CoffeeOrdering.Domain.Interfaces;
using Shop.CoffeeOrdering.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.CoffeeOrdering.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsDomain _itemsDomain;
        public ItemsController(IItemsDomain itemsDomain)
        {
            _itemsDomain = itemsDomain;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            return Ok(await _itemsDomain.GetAllItems());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemDetails(string id)
        {
            return Ok(await _itemsDomain.GetItemById(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertItem([FromBody] Items item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            if (String.IsNullOrEmpty(item.Name))
            {
                ModelState.AddModelError("Name", "The Item name should not be empty");
            }

            if (item.Price == 0)
            {
                ModelState.AddModelError("Price", "The Item Price should not be 0");
            }

            if (item.Tax == 0)
            {
                ModelState.AddModelError("Tax", "The Item Tax should not be 0");
            }

            await _itemsDomain.InsertItem(item);

            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem([FromBody] Items item, string id)
        {
            if (item == null)
            {
                return BadRequest();
            }

            if (String.IsNullOrEmpty(item.Name))
            {
                ModelState.AddModelError("Name", "The Item name should not be empty");
            }

            item.Id = new ObjectId(id);
            await _itemsDomain.UpdateItem(item);

            return Created("Created", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(string id)
        {
            await _itemsDomain.DeleteItem(id);

            return NoContent();
        }
    }
}
