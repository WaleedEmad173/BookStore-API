using AutoMapper;
using BookStore.Application.DTOs.Order;
using BookStore.Application.Exceptions;
using BookStore.Application.RepositoryInterfaces.UnitOfWorkInterfaces;
using BookStore.Application.Services.Interfaces;
using BookStore.Domain.Entities;
namespace BookStore.Application.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OrderDto> Create(CreateOrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);

            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<OrderDto>(order);
        }
        public async Task<bool> Delete(int id)
        {
            if (id <= 0)
                throw new BadRequestException("Invalid Order ID");

            var order = await _unitOfWork.Orders.GetByIdAsync(id);

            if (order == null)
                throw new NotFoundException("Order", id);

            await _unitOfWork.Orders.DeleteAsync(order);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        public async Task<List<OrderDto>> GetAll()
        {
            var orders = await _unitOfWork.Orders.GetAllAsync();

            return _mapper.Map<List<OrderDto>>(orders);
        }
        public async Task<OrderDto> GetById(int id)
        {
            if (id <= 0)
                throw new BadRequestException("Invalid Order ID");

            var order = await _unitOfWork.Orders.GetByIdAsync(id);

            if (order == null)
                throw new NotFoundException("Order", id);

            return _mapper.Map<OrderDto>(order);
        }
        public async Task<OrderDto> Update(int id, CreateOrderDto dto)
        {
            if (id <= 0)
                throw new BadRequestException("Invalid Order ID");

            var order = await _unitOfWork.Orders.GetByIdAsync(id);

            if (order == null)
                throw new NotFoundException("Order", id);

            _mapper.Map(dto, order);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<OrderDto>(order);
        }
    }
}