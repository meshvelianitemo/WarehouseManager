
using Microsoft.EntityFrameworkCore;
using WarehouseManager.Application.Abstractions;
using WarehouseManager.Domain.Entities;
using WarehouseManager.Infrastructure.Persistance;

namespace WarehouseManager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IRoleRepository _roleRepository;
        private readonly WmsDbContext _context;
        public UserRepository(IRoleRepository roleRepository, WmsDbContext context)
        {
            _context = context;
            _roleRepository = roleRepository;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Users
                .AsNoTracking()
                .AnyAsync(u => u.Email == email);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users
                .FindAsync(id);
        }

        public async Task UpdateAsync(User user)
        {

            user.FirstName = user.FirstName;
            user.LastName = user.LastName;
            user.Email = user.Email;
            user.PasswordHash = user.PasswordHash;
            user.UpdatedAt = DateTime.UtcNow;

        }
    }
}
