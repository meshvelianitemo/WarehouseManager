
using FluentValidation;
using WarehouseManager.Application.Features.Commands.Login.DTOs;

namespace WarehouseManager.Application.Features.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(c => c.Dto)
                .NotNull()
                .WithMessage("Login data is required.");

            RuleFor(c => c.Dto)
                .SetValidator(new LoginDtoValidator()!)
                .When(c => c.Dto is not null);
        }
    }
}
