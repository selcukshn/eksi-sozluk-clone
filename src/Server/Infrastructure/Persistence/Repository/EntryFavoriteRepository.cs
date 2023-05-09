using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository;

namespace Application.Interfaces.Repository
{
    public class EntryFavoriteRepository : Repository<EntryFavorite>, IEntryFavoriteRepository
    {
        public EntryFavoriteRepository(DbContext context) : base(context) { }
    }
}