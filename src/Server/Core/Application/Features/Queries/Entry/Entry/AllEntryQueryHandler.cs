using Application.Interfaces.Repository;
using AutoMapper;
using Common.Models.Queries;
using Common.Models.View;

namespace Application.Features.Queries.Entry.Entry
{
    public class AllEntryQueryHandler : GenericHandler<IEntryRepository, AllEntryQuery, List<AllEntryViewModel>>
    {
        public AllEntryQueryHandler(IEntryRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<List<AllEntryViewModel>> Handle(AllEntryQuery request, CancellationToken cancellationToken)
        {
            var entries = await base.Repository.GetAllAsync(request.Count);
            return base.Mapper.Map<List<AllEntryViewModel>>(entries);
        }
    }
}