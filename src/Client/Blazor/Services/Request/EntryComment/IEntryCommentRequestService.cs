using Common.Models.Queries.Base;
using Common.Models.Response;

namespace Blazor.Services.Request.EntryComment
{
    public interface IEntryCommentRequestService
    {
        Task<RequestResponse> GetAsync(Guid entryId, PagedQuery query);
    }
}