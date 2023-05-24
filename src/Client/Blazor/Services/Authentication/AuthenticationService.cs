using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blazor.Extensions.Blazored.LocalStorage;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Services.Authentication
{
    public class AuthenticationService : AuthenticationStateProvider
    {
        private readonly ILocalStorageService LocalStorage;
        private AuthenticationState AnonymousUser;

        public AuthenticationService(ILocalStorageService localStorage)
        {
            LocalStorage = localStorage;
            AnonymousUser = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await LocalStorage.GetJWTAsync();
            if (string.IsNullOrEmpty(token))
                return AnonymousUser;
            return CreateAuthUser(token);
        }

        public void NotifyLogin(string? token)
        {
            if (!string.IsNullOrEmpty(token))
                NotifyAuthenticationStateChanged(Task.FromResult(CreateAuthUser(token)));
        }
        public void NotifyLogout()
        {
            NotifyAuthenticationStateChanged(Task.FromResult(AnonymousUser));
        }
        private AuthenticationState CreateAuthUser(string token)
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(DecodeJWT(token).Claims, "jwt")));
        }
        private JwtSecurityToken DecodeJWT(string token) => new JwtSecurityTokenHandler().ReadJwtToken(token);
    }
}