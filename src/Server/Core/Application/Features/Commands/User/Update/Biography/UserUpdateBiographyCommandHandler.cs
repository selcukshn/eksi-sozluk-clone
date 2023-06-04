using Application.Interfaces.Repository;
using AutoMapper;
using Common.Exceptions;
using Common.Models.Command;

namespace Application.Features.Commands.User.Update.Biography
{
    public class UserUpdateBiographyCommandHandler : GenericHandler<IUserRepository, UserUpdateBiographyCommand, bool>
    {
        public UserUpdateBiographyCommandHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<bool> Handle(UserUpdateBiographyCommand request, CancellationToken cancellationToken)
        {
            var user = await base.Repository.GetOneAsync(e => e.Id == request.UserId);
            if (user is null)
                throw new UserNotFoundException("Kullanıcı bulunamadı");
            user.Biography = request.Biography;
            return 0 > await base.Repository.UpdateAsync(user);
        }
    }
}