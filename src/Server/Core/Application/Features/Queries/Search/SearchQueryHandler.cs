using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using AutoMapper;
using Common.Models.Queries;
using Common.Models.View;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Search
{
    public class SearchQueryHandler : GenericHandler<IEntryRepository, SearchQuery, SearchViewModel>
    {
        private readonly IUserRepository userRepository;
        public SearchQueryHandler(IEntryRepository repository, IMapper mapper, IUserRepository userRepository) : base(repository, mapper)
        {
            this.userRepository = userRepository;
        }

        public override async Task<SearchViewModel> Handle(SearchQuery request, CancellationToken cancellationToken)
        {
            var viewModel = new SearchViewModel()
            {
                Entry = new List<SearchResultEntryModel>(),
                User = new List<SearchResultUserModel>()
            };
            var entries = await base.Repository.AsQueryable().Where(e => e.Subject.Contains(request.Value)).Take(request.Count).ToListAsync();
            if (entries.Any())
            {
                viewModel.Entry.AddRange(entries.Select(e => new SearchResultEntryModel()
                {
                    Subject = e.Subject,
                    Url = e.Url
                }));
            }
            if (entries.Count < request.Count)
            {
                var users = await userRepository.AsQueryable().Where(e => e.Username.Contains(request.Value)).Take(request.Count - entries.Count).ToListAsync();
                if (users.Any())
                    viewModel.User.AddRange(users.Select(e => new SearchResultUserModel()
                    {
                        UserId = e.Id,
                        Username = e.Username
                    }));
            }
            return viewModel;
        }
    }
}