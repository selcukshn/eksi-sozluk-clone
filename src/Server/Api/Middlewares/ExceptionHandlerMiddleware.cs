using System.Text;
using System.Net;
using Common.Exceptions.Base;
using Common.Models.Response;
using Newtonsoft.Json;

namespace Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate Next;
        private readonly ILogger<ExceptionHandlerMiddleware> Logger;
        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            Logger = logger;
            Next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception exception)
            {
                await ExceptionResponseAsync(exception, context);
            }
        }
        private async Task ExceptionResponseAsync(Exception exception, HttpContext context)
        {
            context.Response.Headers.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var exceptionType = exception.GetType();

            if (exceptionType == typeof(ConditionsNotProvidedException))
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exceptionType == typeof(NotFoundException))
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            if (exceptionType == typeof(AlreadyExistException))
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;

            await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(exception)));
        }
    }
}