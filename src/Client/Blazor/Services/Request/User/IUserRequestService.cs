using Common.Models.Response;

namespace Blazor.Services.Request.User
{
    public interface IUserRequestService
    {
        Task<RequestResponse> GetUserAsync(string username);
        Task<RequestResponse> GetUserAsync(Guid userId);
        Task<RequestResponse> UpdateUserBiographyAsync(string biography);
        Task<RequestResponse> UpdateUserImageAsync(string image);
    }
}