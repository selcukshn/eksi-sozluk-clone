using Common.Models.Page;
using Common.Models.Queries.Base;
using Common.Models.View;
using MediatR;

namespace Common.Models.Queries
{
    public class EntryCommentsQuery : PagedQuery, IRequest<PagedViewModel<EntryCommentsViewModel>>
    {
        public Guid EntryId { get; set; }
    }
}