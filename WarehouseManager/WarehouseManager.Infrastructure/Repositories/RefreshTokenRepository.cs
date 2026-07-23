
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WarehouseManager.Application.Abstractions;
using WarehouseManager.Domain.Entities;
using WarehouseManager.Domain.Enums;
using WarehouseManager.Infrastructure.Persistance;

namespace WarehouseManager.Infrastructure.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ILogger<TokenService> _logger;
        private readonly IRoleRepository _roleRepository;
        private readonly WmsDbContext _context;
        public RefreshTokenRepository(WmsDbContext context,IRoleRepository roleRepository, ILogger<TokenService> logger)
        {
            _logger = logger;
            _roleRepository = roleRepository;
            _context = context;
        }
        public async Task<Guid> AddAsync(string tokenHash, User user)
        {
            var refreshToken = new RefreshToken
            {
                Id = Guid.NewGuid(),
                TokenHash = tokenHash,
                ExpiresAt = DateTime.UtcNow.AddDays(20),
                RevokedAt = null,
                UserId = user.Id, 
                CreatedAt = DateTime.UtcNow
            };
            await _context.RefreshTokens.AddAsync(refreshToken);

            return refreshToken.Id;
        }

        public void Delete(Guid refreshTokenId)
        {
            _context.RefreshTokens
                .Remove(new RefreshToken { Id = refreshTokenId});
        }

        public async Task DeleteExpiredAsync()
        {
            var expired= await _context.RefreshTokens
                .Where(r => r.ExpiresAt < DateTime.UtcNow || r.RevokedAt != null)
                .ToListAsync();

            _context.RefreshTokens.RemoveRange(expired);
        }

        public async Task<RefreshToken?> GetByHashAsync(string tokenHash)
        {
           return await _context.RefreshTokens
                .Include(x=> x.User)
                .FirstOrDefaultAsync(r => r.TokenHash == tokenHash);
        }

        public async Task<List<RefreshToken>> GetUserRefreshTokensAsync(Guid userId)
        {
            return await _context.RefreshTokens
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }

        public async Task RevokeAsync(Guid refreshTokenId)
        {
             await _context.RefreshTokens
                .Where(r => r.Id == refreshTokenId)
                .ExecuteUpdateAsync(r => r.SetProperty(rt => rt.RevokedAt, rt => DateTime.UtcNow));
        }
    }
}
