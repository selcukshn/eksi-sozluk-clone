using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository;

namespace Application.Interfaces.Repository
{
    public class EntryCommentRepository : Repository<EntryComment>, IEntryCommentRepository
    {
        public EntryCommentRepository(DbContext context) : base(context) { }
    }
}