
using MediatR;
using Microsoft.AspNetCore.Identity;
using WarehouseManager.Application.Abstractions;
using WarehouseManager.Application.Features.Commands.Register.Mappings;
using WarehouseManager.Application.Results;
using WarehouseManager.Application.Results.Errors;
using WarehouseManager.Domain.Entities;
using WarehouseManager.Domain.Enums;

namespace WarehouseManager.Application.Features.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<Guid>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<User> _passwordHasher;

        public RegisterCommandHandler(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IUnitOfWork unitOfWork,
            IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task<Result<Guid>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var existingUser = await _userRepository
                .GetByEmailAsync(dto.Email);

            if (existingUser != null)
                return Result<Guid>.Failure(UserError.EmailInUse);

            var user = RegisterMapping.ToEntity(dto);

            user.RoleId = await _roleRepository
                .GetGuid(RoleName.ReadOnly);

            user.PasswordHash = _passwordHasher
                .HashPassword(user, dto.Password);

            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(user.Id);
        }
    }
}
