namespace Domain
{
    public class EntryCommentFavorite : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid EntryCommentId { get; set; }

        public virtual EntryComment EntryComment { get; set; }
        public virtual User User { get; set; }
    }
}