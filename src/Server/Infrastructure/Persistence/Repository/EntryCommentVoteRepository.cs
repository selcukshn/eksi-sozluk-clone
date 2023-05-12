using Domain;
using Persistence.Context;
using Persistence.Repository;

namespace Application.Interfaces.Repository
{
    public class EntryCommentVoteRepository : Repository<EntryCommentFavorite>, IEntryCommentVoteRepository
    {
        public EntryCommentVoteRepository(SozlukCloneContext context) : base(context) { }
    }
}