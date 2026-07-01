using BookStore.Application.DTOs.Author;
using BookStore.Application.Services.Interfaces.GenericInterface;

namespace BookStore.Application.Services.Interfaces
{
    public interface IAuthorService : IGenericService<AuthorDto, CreateAuthorDto, UpdateAuthorDto>
    {
    }
}
