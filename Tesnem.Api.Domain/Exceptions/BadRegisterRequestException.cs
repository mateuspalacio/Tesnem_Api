using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.Exceptions
{
    public class BadRegisterRequestException : ErrorException
    {
        public BadRegisterRequestException(ErrorResponse errorResponse, object? obj) : base(errorResponse, obj)
        {
        }
    }
}
