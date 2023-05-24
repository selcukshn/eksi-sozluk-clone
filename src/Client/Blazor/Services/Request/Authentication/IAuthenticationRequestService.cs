using Common.Models.Command;
using Common.Models.Response;

namespace Blazor.Services.Request.Authentication
{
    public interface IAuthenticationRequestService
    {
        Task<RequestResponse> LoginAsync(UserLoginCommand command);
        Task<RequestResponse> RegisterAsync(UserCreateCommand command);
        Task LogoutAsync();
    }
}