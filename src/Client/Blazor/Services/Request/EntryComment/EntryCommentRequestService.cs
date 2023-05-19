using Blazor.Services.Request.Base;
using Common.Models.Queries.Base;
using Common.Models.Response;

namespace Blazor.Services.Request.EntryComment
{
    public class EntryCommentRequestService : RequestService, IEntryCommentRequestService
    {
        public EntryCommentRequestService(HttpClient client) : base(client) { }

        public async Task<RequestResponse> GetAsync(Guid entryId, PagedQuery query)
        {
            return await base.GetAsync($"/api/entrycomments/{entryId}{query.ToString()}");
        }
    }
}