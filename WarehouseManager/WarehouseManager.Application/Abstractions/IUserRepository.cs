
using WarehouseManager.Application.Features.Register;
using WarehouseManager.Application.Results;
using WarehouseManager.Domain.Entities;

namespace WarehouseManager.Application.Abstractions
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByEmailAsync(string email);
        Task<bool> ExistsByEmailAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
