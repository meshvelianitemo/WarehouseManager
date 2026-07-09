
using WarehouseManager.Application.Abstractions;
using WarehouseManager.Infrastructure.Persistance;

namespace WarehouseManager.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WmsDbContext _context;
        public UnitOfWork(WmsDbContext context)
        {
            _context = context;
        }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
