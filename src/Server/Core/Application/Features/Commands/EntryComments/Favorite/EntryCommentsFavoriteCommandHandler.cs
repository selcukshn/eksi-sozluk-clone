using Application.Interfaces.Repository;
using AutoMapper;
using Common.Models.Command;

namespace Application.Features.Commands.EntryComments.Favorite
{
    public class EntryCommentsFavoriteCommandHandler : GenericHandler<IEntryCommentFavoriteRepository, EntryCommentFavoriteCommand, bool>
    {
        public EntryCommentsFavoriteCommandHandler(IEntryCommentFavoriteRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<bool> Handle(EntryCommentFavoriteCommand request, CancellationToken cancellationToken)
        {
            var entity = await base.Repository.GetOneAsync(e => e.EntryCommentId == request.EntryCommentId && e.UserId == request.UserId);
            if (entity == null)
                return await base.Repository.CreateAsync(base.Mapper.Map<Domain.EntryCommentFavorite>(request)) > 0;
            else
                return await base.Repository.DeleteAsync(entity) > 0;
        }
    }
}