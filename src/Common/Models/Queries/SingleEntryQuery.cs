using Common.Models.Queries.Base;
using Common.Models.View;
using MediatR;

namespace Common.Models.Queries
{
    public class SingleEntryQuery : EntryQuery, IRequest<EntryViewModel>
    {
        public Guid UserId { get; set; }
    }
}