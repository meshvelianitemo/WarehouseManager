
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WarehouseManager.Application.Abstractions;
using WarehouseManager.Application.Features.Login;

namespace WarehouseManager.Infrastructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly ILogger<TokenRepository> _logger;
        private readonly IConfiguration _configuration;
        public TokenRepository(ILogger<TokenRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public Task<string> GenerateTokenAsync(UserLoginDto dto)
        {
            
        }
    }
}
