
using MediatR;
using WarehouseManager.Application.Features.Commands.Login.DTOs;
using WarehouseManager.Application.Results;

namespace WarehouseManager.Application.Features.Commands.Login
{
    public class LoginCommand : IRequest<Result<AuthResponse>>
    {
        public LoginDto Dto { get; }

        public LoginCommand(LoginDto dto)
        {
            Dto = dto;
        }
    }
}
