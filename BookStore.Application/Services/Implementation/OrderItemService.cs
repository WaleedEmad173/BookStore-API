using BookStore.Application.DTOs.OrderItem;
using BookStore.Application.Services.Interfaces;

namespace BookStore.Application.Services.Implementation
{
    public class OrderItemService : IOrderItemService
    {
        public Task<OrderItemDto> Create(CreateOrderItemDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderItemDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OrderItemDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItemDto> Update(int id, CreateOrderItemDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
