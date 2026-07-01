using BookStore.Application.DTOs.Order;
using BookStore.Application.Services.Interfaces;

namespace BookStore.Application.Services.Implementation
{
    public class OrderService : IOrderService
    {
        public Task<OrderDto> Create(CreateOrderDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> Update(int id, CreateOrderDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
