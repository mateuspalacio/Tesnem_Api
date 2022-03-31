using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.Exceptions
{
    public class ErrorException : Exception
    {
        public ErrorResponse ErrorResponse { get; set; }
        public ErrorException(ErrorResponse errorResponse, object? obj)
        {
            ErrorResponse = errorResponse;
            ErrorResponse.ErrorValueOrField = obj;
        }
    }
    public class ErrorResponse
    {
        private readonly string message;
        public string Message { get => string.Format(message, ErrorValueOrField); init => message = value; }
        public int StatusCode { get; set; }
        public object ErrorValueOrField { get; set; }
        public ErrorResponse(string message, int code)
        {
            Message = message;
            StatusCode = code;
        }
    }
}
