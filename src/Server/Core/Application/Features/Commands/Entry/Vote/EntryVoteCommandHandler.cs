using Application.Interfaces.Repository;
using AutoMapper;
using Common.Infrastructure.RabbitMQ;
using Common.Models.Command;

namespace Application.Features.Commands.Entry.Vote
{
    public class EntryVoteCommandHandler : GenericHandler<IEntryVoteRepository, EntryVoteCommand, bool>
    {
        public EntryVoteCommandHandler(IEntryVoteRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<bool> Handle(EntryVoteCommand request, CancellationToken cancellationToken)
        {
            new QueuePublisher(QueueConstants.VoteExchange, QueueConstants.CreateEntryVoteQueue, QueueConstants.CreateEntryVoteQueue)
            .AutoDeclare()
            .Publish(request);
            // var entity = await base.Repository.GetOneAsync(e => e.EntryId == request.EntryId && e.UserId == request.UserId);
            // if (entity == null)
            //     return await base.Repository.CreateAsync(Mapper.Map<Domain.EntryVote>(request)) > 0;
            // else
            // {
            //     entity.Type = request.Type;
            //     return await base.Repository.UpdateAsync(entity) > 0;
            // }
            return await Task.FromResult(true);
        }
    }
}