using Bogus;
using Common.Extensions;
using Common.Helpers;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence
{
    public class FakeData
    {
        private readonly SozlukCloneContext Context;
        private readonly Faker Bogus;
        private List<Guid> UserIds;
        private List<Guid> EntriesIds;
        private List<DateTime> EntryDates;

        public FakeData(SozlukCloneContext context)
        {
            Context = context;
            Bogus = new Faker();
        }

        public async Task GenerateAsync(int userCount = 25, int entryCount = 25, int entryCommentCount = 500)
        {
            await AddUsersAsync(userCount);
            await AddEntriesAsync(entryCount);
            await AddEntryComments(entryCommentCount);
        }
        public async Task CleanAsync()
        {
            Context.Users.RemoveRange(await Context.Users.ToListAsync());
            Context.Entries.RemoveRange(await Context.Entries.ToListAsync());
            Context.EntryComments.RemoveRange(await Context.EntryComments.ToListAsync());
            await Context.SaveChangesAsync();
        }

        private async Task AddUsersAsync(int count)
        {
            if (!Context.Users.Any())
            {
                var users = new Faker<User>("tr")
                .RuleFor(e => e.Id, e => Guid.NewGuid())
                .RuleFor(e => e.Email, e => e.Internet.Email())
                .RuleFor(e => e.EmailConfirmed, e => e.Random.Bool())
                .RuleFor(e => e.Password, e => HashHelper.GeneratePassword(e.Internet.Password()))
                .RuleFor(e => e.Username, e => e.Internet.UserName())
                .Generate(count);
                await Context.Users.AddRangeAsync(users);
                await Context.SaveChangesAsync();
            }
            UserIds = await Context.Users.Select(e => e.Id).ToListAsync();
        }
        private async Task AddEntriesAsync(int count)
        {
            if (!Context.Entries.Any())
            {
                var entries = new Faker<Entry>("tr")
                .RuleFor(e => e.Id, e => Guid.NewGuid())
                .RuleFor(e => e.UserId, e => UserIds[e.Random.Int(0, UserIds.Count - 1)])
                .RuleFor(e => e.Content, e => e.Lorem.Sentences(e.Random.Int(5, 10)))
                .RuleFor(e => e.Subject, e => e.Lorem.Sentences(e.Random.Int(1, 2)))
                .RuleFor(e => e.CreatedDate, e => e.Date.Between(DateTime.Now.AddDays(-(365 * 5)), DateTime.Now))
                .Generate(count);
                foreach (var entry in entries)
                {
                    entry.Url = entry.Subject.ToUniqueUrl();
                }
                await Context.AddRangeAsync(entries);
                await Context.SaveChangesAsync();
            }
            var dbEntries = await Context.Entries.Select(e => new { e.CreatedDate, e.Id }).ToListAsync();
            EntryDates = dbEntries.Select(e => e.CreatedDate).ToList();
            EntriesIds = dbEntries.Select(e => e.Id).ToList();
        }
        private async Task AddEntryComments(int count)
        {
            int entityCount = Context.EntryComments.Count();
            if (!Context.EntryComments.Any() || entityCount < count)
            {
                var comments = new Faker<EntryComment>("tr")
                .RuleFor(e => e.Id, e => Guid.NewGuid())
                .RuleFor(e => e.Content, e => e.Lorem.Sentences(e.Random.Int(3, 5)))
                .RuleFor(e => e.CreatedDate, e => e.Date.Between(EntryDates[e.Random.Int(0, EntryDates.Count - 1)], EntryDates[e.Random.Int(0, EntryDates.Count - 1)].AddHours(e.Random.Double(1, 10000))))
                .RuleFor(e => e.UserId, e => UserIds[e.Random.Int(0, UserIds.Count - 1)])
                .RuleFor(e => e.EntryId, e => EntriesIds[e.Random.Int(0, EntriesIds.Count - 1)])
                .Generate(entityCount < count ? count - entityCount : count);
                await Context.EntryComments.AddRangeAsync(comments);
                await Context.SaveChangesAsync();
            }
        }

    }
}