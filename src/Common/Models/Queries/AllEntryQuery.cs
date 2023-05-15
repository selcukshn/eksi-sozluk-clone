using Common.Models.Queries.Base;
using Common.Models.View;
using MediatR;

namespace Common.Models.Queries
{
    public class AllEntryQuery : EntryQuery, IRequest<List<AllEntryViewModel>>
    {

    }
}