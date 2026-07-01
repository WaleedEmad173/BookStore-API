using BookStore.Application.DTOs.Auth;
using BookStore.Application.Services.Interfaces;

namespace BookStore.Application.Services.Implementation
{
    public class AuthService : IAuthService
    {
        public Task<AuthResponseDto> Login(LoginDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResponseDto> Register(RegisterDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
