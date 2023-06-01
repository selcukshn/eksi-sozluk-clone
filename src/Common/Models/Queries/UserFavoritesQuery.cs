using Common.Models.Queries.Base;
using Common.Models.View;
using MediatR;

namespace Common.Models.Queries
{
    public class UserFavoritesQuery : EntryQuery, IRequest<IEnumerable<EntryViewModel>>
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
        private int _skip = 0;
        public int Skip
        {
            get => _skip;
            set
            {
                if (int.TryParse(value.ToString(), out int skip))
                {
                    if (skip > 0)
                        _skip = skip;
                }
            }
        }
    }
}