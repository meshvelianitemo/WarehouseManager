
using WarehouseManager.Application.Features.Commands.Register.DTOs;
using WarehouseManager.Domain.Entities;

namespace WarehouseManager.Application.Features.Commands.Register.Mappings
{
    public static class RegisterMapping
    {
        public static User ToEntity(this RegisterDto dto)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
