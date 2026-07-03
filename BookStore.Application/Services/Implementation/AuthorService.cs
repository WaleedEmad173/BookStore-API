using AutoMapper;
using BookStore.Application.DTOs.Author;
using BookStore.Application.Exceptions;
using BookStore.Application.RepositoryInterfaces.UnitOfWorkInterfaces;
using BookStore.Application.Services.Interfaces;
using BookStore.Domain.Entities;

namespace BookStore.Application.Services.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AuthorDto> Create(CreateAuthorDto dto)
        {
            var exist = await _unitOfWork.Authors.AnyAsync(a => a.FirstName == dto.FirstName && a.LastName == dto.LastName);

            if (exist)
                throw new DuplicateException("Author already exist");

            var author = _mapper.Map<Author>(dto);

            await _unitOfWork.Authors.AddAsync(author);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<bool> Delete(int id)
        {
            if (id <= 0)
                throw new BadRequestException("Invalid Author ID");

            var author = await _unitOfWork.Authors.GetByIdAsync(id);

            if (author == null)
                throw new NotFoundException("Author", id);

            var hasBooks = await _unitOfWork.Books.AnyAsync(b => b.AuthorId == id);

            if (hasBooks)
                throw new ConflictException("Cannot delete author because they have related books.");

            await _unitOfWork.Authors.DeleteAsync(author);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<List<AuthorDto>> GetAll()
        {
            var authors = await _unitOfWork.Authors.GetAllAsync();

            return _mapper.Map<List<AuthorDto>>(authors);
        }

        public async Task<AuthorDto> GetById(int id)
        {
            if (id <= 0)
                throw new BadRequestException("Invalid Author ID");

            var author = await _unitOfWork.Authors.GetByIdAsync(id);

            if (author == null)
                throw new NotFoundException("Author", id);

            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<AuthorDto> Update(int id, UpdateAuthorDto dto)
        {
            if (id <= 0)
                throw new BadRequestException("Invalid Author ID");

            var author = await _unitOfWork.Authors.GetByIdAsync(id);

            if (author == null)
                throw new NotFoundException("Author", id);

            var exist = await _unitOfWork.Authors.AnyAsync(a => a.FirstName == dto.FirstName && a.LastName == dto.LastName && a.Id != id);

            if (exist)
                throw new DuplicateException("Author already exist");

            _mapper.Map(dto, author);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<AuthorDto>(author);
        }
    }
}
