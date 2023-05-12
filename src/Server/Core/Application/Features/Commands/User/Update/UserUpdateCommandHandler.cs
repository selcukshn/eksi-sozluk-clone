using Application.Interfaces.Repository;
using AutoMapper;
using Common.Exceptions;
using Common.Models.Command;

namespace Application.Features.Commands.User.Update
{
    public class UserUpdateCommandHandler : GenericHandler<IUserRepository, UserUpdateCommand, Guid>
    {
        public UserUpdateCommandHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<Guid> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = await base.Repository.GetOneAsync(request.Id);
            if (user == null)
                throw new UserNotFoundException("Kullanıcı bulunamadı.");

            Mapper.Map(source: request, destination: user);
            await base.Repository.UpdateAsync(user);
            return user.Id;
        }
    }
}