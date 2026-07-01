using BookStore.Application.DTOs.Order;
using BookStore.Application.Services.Interfaces.GenericInterface;

namespace BookStore.Application.Services.Interfaces
{
    public interface IOrderService : IGenericService<OrderDto, CreateOrderDto>
    {
    }
}
