using Common.Models.View;
using MediatR;

namespace Common.Models.Queries
{
    public class AllUserQuery : IRequest<List<UserViewModel>>
    {
        public Guid? Id { get; set; }
        public int Count { get; set; } = 100;
    }
}