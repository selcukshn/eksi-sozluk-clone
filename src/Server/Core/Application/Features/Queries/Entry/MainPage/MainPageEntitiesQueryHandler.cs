using Application.Interfaces.Repository;
using AutoMapper;
using Common.Models.Queries;
using Common.Models.View;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Entry.MainPage
{
    public class MainPageEntitiesQueryHandler : GenericHandler<IEntryRepository, MainPageEntriesQuery, List<MainPageViewModel>>
    {
        public MainPageEntitiesQueryHandler(IEntryRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<List<MainPageViewModel>> Handle(MainPageEntriesQuery request, CancellationToken cancellationToken)
        {
            var entities = base.Repository.AsQueryable();
            if (request.Random)
                entities = entities.OrderBy(e => Guid.NewGuid());
            else
                entities = entities.OrderBy(e => e.CreatedDate);
            return await entities.Include(e => e.User).Include(e => e.EntryVotes).Include(e => e.EntryFavorites)
            .Select(e => new MainPageViewModel()
            {
                Content = e.Content,
                CreatedDate = e.CreatedDate,
                Id = e.Id,
                Subject = e.Subject,
                Url = e.Url,
                UserId = e.UserId,
                Username = e.User.Username,
                IsFavorite = e.EntryFavorites.Any(b => b.UserId == request.UserId && b.EntryId == e.Id) && request.UserId != Guid.Empty,
                VoteType = e.EntryVotes.Any(b => b.UserId == request.UserId) && request.UserId != Guid.Empty ?
                 e.EntryVotes.First(b => b.UserId == request.UserId).Type : Common.Enums.VoteType.None
            }).Take(request.Count).ToListAsync();
        }
    }

}