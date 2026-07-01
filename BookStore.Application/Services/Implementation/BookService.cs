using BookStore.Application.DTOs.Book;
using BookStore.Application.Services.Interfaces;

namespace BookStore.Application.Services.Implementation
{
    public class BookService : IBookService
    {
        public Task<BookDto> Create(CreateBookDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> Update(int id, UpdateBookDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
