using BookStore.Application.DTOs.Author;
using BookStore.Application.Services.Interfaces;

namespace BookStore.Application.Services.Implementation
{
    public class AuthorService : IAuthorService
    {
        public Task<AuthorDto> Create(CreateAuthorDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AuthorDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorDto> Update(int id, UpdateAuthorDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
