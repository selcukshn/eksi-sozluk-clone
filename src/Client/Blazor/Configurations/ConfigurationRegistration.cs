using Blazor.Configurations.Http;

namespace Blazor.Configurations
{
    public static class ConfigurationRegistration
    {
        public static IServiceCollection AddConfigurationsDependencies(this IServiceCollection service)
        {
            service.AddScoped<AuthenticationHandler>();
            return service;
        }
    }
}