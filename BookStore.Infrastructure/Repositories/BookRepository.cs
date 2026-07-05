using BookStore.Application.RepositoryInterfaces;
using BookStore.Domain.Entities;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooksWithCategoryAndAuthorAsync()
        {
            return await _context.Books
                .AsNoTracking()
                .Include(b => b.Category)
                .Include(b => b.Author)
                .ToListAsync();
        }
        public async Task<Book?> GetBookWithCategoryAndAuthorAsync(int id)
        {
            return await _context.Books
                .AsNoTracking()
                .Include(b => b.Category)
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
