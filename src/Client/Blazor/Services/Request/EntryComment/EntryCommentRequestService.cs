using Blazor.Services.Authentication;
using Blazor.Services.Request.Base;
using Common.Models.Command;
using Common.Models.Queries.Base;
using Common.Models.Response;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Services.Request.EntryComment
{
    public class EntryCommentRequestService : RequestService, IEntryCommentRequestService
    {
        private readonly AuthenticationService authenticationService;
        public EntryCommentRequestService(HttpClient client, AuthenticationStateProvider authenticationService) : base(client)
        {
            this.authenticationService = (AuthenticationService)authenticationService;
        }

        public async Task<RequestResponse> GetAsync(Guid entryId, PagedQuery query)
        {
            return await base.GetAsync($"/api/entrycomments/{entryId}{query.ToString()}");
        }
        public async Task<RequestResponse> VoteAsync(EntryCommentVoteCommand command)
        {
            return await base.PostAsync($"/api/entrycomments/vote", command);
        }
        public async Task<RequestResponse> FavoriteAsync(EntryCommentFavoriteCommand command)
        {
            return await base.PostAsync($"/api/entrycomments/favorite", command);
        }
    }
}