
using FluentValidation;
using MediatR;
using System.Drawing;
using WarehouseManager.Application.Features.Commands.Login.DTOs;
using WarehouseManager.Application.Results;

namespace WarehouseManager.Application.Features.Commands.Refresh
{
    public class RefreshCommandValidator : AbstractValidator<RefreshCommand>
    {
        public RefreshCommandValidator()
        {
            RuleFor(c => c.RefreshToken)
                .NotNull()
                .WithMessage("refresh token is required.");

            //RuleFor(c => c.RefreshToken)
            //    .SetValidator(new RefreshTokenValidator()!)
            //    .When(c => c.Dto is not null);
        }
    }
}
