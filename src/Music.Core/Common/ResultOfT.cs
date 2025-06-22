namespace Music.Core.Common
{
    public class Result<TValue> : Result
    {
        public TValue Data { get; set; }

        protected internal Result(TValue data, bool success, int statusCode, string message, string error)
            : base(success, statusCode, message, error)
        {
            Data = data;
        }
    }
}
