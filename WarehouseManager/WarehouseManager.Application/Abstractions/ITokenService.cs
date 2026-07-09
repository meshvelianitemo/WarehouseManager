
using WarehouseManager.Application.Features.Login;
using WarehouseManager.Domain.Entities;

namespace WarehouseManager.Application.Abstractions
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(User user);
        Task<string> GenerateRefreshTokenAsync(User user);
    }
}
