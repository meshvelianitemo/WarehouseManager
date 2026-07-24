
using MediatR;
using WarehouseManager.Application.Abstractions;
using WarehouseManager.Application.Results;
using WarehouseManager.Application.Results.Errors;

namespace WarehouseManager.Application.Features.Commands.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Result>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public LogoutCommandHandler(IUserRepository userRepository,
            ITokenService tokenService,
            IRefreshTokenRepository refreshTokenRepository,
            IUnitOfWork unitOfWork)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _tokenService = tokenService;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var refreshToken = request.LogoutDto.RefreshToken;
            var userId = request.LogoutDto.UserId;
            var tokenHash = _tokenService
                .HashRefreshToken(refreshToken);
            var existingToken = await _refreshTokenRepository
                .GetByHashAsync(tokenHash);

            if (existingToken is null)
                return Result.Failure(UserError.InvalidRefreshToken);
            else if (existingToken.RevokedAt != null)
                return Result.Failure(UserError.RevokedRefreshToken);
            else if (existingToken.ExpiresAt < DateTime.UtcNow)
                return Result.Failure(UserError.ExpiredRefreshToken);
            
            if (existingToken.User ==null)
                return Result.Failure(UserError.UserNotFound);
            if (!existingToken.User.IsActive)
                return Result.Failure(UserError.UserNotActive);
            if (existingToken.User.Id != userId)
                return Result.Failure(UserError.InvalidRefreshToken);

            await _refreshTokenRepository.RevokeAsync(existingToken.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    
    }
}
