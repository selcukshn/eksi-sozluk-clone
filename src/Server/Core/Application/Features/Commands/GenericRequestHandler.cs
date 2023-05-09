using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;

namespace Application.Features.Commands
{
    public abstract class GenericRequestHandler<TRepository, TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRepository : IBaseRepository
    where TRequest : IRequest<TResponse>
    {
        protected readonly TRepository Repository;
        protected readonly IMapper Mapper;
        public GenericRequestHandler(TRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}