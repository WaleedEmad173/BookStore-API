using BookStore.Application.RepositoryInterfaces;
using BookStore.Application.RepositoryInterfaces.UnitOfWorkInterfaces;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookStore.Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(
            AppDbContext context,
            IAuthorRepository AuthorRepo,
            IBookRepository BookRepo,
            IOrderItemRepository OrderItemRepo,
            IOrderRepository OrderRepo,
            ICategoryRepository categoryRepo)
        {
            _context = context;
            Categories = categoryRepo;
            Authors = AuthorRepo;
            Books = BookRepo;
            OrderItems = OrderItemRepo;
            Orders = OrderRepo;
        }

        public ICategoryRepository Categories { get; }
        public IAuthorRepository Authors { get; }
        public IBookRepository Books { get; }
        public IOrderItemRepository OrderItems { get; }
        public IOrderRepository Orders { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
                _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}
