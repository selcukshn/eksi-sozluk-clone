using Application.Interfaces.Repository;
using AutoMapper;
using Common.Exceptions;
using Common.Models.Queries;
using Common.Models.View;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.User.Get
{
    public class UserQueryHandler : GenericHandler<IUserRepository, UserQuery, UserViewModel>
    {
        public UserQueryHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<UserViewModel> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            var user = await base.Repository.AsQueryable()
            .Include(e => e.Entries)
            .FirstOrDefaultAsync(e => e.Id == request.UserId || e.Username == request.Username);
            if (user == null)
                throw new UserNotFoundException("böyle bir kullanıcı yok");
            return base.Mapper.Map<UserViewModel>(user);
        }
    }
}