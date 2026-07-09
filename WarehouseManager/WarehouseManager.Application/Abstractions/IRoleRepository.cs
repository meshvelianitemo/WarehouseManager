
using System.Dynamic;
using WarehouseManager.Application.Results;
using WarehouseManager.Domain.Enums;

namespace WarehouseManager.Application.Abstractions
{
    public interface IRoleRepository
    {
        public Task<RoleName> GetRoleByUserIdAsync(Guid userId);
    }
}
