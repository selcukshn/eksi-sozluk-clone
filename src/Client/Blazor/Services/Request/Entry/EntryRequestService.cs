using System.Net.Http.Json;
using Blazor.Services.Request.Base;
using Common.Models.Command;
using Common.Models.Queries;
using Common.Models.Response;

namespace Blazor.Services.Request.Entry
{
    public class EntryRequestService : RequestService, IEntryRequestService
    {

        public EntryRequestService(HttpClient client) : base(client) { }

        public async Task<RequestResponse> GetAllAsync(int count)
        {
            return await base.GetAsync($"/api/entry?count={count}");
        }

        public async Task<RequestResponse> GetAsync(string url, Guid? userId = null)
        {
            string query = userId != null ? $"?userId={userId}" : "";
            return await base.GetAsync($"/api/entry/{url}{query}");
        }

        public async Task<RequestResponse> GetSidebarEntriesAsync(SidebarEntriesQuery query)
        {
            return await base.GetAsync($"/api/entry/sidebar?count={query.Count}&random={query.Random}");
        }
        public async Task<RequestResponse> GetMainPageEntriesAsync(MainPageEntriesQuery query)
        {
            return await base.GetAsync($"/api/entry/main?count={query.Count}&random={query.Random}");
        }

        public async Task<RequestResponse> CreateAsync(EntryCreateCommand command)
        {
            return await base.PostAsync($"/api/entry", JsonContent.Create(command));
        }

        public async Task<RequestResponse> SearchAsync(string value)
        {
            return await base.GetAsync($"/api/entry/search/{value}");
        }
    }
}