using BookStore.Application.DTOs.OrderItem;
using BookStore.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _Service;
        public OrderItemsController(IOrderItemService Service)
        {
            _Service = Service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _Service.GetAll();
            return Ok(items);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _Service.GetById(id);
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderItemDto dto)
        {
            var createdItem = await _Service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateOrderItemDto dto)
        {
            var updatedItem = await _Service.Update(id, dto);
            return Ok(updatedItem);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _Service.Delete(id);
            return NoContent();
        }
    }
}