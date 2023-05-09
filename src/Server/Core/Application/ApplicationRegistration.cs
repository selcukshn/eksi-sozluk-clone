using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection service)
        {
            var assembly = Assembly.GetExecutingAssembly();
            service.AddAutoMapper(assembly);
            service.AddMediatR(assembly);
            service.AddValidatorsFromAssembly(assembly);

            return service;
        }
    }
}