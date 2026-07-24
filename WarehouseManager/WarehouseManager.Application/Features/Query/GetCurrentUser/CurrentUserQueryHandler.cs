
using MediatR;
using Microsoft.AspNetCore.Identity;
using WarehouseManager.Application.Abstractions;
using WarehouseManager.Application.Features.Query.GetCurrentUser.DTOs;
using WarehouseManager.Application.Features.Query.GetCurrentUser.Mappings;
using WarehouseManager.Application.Results;
using WarehouseManager.Application.Results.Errors;

namespace WarehouseManager.Application.Features.Query.GetCurrentUser
{
    public class CurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, Result<CurrentUserDto>>
    {
        private readonly IUserRepository _userRepository;
       
        public CurrentUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<CurrentUserDto>> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var user =await _userRepository
                .GetByIdAsync(request.UserId);
                
            if (user == null)
                return Result<CurrentUserDto>.Failure(UserError.UserNotFound);
            if (!user.IsActive)
                return Result<CurrentUserDto>.Failure(UserError.UserNotActive);

            return Result<CurrentUserDto>.Success(user.ToDto());
        }
    }
}
