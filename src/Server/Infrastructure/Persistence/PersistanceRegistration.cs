using Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence
{
    public static class PersistanceRegistration
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<SozlukCloneContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SQLServer"));
            });

            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IEntryRepository, EntryRepository>();
            service.AddScoped<IEntryCommentRepository, EntryCommentRepository>();
            service.AddScoped<IEntryVoteRepository, EntryVoteRepository>();
            service.AddScoped<IEntryFavoriteRepository, EntryFavoriteRepository>();

            // new FakeData().CleanAsync().GetAwaiter().GetResult();
            new FakeData().GenerateAsync().GetAwaiter().GetResult();

            return service;
        }
    }
}