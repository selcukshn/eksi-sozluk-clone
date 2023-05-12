using Domain;
using Persistence.Context;
using Persistence.Repository;

namespace Application.Interfaces.Repository
{
    public class EntryRepository : Repository<Entry>, IEntryRepository
    {
        public EntryRepository(SozlukCloneContext context) : base(context) { }
    }
}