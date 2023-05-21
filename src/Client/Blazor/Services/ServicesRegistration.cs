using Blazor.Services.Authentication;
using Blazor.Services.Request.Authentication;
using Blazor.Services.Request.Base;
using Blazor.Services.Request.Entry;
using Blazor.Services.Request.EntryComment;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Services
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection service)
        {
            service.AddTransient<IRequestService, RequestService>();
            service.AddTransient<IEntryRequestService, EntryRequestService>();
            service.AddTransient<IEntryCommentRequestService, EntryCommentRequestService>();
            service.AddTransient<IAuthenticationRequestService, AuthenticationRequestService>();
            service.AddScoped<AuthenticationStateProvider, AuthenticationService>();
            return service;
        }
    }
}