
using WarehouseManager.Application.Features.Login;
using WarehouseManager.Domain.Entities;

namespace WarehouseManager.Application.Abstractions
{
    public interface ITokenService
    {
        public Task<string> GenerateTokenAsync(User user);
        public Task<string> GenerateRefreshTokenAsync(User user);
    }
}
