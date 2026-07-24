using Azure;
using Microsoft.AspNetCore.Mvc;
using WarehouseManager.Application.Results;

namespace WarehouseManager.Api
{
    public static class ResultMapper
    {
        public static IActionResult ToActionResult<T>(
            this ControllerBase controller,
            Result<T> result)
        {
            if (result.IsSuccess)
                return controller.Ok(result.Value);

            var response = new ErrorResponse
            {
                Code = result.Error.Code,
                Message = result.Error.Message,
                Field = result.Error.Field
            };

            return result.Error.Code switch
            {
                // 400
                ErrorCode.Validation => controller.BadRequest(response),
                ErrorCode.BadRequest => controller.BadRequest(response),

                // 401
                ErrorCode.Unauthorized => controller.Unauthorized(response),

                // 403
                ErrorCode.Forbidden => controller.StatusCode(StatusCodes.Status403Forbidden, response),

                // 404
                ErrorCode.NotFound => controller.NotFound(response),

                // 409
                ErrorCode.Conflict => controller.Conflict(response),

                // 410
                ErrorCode.Gone => controller.StatusCode(StatusCodes.Status410Gone, response),

                // 422
                ErrorCode.UnprocessableEntity => controller.UnprocessableEntity(response),

                // 429
                ErrorCode.TooManyRequests => controller.StatusCode(StatusCodes.Status429TooManyRequests, response),

                // 500
                ErrorCode.InternalServerError => controller.StatusCode(StatusCodes.Status500InternalServerError, response),

                // 501
                ErrorCode.NotImplemented => controller.StatusCode(StatusCodes.Status501NotImplemented, response),

                // 503
                ErrorCode.ServiceUnavailable => controller.StatusCode(StatusCodes.Status503ServiceUnavailable, response),

                // Fallback
                _ => controller.StatusCode(StatusCodes.Status500InternalServerError, response)
            };
        }

        public static IActionResult ToActionResult(
            this ControllerBase controller,
            Result result)
        {
            if (result.IsSuccess)
                return controller.NoContent();

            var response = new ErrorResponse
            {
                Code = result.Error.Code,
                Message = result.Error.Message,
                Field = result.Error.Field
            };

            return result.Error.Code switch
            {
                ErrorCode.Validation => controller.BadRequest(response),
                // ...
                _ => controller.StatusCode(500, response)
            };
        }
    }
}