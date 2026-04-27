namespace OrderManagement.Persistence.Persistence.Common
{
    public class Result
    {
        public bool IsSuccessful { get; protected set; }
        public string Message { get; protected set; }
        public string? ErrorCode { get; protected set; }

        public Result(bool isSuccessful, string message, string? errorCode = null)
        {
            IsSuccessful = isSuccessful;
            Message = message;
            ErrorCode = errorCode;
        }

        public static Result Success(string message = "Success")
            => new Result(true, message);

        public static Result Failure(string message, string? errorCode = null)
            => new Result(false, message, errorCode);

        public static Result Exception(Exception ex)
            => new Result(false, ex.Message, "EXCEPTION");
        public static Result<T> Success<T>(T data, string message = "Success")
            => Result<T>.Success(data, message);

    }
}
