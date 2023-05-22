using Common.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Extensions
{
    public static class MvcBuilderExtension
    {
        public static IMvcBuilder SuppressFluentValidationExceptionModel<T>(this IMvcBuilder builder)
        where T : Response, new()
        {
            builder.ConfigureApiBehaviorOptions(opt =>
            {
                opt.InvalidModelStateResponseFactory = context =>
                {
                    return new BadRequestObjectResult(new T() { Message = context.ModelState.Values.FirstOrDefault()?.Errors.FirstOrDefault()?.ErrorMessage });
                };
            });
            return builder;
        }
        public static IMvcBuilder DisableJsonResultParametersNamingPolicy(this IMvcBuilder builder)
        {
            builder.AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            return builder;
        }
    }
}