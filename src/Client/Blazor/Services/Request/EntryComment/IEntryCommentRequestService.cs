using Common.Models.Command;
using Common.Models.Queries.Base;
using Common.Models.Response;

namespace Blazor.Services.Request.EntryComment
{
    public interface IEntryCommentRequestService
    {
        Task<RequestResponse> GetAsync(Guid entryId, PagedQuery query);
        Task<RequestResponse> VoteAsync(EntryCommentVoteCommand command);
        Task<RequestResponse> FavoriteAsync(EntryCommentFavoriteCommand command);
    }
}