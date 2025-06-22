using System.Text.Json.Serialization;

namespace Music.Core.Common
{
    public class Result
    {
        public bool Success { get; }
        /// <summary>
        /// dev environment is ex.StackTrace
        /// production is null or anything 
        /// </summary>
        public string Error { get; }
        public string Message { get; }
        public int StatusCode { get; }

        protected Result(bool success, string message = null, string error = null)
        {
            Success = success;
            Error = error;
            Message = message;
        }

        protected Result(bool success, int statusCode, string message = null, string error = null)
        {
            Success = success;
            Error = error;
            Message = message;
            StatusCode = statusCode;
        }

        public static Result Ok(string message = null)
        {
            return new Result(true, 200, message, null);
        }

        public static Result Ok(int statusCode, string message = null)
        {
            return new Result(true, statusCode, message, null);
        }

        public static Result<TValue> Ok<TValue>(TValue value, int statusCode, string message = null)
        {
            return new Result<TValue>(value, true, statusCode, message, null);
        }

        public static Result<TValue> Ok<TValue>(TValue value, string message = null)
        {
            return new Result<TValue>(value, true, 200, message, null);
        }


        public static Result Fail(int statusCode, string message = null, string error = null)
        {
            return new Result(false, statusCode, message, error);
        }


        public static Result<TValue> Fail<TValue>(int statusCode, string messsage = null, string error = null)
        {
            return new Result<TValue>(default(TValue), false, statusCode, messsage, error);
        }

    }
}
