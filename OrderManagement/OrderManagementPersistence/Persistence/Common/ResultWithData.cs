using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Persistence.Persistence.Common
{
    public class Result<T> : Result
    {
        public T? Data { get; private set; }

        private Result(bool isSuccessful, string message, T? data, string? errorCode = null)
            : base(isSuccessful, message, errorCode)
        {
            Data = data;
        }

        public static Result<T> Success(T data, string message = "Success")
            => new Result<T>(true, message, data);

        public static new Result<T> Failure(string message, string? errorCode = null)
            => new Result<T>(false, message, default, errorCode);

        public static Result<T> Exception(Exception ex)
            => new Result<T>(false, ex.Message, default, "EXCEPTION");
    }
}
