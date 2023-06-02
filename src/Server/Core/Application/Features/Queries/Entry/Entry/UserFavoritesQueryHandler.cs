using Application.Interfaces.Repository;
using AutoMapper;
using Common.Exceptions.Base;
using Common.Models.Queries;
using Common.Models.View;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Entry.Entry
{
    public class UserFavoritesQueryHandler : GenericHandler<IEntryFavoriteRepository, UserFavoritesQuery, IEnumerable<EntryViewModel>>
    {
        private readonly IEntryCommentFavoriteRepository entryCommentFavoriteRepository;
        public UserFavoritesQueryHandler(IEntryFavoriteRepository repository, IMapper mapper, IEntryCommentFavoriteRepository entryCommentFavoriteRepository) : base(repository, mapper)
        {
            this.entryCommentFavoriteRepository = entryCommentFavoriteRepository;
        }

        public override async Task<IEnumerable<EntryViewModel>> Handle(UserFavoritesQuery request, CancellationToken cancellationToken)
        {
            var entries = await base.Repository.AsQueryable()
            .Include(e => e.Entry)
            .ThenInclude(e => e.User)
            .Where(e => e.UserId == request.UserId)
            .Skip(request.Skip)
            .Take(request.Count)
            .ToListAsync();

            var entryComments = await entryCommentFavoriteRepository.AsQueryable()
            .Include(e => e.EntryComment)
            .ThenInclude(e => e.Entry)
            .Include(e => e.EntryComment)
            .ThenInclude(e => e.User)
            .Where(e => e.UserId == request.UserId)
            .Skip(request.Skip)
            .Take(request.Count)
            .ToListAsync();

            if (!entries.Any() && !entryComments.Any())
                throw new NotFoundException("favorilere eklenmiş entry bulunamadı");

            var entriesMap = entries.Select(e => new EntryViewModel()
            {
                Content = e.Entry.Content,
                Subject = e.Entry.Subject,
                CreatedDate = e.Entry.CreatedDate,
                Url = e.Entry.Url,
                Username = e.Entry.User.Username,
                UserImage = e.Entry.User.Image
            });
            var entryCommentsMap = entryComments.Select(e => new EntryViewModel()
            {
                Content = e.EntryComment.Content,
                Subject = e.EntryComment.Entry.Subject,
                CreatedDate = e.EntryComment.CreatedDate,
                Url = e.EntryComment.Entry.Url,
                Username = e.EntryComment.User.Username,
                UserImage = e.EntryComment.User.Image
            });
            return entriesMap.Concat(entryCommentsMap);
        }
    }
}