using Common.Models.View;
using MediatR;

namespace Common.Models.Queries
{
    public class EntryCommentsQuery : IRequest<List<EntryCommentsViewModel>>
    {
        public Guid EntryId { get; set; }
        public Guid UserId { get; set; }
    }
}