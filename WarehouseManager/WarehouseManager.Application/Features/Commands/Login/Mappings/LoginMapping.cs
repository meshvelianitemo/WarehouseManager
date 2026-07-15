
using WarehouseManager.Application.Features.Commands.Login.DTOs;
using WarehouseManager.Domain.Entities;

namespace WarehouseManager.Application.Features.Commands.Login.Mappings
{
    public static class LoginMapping
    {
        public static LoginDto ToLoginDto(this User user)
        {
            return new LoginDto
            {
                UserId = user.Id,
                RoleId = user.RoleId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Salt = user.Salt
            };
        }
    }
}
