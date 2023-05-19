using Blazor.Services.Request.Base;
using Blazor.Services.Request.Entry;
using Blazor.Services.Request.EntryComment;

namespace Blazor.Services
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection service)
        {
            service.AddTransient<IRequestService, RequestService>();
            service.AddTransient<IEntryRequestService, EntryRequestService>();
            service.AddTransient<IEntryCommentRequestService, EntryCommentRequestService>();
            return service;
        }
    }
}