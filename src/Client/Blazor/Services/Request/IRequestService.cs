using Common.Models.Response;

namespace Blazor.Services.Request
{
    public interface IRequestService
    {
        Task<Response> GetAsync(string address);
    }
}