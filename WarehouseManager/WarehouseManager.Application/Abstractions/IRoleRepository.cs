
using System.Dynamic;
using WarehouseManager.Application.Results;
using WarehouseManager.Domain.Enums;

namespace WarehouseManager.Application.Abstractions
{
    public interface IRoleRepository
    {
        Task<RoleName> GetRoleByUserIdAsync(Guid userId);
        Task<Guid> GetGuid(RoleName roleName);
    }
}
