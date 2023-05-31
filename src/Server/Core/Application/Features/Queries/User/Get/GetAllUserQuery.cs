using Application.Interfaces.Repository;
using AutoMapper;
using Common.Models.Queries;
using Common.Models.View;

namespace Application.Features.Queries.User.Get
{
    public class GetAllUserQuery : GenericHandler<IUserRepository, AllUserQuery, List<UserViewModel>>
    {
        public GetAllUserQuery(IUserRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<List<UserViewModel>> Handle(AllUserQuery request, CancellationToken cancellationToken)
        {
            var entities = await base.Repository.GetAllAsync(request.Count);
            return base.Mapper.Map<List<UserViewModel>>(entities);
        }
    }
}