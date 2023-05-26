using Common.Models.Queries.Base;
using Common.Models.View;
using MediatR;

namespace Common.Models.Queries
{
    public class MainPageEntriesQuery : MainSideEntriesQuery, IRequest<List<MainPageViewModel>>
    {
        private Guid? _userId;
        public Guid? UserId
        {
            get => _userId;
            set
            {
                if (Guid.TryParse(value.ToString(), out Guid id))
                    _userId = id;
                else
                    _userId = Guid.Empty;
            }
        }
    }
}