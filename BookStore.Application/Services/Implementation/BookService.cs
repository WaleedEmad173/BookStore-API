using AutoMapper;
using BookStore.Application.DTOs.Book;
using BookStore.Application.Exceptions;
using BookStore.Application.RepositoryInterfaces.UnitOfWorkInterfaces;
using BookStore.Application.Services.Interfaces;
using BookStore.Domain.Entities;

namespace BookStore.Application.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookDto> Create(CreateBookDto dto)
        {
            var exist = await _unitOfWork.Books.AnyAsync(b => b.Title == dto.Title);

            if (exist)
                throw new DuplicateException("Book already exist");

            var authorExist = await _unitOfWork.Authors.AnyAsync(a => a.Id == dto.AuthorId);

            if (!authorExist)
                throw new NotFoundException("Author", dto.AuthorId);

            var categoryExist = await _unitOfWork.Categories.AnyAsync(a => a.Id == dto.CategoryId);

            if (!categoryExist)
                throw new NotFoundException("Category", dto.CategoryId);

            var book = _mapper.Map<Book>(dto);

            await _unitOfWork.Books.AddAsync(book);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<BookDto>(book);
        }

        public async Task<bool> Delete(int id)
        {
            if (id <= 0)
                throw new BadRequestException("Invalid Book ID");

            var book = await _unitOfWork.Books.GetByIdAsync(id);

            if (book == null)
                throw new NotFoundException("Book", id);

            var hasOrderItem = await _unitOfWork.OrderItems.AnyAsync(oi => oi.BookId == id);

            if (hasOrderItem)
                throw new ConflictException("Cannot delete Book because they have related OrderItems.");

            await _unitOfWork.Books.DeleteAsync(book);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<List<BookDto>> GetAll()
        {
            var books = await _unitOfWork.Books.GetBooksWithCategoryAndAuthorAsync();

            return _mapper.Map<List<BookDto>>(books);
        }

        public async Task<BookDto> GetById(int id)
        {
            if (id <= 0)
                throw new BadRequestException("Invalid Book ID");

            var book = await _unitOfWork.Books.GetBookWithCategoryAndAuthorAsync(id);

            if (book == null)
                throw new NotFoundException("Book", id);

            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> Update(int id, UpdateBookDto dto)
        {
            if (id <= 0)
                throw new BadRequestException("Invalid Book ID");

            var book = await _unitOfWork.Books.GetByIdAsync(id);

            if (book == null)
                throw new NotFoundException("Book", id);

            var exist = await _unitOfWork.Books.AnyAsync(b => b.Title == dto.Title && b.Id != id);

            if (exist)
                throw new DuplicateException("Book already exist");

            var authorExist = await _unitOfWork.Authors.AnyAsync(a => a.Id == dto.AuthorId);

            if (!authorExist)
                throw new NotFoundException("Author", dto.AuthorId);

            var categoryExist = await _unitOfWork.Categories.AnyAsync(a => a.Id == dto.CategoryId);

            if (!categoryExist)
                throw new NotFoundException("Category", dto.CategoryId);

            _mapper.Map(dto, book);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<BookDto>(book);
        }
    }
}
