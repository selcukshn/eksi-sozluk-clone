using Common.Enums;
using MediatR;

namespace Common.Models.Command
{
    public class EntryVoteCommand : IRequest<bool>
    {
        public VoteType Type { get; set; }
        public Guid UserId { get; set; }
        public Guid EntryId { get; set; }
        public EntryVoteCommand() { }
        public EntryVoteCommand(VoteType type, Guid userId, Guid entryId)
        {
            Type = type;
            UserId = userId;
            EntryId = entryId;
        }
    }
}