
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WarehouseManager.Application.Abstractions;
using WarehouseManager.Application.Features.Login;
using WarehouseManager.Domain.Entities;
using WarehouseManager.Domain.Enums;

namespace WarehouseManager.Infrastructure.Repositories
{
    public class TokenService : ITokenService
    {
        private readonly ILogger<TokenService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IRoleRepository _roleRepository;
        public TokenService(IRoleRepository roleRepository,ILogger<TokenService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _roleRepository = roleRepository;
        }

        public Task<string> GenerateRefreshTokenAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GenerateTokenAsync(User user)
        {
            var role = await _roleRepository.GetRoleByUserIdAsync(user.Id);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role.ToString()),
                new Claim("UserId", user.Id.ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName)
            };

            var token = new JwtSecurityToken
            (
                issuer: _configuration["JwtSettings:validIssuer"],
                audience: _configuration["JwtSettings:validAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: creds
            );

            _logger.LogInformation($"Token Generated for User {user.FirstName} {user.LastName} with Id of {user.Id}");

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return await Task.FromResult(jwt);
        }


    }
}
