using BookStore.Application.RepositoryInterfaces.GenericInterface;
using BookStore.Domain.Entities;

namespace BookStore.Application.RepositoryInterfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        public Task<List<Book>> GetBooksWithCategoryAndAuthorAsync();

        public Task<Book?> GetBookWithCategoryAndAuthorAsync(int id);
    }
}
