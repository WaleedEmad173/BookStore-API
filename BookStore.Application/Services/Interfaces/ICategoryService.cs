using BookStore.Application.DTOs.Category;
using BookStore.Application.Services.Interfaces.GenericInterface;

namespace BookStore.Application.Services.Interfaces
{
    public interface ICategoryService : IGenericService<CategoryDto, CreateCategoryDto, UpdateCategoryDto>
    {
    }
}
