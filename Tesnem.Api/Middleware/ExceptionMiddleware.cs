using Tesnem.Api.Domain.Exceptions;

namespace Tesnem.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (ex is ErrorException error)
                {
                    var response = new Error() { };
                    response.Message = error.ErrorResponse.Message;
                    response.StatusCode = error.ErrorResponse.StatusCode;
                    context.Response.StatusCode = error.ErrorResponse.StatusCode;
                    await context.Response.WriteAsJsonAsync(response);
                } else
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
    public class Error
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
