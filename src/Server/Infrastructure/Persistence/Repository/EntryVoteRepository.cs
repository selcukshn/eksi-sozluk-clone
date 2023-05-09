using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository;

namespace Application.Interfaces.Repository
{
    public class EntryVoteRepository : Repository<EntryVote>, IEntryVoteRepository
    {
        public EntryVoteRepository(DbContext context) : base(context) { }
    }
}