namespace Domain
{
    public class EntryVote : BaseEntity
    {
        public VoteType Type { get; set; }
        public Guid UserId { get; set; }
        public Guid EntryId { get; set; }

        public virtual Entry Entry { get; set; }
        public virtual User User { get; set; }
    }
}