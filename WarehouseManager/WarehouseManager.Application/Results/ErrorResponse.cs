
namespace WarehouseManager.Application.Results
{
    public class ErrorResponse
    {
        public ErrorCode Code { get; init; }
        public string Message { get; init; } = string.Empty;
        public string? Field { get; init; }
    }
}
