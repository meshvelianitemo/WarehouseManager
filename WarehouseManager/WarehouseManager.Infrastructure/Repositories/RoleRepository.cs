
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
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userId);
            
            return user!.Role.Name;
        }
    }
}
