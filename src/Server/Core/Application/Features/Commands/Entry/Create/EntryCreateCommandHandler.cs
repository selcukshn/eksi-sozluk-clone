using Application.Interfaces.Repository;
using AutoMapper;
using Common.Exceptions;
using Common.Helpers;
using Common.Models.Command;

namespace Application.Features.Commands.Entry.Create
{
    public class EntryCreateCommandHandler : GenericHandler<IEntryRepository, EntryCreateCommand, Guid>
    {
        private readonly IUserRepository UserRepository;
        public EntryCreateCommandHandler(IEntryRepository repository, IMapper mapper, IUserRepository userRepository) : base(repository, mapper)
        {
            UserRepository = userRepository;
        }

        public override async Task<Guid> Handle(EntryCreateCommand request, CancellationToken cancellationToken)
        {
            var creator = await UserRepository.GetOneAsync(request.UserId);
            if (creator == null)
                throw new UserNotFoundException("Kullanıcı bulunamadı.");

            var newEntity = base.Mapper.Map<Domain.Entry>(request);
            newEntity.Url = StringHelper.CreateUniqueUrl(newEntity.Subject);
            await base.Repository.CreateAsync(newEntity);
            return newEntity.Id;
        }
    }
}