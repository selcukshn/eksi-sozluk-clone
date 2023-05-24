using System.Net.Http.Headers;
using Blazor.Extensions.Blazored.LocalStorage;
using Blazored.LocalStorage;

namespace Blazor.Configurations.Http
{
    public class AuthenticationHandler : DelegatingHandler
    {
        private ILocalStorageService Storage { get; set; }
        public AuthenticationHandler(ILocalStorageService storage)
        {
            Storage = storage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (await Storage.HaveTokenAsync())
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await Storage.GetJWTAsync());
            return await base.SendAsync(request, cancellationToken);
        }
    }
}