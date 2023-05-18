using System.Net;
using Common.Exceptions.Base;
using Common.Models.Response;
using Microsoft.AspNetCore.Diagnostics;

namespace Api.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder ExceptionHandling(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>();
                    if (exception != null)
                        await ExceptionResponseAsync(exception.Error, context);
                    return;
                });
            });
            return app;
        }
        private static async Task ExceptionResponseAsync(Exception exception, HttpContext context)
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

            await context.Response.WriteAsJsonAsync(new ExceptionResponse(exception.Message));
        }
    }
}