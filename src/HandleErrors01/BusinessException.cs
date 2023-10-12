namespace HandleErrors01
{
    public class BusinessException : Exception
    {
        public BusinessException(string exceptionCode, string message)
            : base(message)
        {
            ExceptionCode = exceptionCode;
        }

        public BusinessException(string exceptionCode, string message, int statusCode)
            : base(message)
        {
            ExceptionCode = exceptionCode;
            StatusCode = statusCode;
        }

        public string ExceptionCode { get; set; } = "Unknown";

        public int StatusCode { get; set; } = StatusCodes.Status500InternalServerError;
    }
}
