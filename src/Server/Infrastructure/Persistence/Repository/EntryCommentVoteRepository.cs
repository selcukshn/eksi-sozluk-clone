using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository;

namespace Application.Interfaces.Repository
{
    public class EntryCommentVoteRepository : Repository<EntryCommentFavorite>, IEntryCommentVoteRepository
    {
        public EntryCommentVoteRepository(DbContext context) : base(context) { }
    }
}