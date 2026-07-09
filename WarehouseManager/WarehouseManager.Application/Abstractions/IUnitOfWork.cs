
namespace WarehouseManager.Application.Abstractions
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// THIS MUST BE CALLED AFTER ALMOST EVERY CONSECUITIVE REPOSITORY METHOD CALLS SO THAT ALL THE CHANGES MADE IS COMMITED
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
