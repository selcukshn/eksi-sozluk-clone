using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Models.Queries;
using Common.Models.View;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Entry.Sidebar
{
    public class SidebarEntitiesQueryHandler : GenericHandler<IEntryRepository, SidebarEntitiesQuery, List<SidebarViewModel>>
    {
        public SidebarEntitiesQueryHandler(IEntryRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<List<SidebarViewModel>> Handle(SidebarEntitiesQuery request, CancellationToken cancellationToken)
        {
            var entities = base.Repository.AsQueryable();
            if (request.Random)
                entities = entities.OrderBy(e => Guid.NewGuid());
            else
                entities = entities.OrderBy(e => e.CreatedDate);

            return await entities.Include(e => e.EntryComments)
            .Take(request.Count)
            .ProjectTo<SidebarViewModel>(base.Mapper.ConfigurationProvider)
            .ToListAsync();
        }
    }
}