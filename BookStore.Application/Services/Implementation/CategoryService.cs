using BookStore.Application.DTOs.Category;
using BookStore.Application.Services.Interfaces;

namespace BookStore.Application.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        public Task<CategoryDto> Create(CreateCategoryDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> Update(int id, UpdateCategoryDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
