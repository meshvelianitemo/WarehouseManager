
using WarehouseManager.Domain.Entities;

namespace WarehouseManager.Application.Features.Register
{
    public class UserRegistrationDto
    {
        public Guid UserId { get; set;}
        public Guid RoleId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Role Role { get; set; } = null!;
    }
}
