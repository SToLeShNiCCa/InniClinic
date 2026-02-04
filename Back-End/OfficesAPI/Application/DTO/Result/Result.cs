using Domain.Enums;

namespace Application.DTO.Result
{
    public class Result<T> : Result
    {
        public T? Data { get; init; }

        public new static Result<T> SuccessResult()
            => new() { Success = true, ErrorType = EVErrorType.None, Message = null };

        public static Result<T> SuccessResult(T data)
            => new() { Success = true, Data = data, ErrorType = EVErrorType.None, Message = null };

        public new static Result<T> ValidationErrorResult(string message)
            => new() { Success = false, ErrorType = EVErrorType.Validation, Message = message };

        public new static Result<T> UserAccessErrorResult(string message)
            => new() { Success = false, ErrorType = EVErrorType.UserAccess, Message = message };

        public new static Result<T> NotFoundResult(string message)
            => new() { Success = false, ErrorType = EVErrorType.NotFound, Message = message };

        public new static Result<T> BusinessErrorResult(string message)
            => new() { Success = false, ErrorType = EVErrorType.Business, Message = message };

        public new static Result<T> ConvertFromResult(Result result)
            => new() { Success = result.Success, ErrorType = result.ErrorType, Message = result.Message };
    }

    public class Result
    {
        public bool Success { get; init; }
        public EVErrorType ErrorType { get; init; }
        public string? Message { get; init; }

        public static Result SuccessResult()
            => new() { Success = true, ErrorType = EVErrorType.None, Message = null };

        public static Result ValidationErrorResult(string message)
            => new() { Success = false, ErrorType = EVErrorType.Validation, Message = message };

        public static Result UserAccessErrorResult(string message)
            => new() { Success = false, ErrorType = EVErrorType.UserAccess, Message = message };

        public static Result NotFoundResult(string message)
            => new() { Success = false, ErrorType = EVErrorType.NotFound, Message = message };

        public static Result BusinessErrorResult(string message)
            => new() { Success = false, ErrorType = EVErrorType.Business, Message = message };

        public static Result ConvertFromResult(Result result)
            => new() { Success = result.Success, ErrorType = result.ErrorType, Message = result.Message };
    }
}
