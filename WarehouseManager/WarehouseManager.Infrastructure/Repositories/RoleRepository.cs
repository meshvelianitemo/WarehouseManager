
using Microsoft.EntityFrameworkCore;
using WarehouseManager.Application.Abstractions;
using WarehouseManager.Domain.Enums;
using WarehouseManager.Infrastructure.Persistance;

namespace WarehouseManager.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly WmsDbContext _context;
        public RoleRepository(WmsDbContext context)
        {
            _context = context;
        }
        public async Task<RoleName> GetRoleByUserIdAsync(Guid userId)
        {
            return await _context.Users
                .AsNoTracking()
                .Where(u => u.Id == userId)
                .Select(u => u.Role.Name)
                .FirstAsync();
        }
    }
}
