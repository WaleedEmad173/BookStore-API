using BookStore.Application.DTOs.Order;
using BookStore.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _Service;
        public OrdersController(IOrderService Service)
        {
            _Service = Service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _Service.GetAll();
            return Ok(orders);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _Service.GetById(id);
            return Ok(order);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto dto)
        {
            var createdOrder = await _Service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateOrderDto dto)
        {
            var updatedOrder = await _Service.Update(id, dto);
            return Ok(updatedOrder);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _Service.Delete(id);
            return NoContent();
        }
    }
}