
namespace WarehouseManager.Application.Features.Commands.Logout.DTOs
{
    public class LogoutDto
    {
        public string RefreshToken { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}
