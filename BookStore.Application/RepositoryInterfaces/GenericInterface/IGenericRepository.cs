using System.Linq.Expressions;

namespace BookStore.Application.RepositoryInterfaces.GenericInterface
{
    public interface IGenericRepository<T> where T : class
    {
        Task DeleteRangeAsync(ICollection<T> entities);
        Task<T?> GetByIdAsync(int id);
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<T, TResult>> selector);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}
