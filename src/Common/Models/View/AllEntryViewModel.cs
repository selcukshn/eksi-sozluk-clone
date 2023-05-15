namespace Common.Models.View
{
    public class AllEntryViewModel
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}