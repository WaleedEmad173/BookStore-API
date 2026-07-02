using BookStore.Application.DTOs.Auth;
using BookStore.Application.Exceptions;
using BookStore.Application.Services.Interfaces;
using BookStore.Application.Settings;
using BookStore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.Application.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<AppUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(IConfiguration config, UserManager<AppUser> userManager, IOptions<JwtSettings> jwtSettings)
        {
            _config = config;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthResponseDto> Login(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
                throw new BadRequestException("Invalid email or password");

            var validPassword = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!validPassword)
                throw new BadRequestException("Invalid email or password");

            return new AuthResponseDto
            {
                AccessToken = await GenerateAccessToken(user)
            };

        }

        public async Task<AuthResponseDto> Register(RegisterDto dto)
        {
            var emailExist = await _userManager.FindByEmailAsync(dto.Email);

            if (emailExist != null)
                throw new DuplicateException("Email already exist.");

            var userNameExist = await _userManager.FindByNameAsync(dto.UserName);

            if (userNameExist != null)
                throw new DuplicateException("User Name already exist.");

            if (dto.Password != dto.ConfirmPassword)
            {
                throw new BadRequestException("Passwords do not match");
            }

            var user = new AppUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserName = dto.UserName
            };

            await _userManager.CreateAsync(user, dto.Password);
            await _userManager.AddToRoleAsync(user, "User");

            return new AuthResponseDto
            {
                AccessToken = await GenerateAccessToken(user)
            };
        }

        private async Task<string> GenerateAccessToken(AppUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key!));
            List<string> roles = (List<string>)await _userManager.GetRolesAsync(user);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_jwtSettings.DurationInMinutes!)),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
