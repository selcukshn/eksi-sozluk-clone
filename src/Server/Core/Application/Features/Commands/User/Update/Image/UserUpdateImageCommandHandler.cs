using Application.Interfaces.Repository;
using AutoMapper;
using Common.Exceptions;
using Common.Models.Command;

namespace Application.Features.Commands.User.Update.Image
{
    public class UserUpdateImageCommandHandler : GenericHandler<IUserRepository, UserUpdateImageCommand, bool>
    {
        public UserUpdateImageCommandHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<bool> Handle(UserUpdateImageCommand request, CancellationToken cancellationToken)
        {
            var user = await base.Repository.GetOneAsync(e => e.Id == request.UserId);
            if (user is null)
                throw new UserNotFoundException("Kullanıcı bulunamadı");
            user.Image = request.Image;
            return 0 > await base.Repository.UpdateAsync(user);
        }
    }
}