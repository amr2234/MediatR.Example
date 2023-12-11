using MediatR.Example.ErrorHandling;
using System.Net;
using System.Text.Json;

namespace MediatR.Example.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<ExceptionMiddleware> _Explogger;
        private readonly IHostEnvironment _environment;

        public ExceptionMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionMiddleware> explogger, IHostEnvironment environment)
        {
            _requestDelegate = requestDelegate;
            _Explogger = explogger;
            _environment = environment;
        }

        public async Task Invoke(HttpContext context) {

            try
            {
                 await _requestDelegate(context);
            }
            catch (Exception e) {

                _Explogger.LogError(e, e.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = _environment.IsDevelopment()
                   ? new ApiExceptionHandler((int)HttpStatusCode.InternalServerError, e.Message, e.StackTrace.ToString())
                   : new ApiExceptionHandler((int)HttpStatusCode.InternalServerError);
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);

            }
           
        
        }
    }
}
