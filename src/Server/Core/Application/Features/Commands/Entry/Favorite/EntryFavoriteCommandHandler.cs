using Application.Interfaces.Repository;
using AutoMapper;
using Common.Models.Command;

namespace Application.Features.Commands.Entry.Favorite
{
    public class EntryFavoriteCommandHandler : GenericHandler<IEntryFavoriteRepository, EntryFavoriteCommand, bool>
    {
        public EntryFavoriteCommandHandler(IEntryFavoriteRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<bool> Handle(EntryFavoriteCommand request, CancellationToken cancellationToken)
        {
            var entity = await base.Repository.GetOneAsync(e => e.EntryId == request.EntryId && e.UserId == request.UserId);
            if (entity == null)
                return await base.Repository.CreateAsync(base.Mapper.Map<Domain.EntryFavorite>(request)) > 0;
            else
                return await base.Repository.DeleteAsync(entity) > 0;
        }
    }
}