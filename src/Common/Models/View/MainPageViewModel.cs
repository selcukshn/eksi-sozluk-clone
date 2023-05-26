using Common.Enums;

namespace Common.Models.View
{
    public class MainPageViewModel
    {
        public Guid Id { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public string? Url { get; set; }
        public Guid UserId { get; set; }
        public VoteType VoteType { get; set; }
        public string? Username { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}