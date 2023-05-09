using Application.Interfaces.Repository;
using AutoMapper;
using Common.Exceptions;
using Common.Helpers;
using Common.Models.Command;

namespace Application.Features.Commands.User.Create
{
    public class UserCreateCommandHandler : GenericRequestHandler<IUserRepository, UserCreateCommand, Guid>
    {
        public UserCreateCommandHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper) { }
        public override async Task<Guid> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = await base.Repository.GetOneAsync(e => e.Email == request.Email || e.Username == request.Username);
            if (user != null)
            {
                if (user.Email == request.Email)
                    throw new UserEmailAlreadyExist("Bu e-posta adresi ile daha önce kayıt olunmuş.");
                if (user.Username == request.Username)
                    throw new UserUsernameAlreadyExist("Bu kullanıcı adı daha önce kullanılmış.");
            }
            request.Password = HashHelper.GeneratePassword(request.Password);
            var newUser = base.Mapper.Map<Domain.User>(request);
            await base.Repository.CreateAsync(newUser);
            return newUser.Id;
        }
    }
}