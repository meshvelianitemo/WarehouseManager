
using MediatR;
using WarehouseManager.Application.Abstractions;
using WarehouseManager.Application.Results;

namespace WarehouseManager.Application.Features.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LoginCommandHandler(
            IUserRepository userRepository,
            ITokenService tokenService,
            IRefreshTokenRepository refreshTokenRepository,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _refreshTokenRepository = refreshTokenRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            //var dto = request.Dto;
            //var user = 
            throw new NotImplementedException();

        }
    }
}
