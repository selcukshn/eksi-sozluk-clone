using Application.Interfaces.Repository;
using AutoMapper;
using Common.Models.Command;

namespace Application.Features.Commands.EntryComments.Vote
{
    public class EntryCommentsVoteCommandHandler : GenericHandler<IEntryCommentVoteRepository, EntryCommentVoteCommand, bool>
    {
        public EntryCommentsVoteCommandHandler(IEntryCommentVoteRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<bool> Handle(EntryCommentVoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await base.Repository.GetOneAsync(e => e.EntryCommentId == request.EntryCommentId && e.UserId == request.UserId);
            if (entity == null)
                return await base.Repository.CreateAsync(Mapper.Map<Domain.EntryCommentVote>(request)) > 0;
            else
            {
                entity.Type = request.Type;
                return await base.Repository.UpdateAsync(entity) > 0;
            }

        }
    }
}