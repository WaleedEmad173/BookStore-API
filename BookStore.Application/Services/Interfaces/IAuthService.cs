using BookStore.Application.DTOs.Auth;

namespace BookStore.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> Register(RegisterDto dto);
        Task<AuthResponseDto> Login(LoginDto dto);
    }
}
