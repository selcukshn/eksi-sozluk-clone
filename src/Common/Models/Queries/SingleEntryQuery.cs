using Common.Models.Page;
using Common.Models.Queries.Base;
using Common.Models.View;
using MediatR;

namespace Common.Models.Queries
{
    public class SingleEntryQuery : PagedQuery, IRequest<EntryViewModel>
    {
        public string? Url { get; set; }
    }
}