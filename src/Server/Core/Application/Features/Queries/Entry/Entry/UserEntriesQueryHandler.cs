using Application.Interfaces.Repository;
using AutoMapper;
using Common.Exceptions.Base;
using Common.Models.Queries;
using Common.Models.View;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Entry.Entry
{
    public class UserEntriesQueryHandler : GenericHandler<IEntryRepository, UserEntriesQuery, IEnumerable<EntryViewModel>>
    {
        private readonly IEntryCommentRepository entryCommentRepository;
        public UserEntriesQueryHandler(IEntryRepository repository, IMapper mapper, IEntryCommentRepository entryCommentRepository) : base(repository, mapper)
        {
            this.entryCommentRepository = entryCommentRepository;
        }

        public override async Task<IEnumerable<EntryViewModel>> Handle(UserEntriesQuery request, CancellationToken cancellationToken)
        {
            var entries = await base.Repository.AsQueryable()
            .Include(e => e.User)
            .Include(e => e.EntryVotes)
            .Include(e => e.EntryFavorites)
            .Where(e => e.UserId == request.UserId)
            .Skip(request.Skip)
            .Take(request.Count)
            .ToListAsync();

            var entryComments = await entryCommentRepository.AsQueryable()
            .Include(e => e.Entry)
            .Include(e => e.User)
            .Include(e => e.EntryCommentFavorites)
            .Include(e => e.EntryCommentVotes)
            .Where(e => e.UserId == request.UserId)
            .Skip(request.Skip)
            .Take(request.Count)
            .ToListAsync();

            if (!entries.Any() && !entryComments.Any())
                throw new NotFoundException("entry bulunamadı");

            var entriesMap = entries.Select(e => new EntryViewModel()
            {
                Id = e.Id,
                Content = e.Content,
                Subject = e.Subject,
                CreatedDate = e.CreatedDate,
                Url = e.Url,
                Username = e.User.Username,
                UserImage = e.User.Image,
                IsFavorite = e.EntryFavorites.Any(b => b.UserId == request.UserId && b.EntryId == e.Id) && request.UserId != Guid.Empty,
                VoteType = e.EntryVotes.Any(b => b.UserId == request.UserId) && request.UserId != Guid.Empty ?
                    e.EntryVotes.First(b => b.UserId == request.UserId).Type :
                    Common.Enums.VoteType.None,
                IsEntry = true
            });
            var entryCommentsMap = entryComments.Select(e => new EntryViewModel()
            {
                Id = e.Id,
                Content = e.Content,
                Subject = e.Entry.Subject,
                CreatedDate = e.CreatedDate,
                Url = e.Entry.Url,
                Username = e.User.Username,
                UserImage = e.User.Image,
                IsFavorite = e.EntryCommentFavorites.Any(b => b.UserId == request.UserId && b.EntryCommentId == e.Id) && request.UserId != Guid.Empty,
                VoteType = e.EntryCommentVotes.Any(b => b.UserId == request.UserId) && request.UserId != Guid.Empty ?
                    e.EntryCommentVotes.First(b => b.UserId == request.UserId).Type :
                    Common.Enums.VoteType.None,
                IsEntryComment = true
            });
            return entriesMap.Concat(entryCommentsMap);
        }
    }
}