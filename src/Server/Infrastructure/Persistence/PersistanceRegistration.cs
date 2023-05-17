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
                opt.UseSqlServer(configuration.GetConnectionString("MSSQL"));
            });

            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IEntryRepository, EntryRepository>();
            service.AddScoped<IEntryCommentRepository, EntryCommentRepository>();

            new FakeData(new SozlukCloneContext()).GenerateAsync().GetAwaiter().GetResult();
            // new FakeData(new SozlukCloneContext()).CleanAsync().GetAwaiter().GetResult();

            return service;
        }
    }
}