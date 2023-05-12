namespace Common.Models.View
{
    public class SidebarViewModel
    {
        public Guid Id { get; set; }
        public string? Url { get; set; }
        public string? Subject { get; set; }
        public int CommentCount { get; set; }
    }
}