using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Extensions
{
    public static class AuthenticationStateProviderExtension
    {
        public static async Task<bool> HaveUser(this AuthenticationStateProvider provider)
        {
            var state = await provider.GetAuthenticationStateAsync();
            return state.User.Claims.Any();
        }
        public static async Task<Guid> GetUserIdAsync(this AuthenticationStateProvider provider)
        {
            var state = await provider.GetAuthenticationStateAsync();
            var userId = state.User.FindFirst("Id")?.Value;
            return string.IsNullOrEmpty(userId) ? Guid.Empty : new Guid(userId);
        }

    }
}