

namespace WarehouseManager.Application.Results
{
    public class Error
    {
        public ErrorCode Code { get; }
        public string Message { get; }
        public string? Field { get; }

        public Error(ErrorCode code, string message, string? field)
        {
            Code = code;
            Message = message;
            Field = field;
        }
        public Error(ErrorCode code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
