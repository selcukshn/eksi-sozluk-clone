using Common.Models.Response;

namespace Blazor.Services.Request.Base
{
    public interface IRequestService
    {
        Task<RequestResponse> GetAsync(string address);
    }
}