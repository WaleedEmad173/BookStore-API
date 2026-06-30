namespace BookStore.Application.RepositoryInterfaces.UnitOfWorkInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
        IOrderItemRepository OrderItems { get; }
        IOrderRepository Orders { get; }

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
