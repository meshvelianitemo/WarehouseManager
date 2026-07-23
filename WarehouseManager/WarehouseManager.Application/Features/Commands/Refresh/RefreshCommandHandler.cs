
using MediatR;
using WarehouseManager.Application.Abstractions;
using WarehouseManager.Application.Features.Commands.Login.DTOs;
using WarehouseManager.Application.Features.Commands.Refresh;
using WarehouseManager.Application.Results;
using WarehouseManager.Application.Results.Errors;

namespace WarehouseManager.Application.Features.Commands.Refresh
{
    public class RefreshCommandHandler : IRequestHandler<RefreshCommand, Result<AuthResponse>>
    {
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;
        public RefreshCommandHandler(ITokenService tokenService,
            IUnitOfWork unitOfWork,
            IRefreshTokenRepository refreshTokenRepository,
            IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
        }
        public async Task<Result<AuthResponse>> Handle(RefreshCommand request, CancellationToken cancellationToken)
        {
            var hashedToken = _tokenService
                .HashRefreshToken(request.RefreshToken);

            var refreshToken = await _refreshTokenRepository
                .GetByHashAsync(hashedToken); 
            if (refreshToken is null)
                return Result<AuthResponse>.Failure(UserError.InvalidRefreshToken);

            if (!refreshToken.User.IsActive)
                return Result<AuthResponse>.Failure(UserError.UserNotActive);

            if (refreshToken.RevokedAt != null)
                return Result<AuthResponse>.Failure(UserError.RevokedRefreshToken);

            if (refreshToken.ExpiresAt < DateTime.UtcNow)
                return Result<AuthResponse>.Failure(UserError.ExpiredRefreshToken);
            
            var newRefreshToken = _tokenService
                .GenerateRefreshToken(refreshToken.User);
            var newHashedToken = _tokenService
                .HashRefreshToken(newRefreshToken);

            var accessToken = await _tokenService
                .GenerateTokenAsync(refreshToken.User);

            refreshToken.RevokedAt = DateTime.UtcNow;

            await _refreshTokenRepository.AddAsync(newHashedToken, refreshToken.User);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<AuthResponse>
                .Success(new AuthResponse(accessToken, newRefreshToken));
        }
    }
}
