
namespace WarehouseManager.Application.Results.Exceptions
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public string ErrorCode { get; set; } = string.Empty;
        public Dictionary<string, string[]> Errors { get; set; } 
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
