using BookStore.Application.DTOs.OrderItem;
using BookStore.Application.Services.Interfaces.GenericInterface;

namespace BookStore.Application.Services.Interfaces
{
    public interface IOrderItemService : IGenericService<OrderItemDto, CreateOrderItemDto>
    {
    }
}
