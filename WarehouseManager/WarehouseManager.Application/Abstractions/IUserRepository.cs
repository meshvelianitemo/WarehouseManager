
using WarehouseManager.Application.Features.Register;
using WarehouseManager.Application.Results;
using WarehouseManager.Domain.Entities;

namespace WarehouseManager.Application.Abstractions
{
    public interface IUserRepository
    {
        public Task<Result> AddUser(UserRegistrationDto dto);
    }
}
