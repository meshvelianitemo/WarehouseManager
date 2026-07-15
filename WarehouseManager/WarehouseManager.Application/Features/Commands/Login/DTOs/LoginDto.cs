
namespace WarehouseManager.Application.Features.Commands.Login.DTOs
{
    public class LoginDto
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Salt {  get; set; } = string.Empty;
    }
}
