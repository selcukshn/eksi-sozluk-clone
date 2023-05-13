using Common.Models.View;
using MediatR;

namespace Common.Models.Queries
{
    public class EntryQuery : IRequest<EntryViewModel>
    {
        public string Url { get; set; }
    }
}