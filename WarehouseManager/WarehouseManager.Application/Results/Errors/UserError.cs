
using WarehouseManager.Application.Results.Exceptions;

namespace WarehouseManager.Application.Results.Errors
{
    public static class UserError
    {
        public static readonly Error EmailInUse =
            new(ErrorCode.Conflict, "Email is already Used!", "Users");

        public static readonly Error RoleNotFound =
            new(ErrorCode.NotFound, "Role was not found!", "Users");

        public static readonly Error UserNotFound =
            new(ErrorCode.NotFound, "User was not found!", "Users");

        public static readonly Error InvalidCredentials =
            new(ErrorCode.Unauthorized, "User was not found!", "Users");

        public static readonly Error InvalidRefreshToken =
            new(ErrorCode.Forbidden, "Invalid refresh token!", "Users");

        public static readonly Error UserNotActive =
            new(ErrorCode.Unauthorized, "User is not active!", "Users");

        public static readonly Error RevokedRefreshToken =
            new(ErrorCode.Unauthorized, "Refresh token is already revoked!", "Users");

        public static readonly Error ExpiredRefreshToken =
            new(ErrorCode.Unauthorized, "Refresh token is expired!", "Users");
    }
}
