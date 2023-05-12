using Common.Models.View;
using MediatR;

namespace Common.Models.Queries
{
    public class SidebarEntitiesQuery : IRequest<List<SidebarViewModel>>
    {
        public bool Random { get; set; }
        public int Count { get; set; } = 30;
    }
}