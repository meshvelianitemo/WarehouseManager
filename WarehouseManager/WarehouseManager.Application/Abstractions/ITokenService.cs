
using System.Runtime.CompilerServices;
using WarehouseManager.Domain.Entities;

namespace WarehouseManager.Application.Abstractions
{
    public interface ITokenService
    {
        string HashRefreshToken(string token);
        Task<string> GenerateTokenAsync(User user);
        string GenerateRefreshToken(User user);

    }
}
