using Common.Models.Response;

namespace Blazor.Services.Request
{
    public interface IRequestService
    {
        Task<RequestResponse> GetAsync(string address);
    }
}