using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
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
        private List<Guid>? UserIds;
        private List<Guid>? EntriesIds;
        private List<DateTime>? EntryDates;

        public FakeData(SozlukCloneContext context)
        {
            Context = context;
            Bogus = new Faker();
        }

        public async Task GenerateAsync(int count = 250)
        {
            UserIds = await AddUsersAsync(count);
            EntriesIds = await AddEntriesAsync(count);
            await AddEntryComments(count);
        }

        private async Task<List<Guid>> AddUsersAsync(int count)
        {
            if (Context.Users.Any())
                return await Context.Users.Select(e => e.Id).ToListAsync();

            var users = new Faker<User>("tr")
            .RuleFor(e => e.Id, e => Guid.NewGuid())
            .RuleFor(e => e.Email, e => e.Internet.Email())
            .RuleFor(e => e.EmailConfirmed, e => e.Random.Bool())
            .RuleFor(e => e.Password, e => HashHelper.GeneratePassword(e.Internet.Password()))
            .RuleFor(e => e.Username, e => e.Internet.UserName())
            .Generate(count);
            await Context.Users.AddRangeAsync(users);
            await Context.SaveChangesAsync();
            return users.Select(e => e.Id).ToList();

        }
        private async Task<List<Guid>> AddEntriesAsync(int count)
        {
            if (Context.Entries.Any())
            {
                var dbEntries = await Context.Entries.Select(e => new { e.CreatedDate, e.Id }).ToListAsync();
                EntryDates = dbEntries.Select(e => e.CreatedDate).ToList();
                return dbEntries.Select(e => e.Id).ToList();
            }
            else
            {
                var entries = new Faker<Entry>("tr")
                .RuleFor(e => e.Id, e => Guid.NewGuid())
                .RuleFor(e => e.UserId, UserIds.OrderBy(e => Guid.NewGuid()).First())
                .RuleFor(e => e.Content, e => e.Lorem.Sentences(e.Random.Int(5, 10)))
                .RuleFor(e => e.Subject, Bogus.Lorem.Sentences(Bogus.Random.Int(1, 2)))
                .RuleFor(e => e.CreatedDate, e => e.Date.Between(DateTime.Now.AddDays(-(365 * 5)), DateTime.Now))
                .Generate(count);
                foreach (var entry in entries)
                {
                    entry.Url = StringHelper.CreateUniqueUrl(entry.Subject);
                }
                await Context.AddRangeAsync(entries);
                await Context.SaveChangesAsync();
                EntryDates = entries.Select(e => e.CreatedDate).ToList();
                return entries.Select(e => e.Id).ToList();
            }
        }
        private async Task<List<Guid>> AddEntryComments(int count)
        {
            if (Context.EntryComments.Any())
                return await Context.EntryComments.Select(e => e.Id).ToListAsync();

            var comments = new Faker<EntryComment>("tr")
            .RuleFor(e => e.Id, e => Guid.NewGuid())
            .RuleFor(e => e.Content, e => e.Lorem.Sentences(e.Random.Int(3, 5)))
            .RuleFor(e => e.CreatedDate, e => e.Date.Between(EntryDates[e.Random.Int(0, EntryDates.Count - 1)], EntryDates[e.Random.Int(0, EntryDates.Count - 1)].AddHours(e.Random.Double(1, 10000))))
            .RuleFor(e => e.UserId, e => UserIds.OrderBy(e => Guid.NewGuid()).First())
            .RuleFor(e => e.EntryId, e => EntriesIds.OrderBy(e => Guid.NewGuid()).First())
            .Generate(count);
            await Context.EntryComments.AddRangeAsync(comments);
            await Context.SaveChangesAsync();
            return comments.Select(e => e.Id).ToList();
        }

    }
}