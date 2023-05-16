using Application.Interfaces.Repository;
using AutoMapper;
using Common.Exceptions;
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
            .FirstOrDefaultAsync(e => e.Url == request.Url);
            if (entry == null)
                throw new EntryNotFoundException("Bu url'e ait entry bulunamadı");

            return new EntryViewModel()
            {
                Id = entry.Id,
                Content = entry.Content,
                CreatedDate = entry.CreatedDate,
                Subject = entry.Subject,
                Url = entry.Url,
                UserImage = entry.User.Image,
                Username = entry.User.Username,
                UserId = entry.UserId,
                VoteType = entry.EntryVotes.Any(e => e.UserId == request.UserId) && request.UserId != Guid.Empty ?
                    entry.EntryVotes.First(e => e.UserId == request.UserId).Type :
                    Common.Enums.VoteType.None
            };
        }
    }
}