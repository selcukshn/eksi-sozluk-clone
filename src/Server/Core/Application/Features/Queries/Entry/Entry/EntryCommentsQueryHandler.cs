using Application.Interfaces.Repository;
using AutoMapper;
using Common.Extensions;
using Common.Models.Page;
using Common.Models.Queries;
using Common.Models.View;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Entry.Entry
{
    public class EntryCommentsQueryHandler : GenericHandler<IEntryCommentRepository, EntryCommentsQuery, PagedViewModel<EntryCommentsViewModel>>
    {
        public EntryCommentsQueryHandler(IEntryCommentRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<PagedViewModel<EntryCommentsViewModel>> Handle(EntryCommentsQuery request, CancellationToken cancellationToken)
        {
            var entry = base.Repository.AsQueryable()
            .Include(e => e.User)
            .Include(e => e.EntryCommentVotes)
            .Where(e => e.EntryId == request.EntryId);

            var mapEntry = entry.Select(e => new EntryCommentsViewModel()
            {
                Id = e.Id,
                Content = e.Content,
                CreatedDate = e.CreatedDate,
                UserImage = e.User.Image,
                Username = e.User.Username,
                VoteType = e.EntryCommentVotes.Any(e => e.UserId == request.UserId) && request.UserId != Guid.Empty ?
                    e.EntryCommentVotes.First(e => e.UserId == request.UserId).Type :
                    Common.Enums.VoteType.None
            });

            var viewModel = await mapEntry.ToPagedAsync(request.Take, request.Current);
            return viewModel;
        }
    }
}