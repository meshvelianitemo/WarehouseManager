
namespace WarehouseManager.Application.Results
{
    public enum ErrorCode
    { 
        // 400 Bad Request
        Validation,
        BadRequest,

        // 401 Unauthorized
        Unauthorized,

        // 403 Forbidden
        Forbidden,

        // 404 Not Found
        NotFound,

        // 409 Conflict
        Conflict,

        // 410 Gone (optional)
        Gone,

        // 422 Unprocessable Entity
        UnprocessableEntity,

        // 429 Too Many Requests
        TooManyRequests,

        // 500 Internal Server Error
        InternalServerError,

        // 501 Not Implemented
        NotImplemented,

        // 503 Service Unavailable
        ServiceUnavailable
    }
}
