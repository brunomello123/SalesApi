using System.Net;

namespace SalesApi.Domain.Exceptions
{
    public class BusinessException(string message, HttpStatusCode statusCode, string detail = "")
        : Exception(message)
    {
        public HttpStatusCode StatusCode { get; } = statusCode;
        public string ErrorType { get; } = statusCode.ToString();
        public string Detail { get; } = detail;
    }
}