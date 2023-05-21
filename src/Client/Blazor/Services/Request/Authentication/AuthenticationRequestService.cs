using System.Net.Http.Headers;
using Blazor.Extensions.LocalStorage;
using Blazor.Services.Authentication;
using Blazor.Services.Request.Base;
using Blazored.LocalStorage;
using Common.Models.Command;
using Common.Models.Response;
using Common.Models.View;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Services.Request.Authentication
{
    public class AuthenticationRequestService : RequestService, IAuthenticationRequestService
    {
        private readonly AuthenticationService AuthenticationState;
        private readonly ILocalStorageService LocalStorage;
        public AuthenticationRequestService(HttpClient client, AuthenticationStateProvider authenticationState, ILocalStorageService localStorage) : base(client)
        {
            AuthenticationState = (authenticationState as AuthenticationService);
            LocalStorage = localStorage;
        }
        public async Task<RequestResponse> RegisterAsync(UserCreateCommand command)
        {
            return await base.PostAsync("/api/user/register", command);
        }
        public async Task<RequestResponse> LoginAsync(UserLoginCommand command)
        {
            var response = await base.PostAsync("/api/user/login", command);
            if (response.IsSuccess)
            {
                var result = await response.ResultAsync<UserLoginViewModel>();
                if (!string.IsNullOrEmpty(result?.Token))
                {
                    await LocalStorage.SetJWTAsync(result.Token);
                    AuthenticationState.NotifyLogin(result.Token);
                    base.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.Token);
                }
            }
            return response;

        }
        public async Task LogoutAsync()
        {
            await LocalStorage.RemoveJWTAsync();
            AuthenticationState.NotifyLogout();
            base.Client.DefaultRequestHeaders.Authorization = null;
        }
    }
}