namespace Domain
{
    public class EntryFavorite : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid EntryId { get; set; }

        public virtual Entry Entry { get; set; }
        public virtual User User { get; set; }
    }
}