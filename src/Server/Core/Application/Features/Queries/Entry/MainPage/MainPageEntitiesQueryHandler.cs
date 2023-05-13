using Application.Interfaces.Repository;
using AutoMapper;
using Common.Models.Queries;
using Common.Models.View;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Entry.MainPage
{
    public class MainPageEntitiesQueryHandler : GenericHandler<IEntryRepository, MainPageEntitiesQuery, List<MainPageViewModel>>
    {
        public MainPageEntitiesQueryHandler(IEntryRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<List<MainPageViewModel>> Handle(MainPageEntitiesQuery request, CancellationToken cancellationToken)
        {
            var entities = base.Repository.AsQueryable();
            if (request.Random)
                entities = entities.OrderBy(e => Guid.NewGuid());
            else
                entities = entities.OrderBy(e => e.CreatedDate);

            return base.Mapper.Map<List<MainPageViewModel>>(await entities.Take(request.Count).ToListAsync());
        }
    }
}