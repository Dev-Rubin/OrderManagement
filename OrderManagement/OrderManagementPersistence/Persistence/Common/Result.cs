namespace OrderManagement.Persistence.Persistence.Common
{
    public class Result
    {
        public bool IsSuccessful { get; protected set; }
        public string Message { get; protected set; }
        public string? ErrorCode { get; protected set; }
        public object? Data { get; protected set; }

        public Result(bool isSuccessful, string message, string? errorCode = null, object? data = null)
        {
            IsSuccessful = isSuccessful;
            Message = message;
            ErrorCode = errorCode;
            Data = data;
        }

        public static Result Success(string message = "Success", object? data = null)
            => new Result(true, message, null, data);

        public static Result Failure(string message, string? errorCode = null, object? data = null)
            => new Result(false, message, errorCode, data);
        public static Result Exception(Exception ex)
            => new Result(false, ex.Message, "EXCEPTION");
        public static Result<T> Success<T>(T data, string message = "Success", object? additionalData = null)
            => Result<T>.Success(data, message, additionalData);

    }
}
