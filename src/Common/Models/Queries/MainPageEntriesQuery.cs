using Common.Models.Queries.Base;
using Common.Models.View;
using MediatR;

namespace Common.Models.Queries
{
    public class MainPageEntriesQuery : MainSideEntriesQuery, IRequest<List<MainPageViewModel>>
    {
    }
}