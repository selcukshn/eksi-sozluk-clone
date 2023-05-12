using Domain;
using Persistence.Context;
using Persistence.Repository;

namespace Application.Interfaces.Repository
{
    public class EntryVoteRepository : Repository<EntryVote>, IEntryVoteRepository
    {
        public EntryVoteRepository(SozlukCloneContext context) : base(context) { }
    }
}