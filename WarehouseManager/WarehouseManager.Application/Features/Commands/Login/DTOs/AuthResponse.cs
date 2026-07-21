
using MediatR.NotificationPublishers;

namespace WarehouseManager.Application.Features.Commands.Login.DTOs
{
    public class AuthResponse
    {
        public string AccessToken { get; set;  } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public AuthResponse(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

    }
}
