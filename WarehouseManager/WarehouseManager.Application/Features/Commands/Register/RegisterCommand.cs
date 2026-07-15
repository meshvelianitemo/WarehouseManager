
using MediatR;
using WarehouseManager.Application.Features.Commands.Register.DTOs;
using WarehouseManager.Application.Results;

namespace WarehouseManager.Application.Features.Commands.Register
{
    public class RegisterCommand : IRequest<Result<Guid>>
    {
        public RegisterDto Dto { get; }

        public RegisterCommand(RegisterDto dto)
        {
            Dto = dto;
        }
    }
}
