using BookStore.Application.DTOs.Book;
using BookStore.Application.Services.Interfaces.GenericInterface;

namespace BookStore.Application.Services.Interfaces
{
    public interface IBookService : IGenericService<BookDto, CreateBookDto, UpdateBookDto>
    {
    }
}
