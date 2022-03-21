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
        public ErrorException(ErrorResponse errorResponse)
        {
            ErrorResponse = errorResponse;
        }
    }
    public class ErrorResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
