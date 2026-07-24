

namespace WarehouseManager.Application.Features.Query.GetCurrentUser.DTOs
{
    public sealed record CurrentUserDto
    (string firstName,
        string lastName,
        string email,
        string role
        );
}
