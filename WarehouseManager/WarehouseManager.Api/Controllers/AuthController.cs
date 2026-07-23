using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using WarehouseManager.Application.Features.Commands.Register;
using WarehouseManager.Application.Features.Commands.Register.DTOs;
using WarehouseManager.Application.Features.Commands.Login;
using WarehouseManager.Application.Features.Commands.Login.DTOs;
using WarehouseManager.Application.Features.Commands.Refresh;

namespace WarehouseManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly ISender _sender;
        public AuthController(ISender sender, ILogger<AuthController> logger)
        {
            _sender = sender;
            _logger = logger;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto request
            , CancellationToken cancellationToken)
        {
            var result = await _sender
                .Send(new RegisterCommand(request), cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto request
            , CancellationToken cancellationToken)
        {
            var result = await _sender
                .Send(new LoginCommand(request), cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] string refreshToken
            , CancellationToken cancellationToken)
        {
            var result = await _sender
                .Send(new RefreshCommand(refreshToken), cancellationToken);
            return this.ToActionResult(result);
        }
    }
}
    