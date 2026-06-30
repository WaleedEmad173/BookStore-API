using BookStore.Application.RepositoryInterfaces.GenericInterface;
using BookStore.Domain.Entities;

namespace BookStore.Application.RepositoryInterfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
    }
}
