using Application.Interfaces.Repository;
using AutoMapper;
using Common.Models.Queries;
using Common.Models.View;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Entry.Entry
{
    public class SingleEntryQueryHandler : GenericHandler<IEntryRepository, SingleEntryQuery, EntryViewModel>
    {
        public SingleEntryQueryHandler(IEntryRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<EntryViewModel> Handle(SingleEntryQuery request, CancellationToken cancellationToken)
        {
            var entry = await base.Repository.AsQueryable()
            .Include(e => e.User)
            .Include(e => e.EntryVotes)
            .FirstOrDefaultAsync(e => e.Url == Uri.EscapeDataString(request.Url));
            var result = new EntryViewModel()
            {
                Content = entry.Content,
                CreatedDate = entry.CreatedDate,
                Subject = entry.Subject,
                Url = entry.Url,
                UserImage = entry.User.Image,
                Username = entry.User.Username,
                UserId = entry.UserId,
                VoteType = Common.Enums.VoteType.None
            };
            if (entry.EntryVotes.Any(e => e.UserId == request.UserId) && request.UserId != Guid.Empty)
                result.VoteType = entry.EntryVotes.FirstOrDefault(e => e.UserId == request.UserId).Type;

            return result;
        }
    }
}