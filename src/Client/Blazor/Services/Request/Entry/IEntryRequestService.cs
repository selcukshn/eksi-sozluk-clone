using Common.Models.Command;
using Common.Models.Queries;
using Common.Models.Response;

namespace Blazor.Services.Request.Entry
{
    public interface IEntryRequestService
    {
        Task<RequestResponse> CreateAsync(EntryCreateCommand command);
        Task<RequestResponse> GetAsync(string url, Guid? userId = null);
        Task<RequestResponse> GetAllAsync(int count);
        Task<RequestResponse> GetMainPageEntriesAsync(MainPageEntriesQuery query);
        Task<RequestResponse> GetSidebarEntriesAsync(SidebarEntriesQuery query);
        Task<RequestResponse> SearchAsync(string value);
    }
}