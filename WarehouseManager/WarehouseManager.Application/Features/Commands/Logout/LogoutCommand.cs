
using MediatR;
using Microsoft.IdentityModel.Tokens.Experimental;
using WarehouseManager.Application.Features.Commands.Logout.DTOs;
using WarehouseManager.Application.Results;

namespace WarehouseManager.Application.Features.Commands.Logout
{
    public class LogoutCommand : IRequest<Result>
    {
        public LogoutDto LogoutDto { get; set; } 
        public LogoutCommand(LogoutDto logoutDto)
        {
            LogoutDto = logoutDto;
        }
    }
}
