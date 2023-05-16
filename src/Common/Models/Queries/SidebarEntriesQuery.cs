using Common.Models.Queries.Base;
using Common.Models.View;
using MediatR;

namespace Common.Models.Queries
{
    public class SidebarEntriesQuery : MainSideEntriesQuery, IRequest<List<SidebarViewModel>>
    {
    }
}