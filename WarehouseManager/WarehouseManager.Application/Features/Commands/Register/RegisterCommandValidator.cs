
using FluentValidation;
using WarehouseManager.Application.Features.Commands.Register.DTOs;

namespace WarehouseManager.Application.Features.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c => c.Dto)
                .NotNull()
                .WithMessage("Registration data is required.");

            RuleFor(c => c.Dto)
                .SetValidator(new RegisterDtoValidator()!)
                .When(c => c.Dto is not null);
        }
    }
}
