using Common.Enums;

namespace Domain
{
    public class EntryCommentVote : BaseEntity
    {
        public VoteType Type { get; set; }
        public Guid UserId { get; set; }
        public Guid EntryCommentId { get; set; }

        public virtual EntryComment EntryComment { get; set; }
        public virtual User User { get; set; }
    }
}