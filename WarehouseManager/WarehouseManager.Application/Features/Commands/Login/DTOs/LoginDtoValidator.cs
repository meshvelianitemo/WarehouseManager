
using FluentValidation;

namespace WarehouseManager.Application.Features.Commands.Login.DTOs
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(d => d.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(256).WithMessage("Email must not exceed 256 characters.")
                .EmailAddress().WithMessage("Email is not a valid email address.");

            RuleFor(d => d.PasswordHash)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .MaximumLength(128).WithMessage("Password must not exceed 128 characters.");
        }
    }
}
