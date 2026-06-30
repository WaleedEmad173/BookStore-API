using BookStore.Application.RepositoryInterfaces;
using BookStore.Domain.Entities;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Repositories.Generic;

namespace BookStore.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
