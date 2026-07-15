
using MediatR;
using WarehouseManager.Application.Features.Commands.Login.DTOs;
using WarehouseManager.Application.Results;

namespace WarehouseManager.Application.Features.Commands.Login
{
    public class LoginCommand : IRequest<Result<string>>
    {
        public LoginDto Dto { get; }

        public LoginCommand(LoginDto dto)
        {
            Dto = dto;
        }
    }
}
