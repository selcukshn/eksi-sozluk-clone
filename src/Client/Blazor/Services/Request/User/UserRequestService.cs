using Blazor.Extensions;
using Blazor.Services.Authentication;
using Blazor.Services.Request.Base;
using Common.Models.Command;
using Common.Models.Queries;
using Common.Models.Response;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Services.Request.User
{
    public class UserRequestService : RequestService, IUserRequestService
    {
        private readonly AuthenticationService authenticationService;
        private readonly Guid LoggedUserId;
        public UserRequestService(HttpClient client, AuthenticationStateProvider authenticationStateProvider) : base(client)
        {
            authenticationService = (AuthenticationService)authenticationStateProvider;
        }

        public async Task<RequestResponse> GetUserAsync(string username)
        {
            return await base.PostAsync("/api/user", new UserQuery() { Username = username });
        }
        public async Task<RequestResponse> GetUserAsync(Guid userId)
        {
            return await base.PostAsync("/api/user", new UserQuery() { UserId = userId });
        }
        public async Task<RequestResponse> UpdateUserBiographyAsync(string biography)
        {
            return await base.PostAsync("/api/user/update/biography", new UserUpdateBiographyCommand() { Biography = biography, UserId = await authenticationService.GetUserIdAsync() });
        }
        public async Task<RequestResponse> UpdateUserImageAsync(string image)
        {
            return await base.PostAsync("/api/user/update/image", new UserUpdateImageCommand() { Image = image, UserId = await authenticationService.GetUserIdAsync() });
        }
    }
}