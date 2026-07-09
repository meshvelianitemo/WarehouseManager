
using WarehouseManager.Application.Features.Register;
using WarehouseManager.Application.Results;
using WarehouseManager.Domain.Entities;

namespace WarehouseManager.Application.Abstractions
{
    public interface IAuthRepository
    {
        public Task<Result> AddUser(UserRegistrationDto dto);
    }
}
