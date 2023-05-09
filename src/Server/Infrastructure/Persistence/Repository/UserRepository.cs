using Domain;
using Persistence.Context;
using Persistence.Repository;

namespace Application.Interfaces.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SozlukCloneContext context) : base(context) { }
    }
}