using AutoMapper;
using BookStore.Application.DTOs.Category;
using BookStore.Application.Exceptions;
using BookStore.Application.RepositoryInterfaces.UnitOfWorkInterfaces;
using BookStore.Application.Services.Interfaces;
using BookStore.Domain.Entities;

namespace BookStore.Application.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Create(CreateCategoryDto dto)
        {
            var exist = await _unitOfWork.Categories.AnyAsync(c => c.Name == dto.Name);

            if (exist)
                throw new DuplicateException("Category already exist.");

            var category = _mapper.Map<Category>(dto);

            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> Delete(int id)
        {
            if (id <= 0)
                throw new BadRequestException("Invalid Category ID");

            var category = await _unitOfWork.Categories.GetByIdAsync(id);

            if (category == null) throw new NotFoundException("Category", id);

            await _unitOfWork.Categories.DeleteAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();

            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetById(int id)
        {
            if (id <= 0)
                throw new BadRequestException("Invalid Category ID");

            var category = await _unitOfWork.Categories.GetByIdAsync(id);

            if (category == null)
                throw new NotFoundException("Category", id);

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> Update(int id, UpdateCategoryDto dto)
        {
            if (id <= 0)
                throw new BadRequestException("Invalid Category ID");

            var category = await _unitOfWork.Categories.GetByIdAsync(id);

            if (category == null)
                throw new NotFoundException("Category", id);

            _mapper.Map(dto, category);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
