using MediatR;

namespace Common.Models.Command
{
    public class EntryCommentFavoriteCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid EntryCommentId { get; set; }
        public EntryCommentFavoriteCommand(Guid userId, Guid entryCommentId)
        {
            UserId = userId;
            EntryCommentId = entryCommentId;
        }
    }
}