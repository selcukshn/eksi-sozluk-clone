using Blazor.Services.Request.Base;
using Common.Models.Queries;
using Common.Models.Response;

namespace Blazor.Services.Request.User
{
    public class UserRequestService : RequestService, IUserRequestService
    {
        public UserRequestService(HttpClient client) : base(client) { }

        public async Task<RequestResponse> GetUserAsync(string username)
        {
            return await base.PostAsync("/api/user", new UserQuery() { Username = username });
        }
        public async Task<RequestResponse> GetUserAsync(Guid userId)
        {
            return await base.PostAsync("/api/user", new UserQuery() { UserId = userId });
        }
    }
}