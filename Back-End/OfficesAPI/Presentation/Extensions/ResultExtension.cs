using Application.DTO.Result;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Extensions
{
    public static class ResultExtension
    {
        public static ActionResult ToActionResult<T>(this Result<T> result)
        {
            return result.ErrorType switch
            {
                EVErrorType.Validation => new BadRequestObjectResult(result.Message),
                EVErrorType.UserAccess => new UnauthorizedObjectResult(result.Message!),
                EVErrorType.NotFound => new NotFoundObjectResult(result.Message),
                EVErrorType.Business => new ConflictObjectResult(result.Message),
                _ => new OkObjectResult(result.Data)
            };
        }

        public static ActionResult ToActionResult(this Result result)
        {
            return result.ErrorType switch
            {
                EVErrorType.Validation => new BadRequestObjectResult(result.Message),
                EVErrorType.UserAccess => new UnauthorizedObjectResult(result.Message!),
                EVErrorType.NotFound => new NotFoundObjectResult(result.Message),
                EVErrorType.Business => new ConflictObjectResult(result.Message),
                _ => new NoContentResult()
            };
        }
    }
}
