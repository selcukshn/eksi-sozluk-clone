using Domain;
using Persistence.Context;
using Persistence.Repository;

namespace Application.Interfaces.Repository
{
    public class EntryCommentRepository : Repository<EntryComment>, IEntryCommentRepository
    {
        public EntryCommentRepository(SozlukCloneContext context) : base(context) { }
    }
}