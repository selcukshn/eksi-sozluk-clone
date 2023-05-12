using Domain;
using Persistence.Context;
using Persistence.Repository;

namespace Application.Interfaces.Repository
{
    public class EntryFavoriteRepository : Repository<EntryFavorite>, IEntryFavoriteRepository
    {
        public EntryFavoriteRepository(SozlukCloneContext context) : base(context) { }
    }
}