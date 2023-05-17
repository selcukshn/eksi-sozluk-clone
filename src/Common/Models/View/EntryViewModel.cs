using Common.Enums;

namespace Common.Models.View
{
    public class EntryViewModel
    {
        public Guid Id { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public string? Url { get; set; }
        public DateTime CreatedDate { get; set; }
        public VoteType VoteType { get; set; }
        public Guid UserId { get; set; }
        public string? Username { get; set; }
        public string? UserImage { get; set; }
    }
}