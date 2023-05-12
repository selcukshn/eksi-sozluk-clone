using MediatR;

namespace Common.Models.Command
{
    public class EntryCreateCommand : IRequest<Guid>
    {

        public string Subject { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public Guid UserId { get; set; }
        public EntryCreateCommand(string subject, Guid userId, string content, string url)
        {
            Subject = subject;
            UserId = userId;
            Content = content;
            Url = url;
        }
    }
}