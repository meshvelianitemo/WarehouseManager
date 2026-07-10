
using WarehouseManager.Domain.Entities;

namespace WarehouseManager.Application.Abstractions
{
    public interface IRefreshTokenRepository
    {
        Task<Guid> AddAsync(string tokenHash, User user);
        Task<RefreshToken?> GetByHashAsync(string tokenHash);
        Task RevokeAsync(Guid refreshTokenId);
        void Delete(Guid refreshTokenId);
        Task DeleteExpiredAsync();
        Task<List<RefreshToken>> GetUserRefreshTokensAsync(Guid userId);
    }
}
