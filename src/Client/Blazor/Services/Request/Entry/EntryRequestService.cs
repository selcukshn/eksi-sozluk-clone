using System.Net.Http.Json;
using Blazor.Services.Request.Base;
using Blazored.LocalStorage;
using Common.Models.Command;
using Common.Models.Queries;
using Common.Models.Response;

namespace Blazor.Services.Request.Entry
{
    public class EntryRequestService : RequestService, IEntryRequestService
    {

        private ILocalStorageService Storage;
        public EntryRequestService(HttpClient client, ILocalStorageService storage) : base(client)
        {
            Storage = storage;
        }

        public async Task<RequestResponse> GetAllAsync(int count)
        {
            return await base.GetAsync($"/api/entry?count={count}");
        }

        public async Task<RequestResponse> GetAsync(string url, Guid? userId = null)
        {
            string query = userId != null ? $"?userId={userId}" : string.Empty;
            return await base.GetAsync($"/api/entry/{url}{query}");
        }

        public async Task<RequestResponse> GetSidebarEntriesAsync(SidebarEntriesQuery query)
        {
            return await base.GetAsync($"/api/entry/sidebar?count={query.Count}&random={query.Random}");
        }
        public async Task<RequestResponse> GetMainPageEntriesAsync(MainPageEntriesQuery query)
        {
            return await base.GetAsync($"/api/entry/main?count={query.Count}&random={query.Random}&userId={query.UserId}");
        }

        public async Task<RequestResponse> CreateAsync(EntryCreateCommand command)
        {
            return await base.PostAsync($"/api/entry", JsonContent.Create(command));
        }

        public async Task<RequestResponse> SearchAsync(string value)
        {
            return await base.GetAsync($"/api/entry/search/{value}");
        }
        public async Task<RequestResponse> VoteAsync(EntryVoteCommand command)
        {
            return await base.PostAsync($"/api/entry/vote", command);
        }
        public async Task<RequestResponse> FavoriteAsync(EntryFavoriteCommand command)
        {
            return await base.PostAsync($"/api/entry/favorite", command);
        }
    }
}