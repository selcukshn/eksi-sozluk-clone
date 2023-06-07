using Common.Enums;
using MediatR;

namespace Common.Models.Command
{
    public class EntryCommentVoteCommand : IRequest<bool>
    {
        public VoteType Type { get; set; }
        public Guid UserId { get; set; }
        public Guid EntryCommentId { get; set; }
        public EntryCommentVoteCommand() { }
        public EntryCommentVoteCommand(VoteType type, Guid userId, Guid entryCommentId)
        {
            Type = type;
            UserId = userId;
            EntryCommentId = entryCommentId;
        }
    }
}