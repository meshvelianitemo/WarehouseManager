using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManager.Application.Features.Query.GetCurrentUser.DTOs;
using WarehouseManager.Application.Results;

namespace WarehouseManager.Application.Features.Query.GetCurrentUser
{
    public record GetCurrentUserQuery (Guid UserId) : IRequest<Result<CurrentUserDto>>;
}
