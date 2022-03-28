using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.Exceptions
{
    public class ExceptionMessages
    { // This class we create all the exception messages that we might return, so instead of typing "not found" a
      // billion times we just do ExceptionMessages.PersonNotFound, and pass the Id or w/e parameter that we had asked for so they know what we didn't find
        public static ErrorResponse PersonNotFoundMessage => new("Student or Professor not found with Id {0}", (int)HttpStatusCode.NotFound);
    }
}
