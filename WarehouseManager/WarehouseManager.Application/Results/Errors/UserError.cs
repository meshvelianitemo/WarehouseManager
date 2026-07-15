
using WarehouseManager.Application.Results.Exceptions;

namespace WarehouseManager.Application.Results.Errors
{
    public static class UserError
    {
        public static readonly Error EmailInUse =
            new("User.EmailInUse", "Email is already Used!", "Users");
    }
}
