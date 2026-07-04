using BookStore.Application.DTOs.Book;
using BookStore.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _Service;

        public BooksController(IBookService Service)
        {
            _Service = Service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _Service.GetAll();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _Service.GetById(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookDto dto)
        {
            var createdBook = await _Service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdBook.Id }, createdBook);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBookDto dto)
        {
            var updatedBook = await _Service.Update(id, dto);
            return Ok(updatedBook);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _Service.Delete(id);
            return NoContent();
        }
    }
}