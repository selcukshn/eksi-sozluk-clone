using Common.Models.Command;
using Dapper;
using Microsoft.Data.SqlClient;

namespace VoteService.Service
{
    public class VoteDbService : IVoteDbService
    {
        private readonly IConfiguration Configuration;

        public VoteDbService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task EntryVoteProcessAsync(EntryVoteCommand command)
        {
            using var sql = new SqlConnection(Configuration.GetConnectionString("SQLServer"));
            var entity = await sql.ExecuteAsync("SELECT * FROM EntryVote WHERE EntryId = @EntryId and UserId = @UserId",
                        new { EntryId = command.EntryId, UserId = command.UserId });
            if (entity == 0)
                await sql.ExecuteAsync("INSERT INTO EntryVote (EntryId,UserId,Type) VALUES (@EntryId,@UserId,@Type)",
                new { EntryId = command.EntryId, UserId = command.UserId, Type = command.Type });
            else
                await sql.ExecuteAsync("UPDATE EntryVote SET Type=@Type WHERE EntryId = @EntryId and UserId = @UserId",
                new { EntryId = command.EntryId, UserId = command.UserId, Type = command.Type });
        }
    }
}