

namespace WarehouseManager.Application.Results
{
    public class Error
    {
        public string Code { get; }
        public string Message { get; }
        public string? Field { get; }

        public Error(string code, string message, string? field)
        {
            Code = code;
            Message = message;
            Field = field;
        }
        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
