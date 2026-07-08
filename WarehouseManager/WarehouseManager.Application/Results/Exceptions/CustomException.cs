
namespace WarehouseManager.Application.Results.Exceptions
{

    public class CustomException : Exception
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public CustomException(string message, string errorMessage = "INTERNAL_ERROR", int statusCode = 500, Exception innerException = null)
                        : base(message, innerException)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
        



    }
}
