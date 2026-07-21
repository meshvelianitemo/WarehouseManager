
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens.Experimental;
using WarehouseManager.Application.Abstractions;
using WarehouseManager.Application.Features.Commands.Login.DTOs;
using WarehouseManager.Application.Results;
using WarehouseManager.Application.Results.Errors;
using WarehouseManager.Domain.Entities;

namespace WarehouseManager.Application.Features.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<AuthResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<User> _passwordHasher;

        public LoginCommandHandler(
            IUserRepository userRepository,
            ITokenService tokenService,
            IRefreshTokenRepository refreshTokenRepository,
            IUnitOfWork unitOfWork,
            IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _tokenService = tokenService;
            _refreshTokenRepository = refreshTokenRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<AuthResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var existingUser  = await _userRepository
                .GetByEmailAsync(dto.Email);
            if (existingUser == null)
                return Result<AuthResponse>.Failure(UserError.UserNotFound);

            var result = _passwordHasher
                .VerifyHashedPassword(existingUser,
                existingUser.PasswordHash,
                dto.Password);
            if(result == PasswordVerificationResult.Failed)
                return Result<AuthResponse>.Failure(UserError.InvalidCredentials);
            if(result == PasswordVerificationResult.SuccessRehashNeeded)
                return Result<AuthResponse>.Failure(UserError.InvalidCredentials);

            var accessToken = await _tokenService
                .GenerateTokenAsync(existingUser);
            var rawRefreshToken = _tokenService
                .GenerateRefreshToken(existingUser);
            
            var hashedRefreshToken = _tokenService
                .HashRefreshToken(rawRefreshToken);

            var tokenId = await _refreshTokenRepository
                .AddAsync(hashedRefreshToken, existingUser);

            await _unitOfWork.SaveChangesAsync();
            return Result<AuthResponse>.Success(new AuthResponse(accessToken, rawRefreshToken));
        }
    }
}
