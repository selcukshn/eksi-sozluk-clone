using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository;

namespace Application.Interfaces.Repository
{
    public class EntryRepository : Repository<Entry>, IEntryRepository
    {
        public EntryRepository(DbContext context) : base(context) { }
    }
}