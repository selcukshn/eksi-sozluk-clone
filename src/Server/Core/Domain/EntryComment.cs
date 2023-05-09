namespace Domain
{
    public class EntryComment : BaseEntity
    {
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
        public Guid EntryId { get; set; }

        public virtual User User { get; set; }
        public virtual Entry Entry { get; set; }
        public virtual ICollection<EntryCommentFavorite> EntryCommentFavorites { get; set; }
        public virtual ICollection<EntryCommentVote> EntryCommentVotes { get; set; }
    }
}