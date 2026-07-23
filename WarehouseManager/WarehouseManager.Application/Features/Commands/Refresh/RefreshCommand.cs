
using MediatR;
using WarehouseManager.Application.Features.Commands.Login.DTOs;
using WarehouseManager.Application.Results;

namespace WarehouseManager.Application.Features.Commands.Refresh
{
    public class RefreshCommand : IRequest<Result<AuthResponse>>
    {
        public string RefreshToken { get; }

        public RefreshCommand(string refreshToken)
        {
            RefreshToken = refreshToken;
        }
    }
}
