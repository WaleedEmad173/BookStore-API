using AutoMapper;
using BookStore.Application.DTOs.OrderItem;
using BookStore.Application.Exceptions;
using BookStore.Application.RepositoryInterfaces.UnitOfWorkInterfaces;
using BookStore.Application.Services.Interfaces;
using BookStore.Domain.Entities;
namespace BookStore.Application.Services.Implementation
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OrderItemDto> Create(CreateOrderItemDto dto)
        {
            var item = _mapper.Map<OrderItem>(dto);

            await _unitOfWork.OrderItems.AddAsync(item);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<OrderItemDto>(item);
        }
        public async Task<bool> Delete(int id)
        {
            if (id <= 0)
                throw new BadRequestException("Invalid OrderItem ID");

            var item = await _unitOfWork.OrderItems.GetByIdAsync(id);

            if (item == null)
                throw new NotFoundException("OrderItem", id);

            await _unitOfWork.OrderItems.DeleteAsync(item);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        public async Task<List<OrderItemDto>> GetAll()
        {
            var items = await _unitOfWork.OrderItems.GetAllAsync();

            return _mapper.Map<List<OrderItemDto>>(items);
        }
        public async Task<OrderItemDto> GetById(int id)
        {
            if (id <= 0)
                throw new BadRequestException("Invalid OrderItem ID");

            var item = await _unitOfWork.OrderItems.GetByIdAsync(id);

            if (item == null)
                throw new NotFoundException("OrderItem", id);

            return _mapper.Map<OrderItemDto>(item);
        }
        public async Task<OrderItemDto> Update(int id, CreateOrderItemDto dto)
        {
            if (id <= 0)
                throw new BadRequestException("Invalid OrderItem ID");

            var item = await _unitOfWork.OrderItems.GetByIdAsync(id);

            if (item == null)
                throw new NotFoundException("OrderItem", id);

            _mapper.Map(dto, item);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<OrderItemDto>(item);
        }
    }
}