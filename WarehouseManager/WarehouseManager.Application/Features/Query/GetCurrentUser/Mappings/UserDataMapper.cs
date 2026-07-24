
using WarehouseManager.Application.Features.Query.GetCurrentUser.DTOs;
using WarehouseManager.Domain.Entities;

namespace WarehouseManager.Application.Features.Query.GetCurrentUser.Mappings
{
    public static class UserDataMapper
    {
        public static CurrentUserDto ToDto(this User user)
        {
            return new CurrentUserDto(
                user.FirstName,
                user.LastName,
                user.Email,
                user.Role.ToString()!
            );
        }
    }
}
