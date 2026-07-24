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
using Microsoft.AspNetCore.Authorization;
using WarehouseManager.Application.Features.Commands.Logout;
using System.Security.Claims;
using WarehouseManager.Application.Features.Commands.Logout.DTOs;
using WarehouseManager.Application.Features.Query.GetCurrentUser;

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

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser(CancellationToken cancellationToken)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized(new { message = "User is not authenticated." });
            }
            var result = await _sender
                .Send(new GetCurrentUserQuery(Guid.Parse(userId)), cancellationToken);
            return this.ToActionResult(result);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto request
            , CancellationToken cancellationToken)
        {
            var result = await _sender
                .Send(new RegisterCommand(request), cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto request
            , CancellationToken cancellationToken)
        {
            var result = await _sender
                .Send(new LoginCommand(request), cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] string refreshToken
            , CancellationToken cancellationToken)
        {
            var result = await _sender
                .Send(new RefreshCommand(refreshToken), cancellationToken);
            return this.ToActionResult(result);
        }

        [Authorize]
        [HttpPut("logout")]
        public async Task<IActionResult> Logout([FromBody] string refreshToken
            , CancellationToken cancellationToken)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dto = new LogoutDto
            {
                RefreshToken = refreshToken,
                UserId = Guid.Parse(userId)
            };
            var result = await _sender
                .Send(new LogoutCommand(dto), cancellationToken);
            return this.ToActionResult(result);
        }
    }
}
    