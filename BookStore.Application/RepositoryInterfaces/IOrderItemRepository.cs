using BookStore.Application.RepositoryInterfaces.GenericInterface;
using BookStore.Domain.Entities;

namespace BookStore.Application.RepositoryInterfaces
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {
    }
}
