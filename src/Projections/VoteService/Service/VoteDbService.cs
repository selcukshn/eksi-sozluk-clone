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
            using (var connection = new SqlConnection(Configuration.GetConnectionString("SQLServer")))
            {
                var entity = connection.Query<object>("SELECT * FROM EntryVote WHERE EntryId = @EntryId and UserId = @UserId",
                                        new { EntryId = command.EntryId, UserId = command.UserId }).ToList();
                if (entity is not null && !entity.Any())
                    await connection.ExecuteAsync("INSERT INTO EntryVote (EntryId,UserId,Type) VALUES (@EntryId,@UserId,@Type)",
                    new { EntryId = command.EntryId, UserId = command.UserId, Type = command.Type });
                else
                    await connection.ExecuteAsync("UPDATE EntryVote SET Type=@Type WHERE EntryId = @EntryId and UserId = @UserId",
                    new { EntryId = command.EntryId, UserId = command.UserId, Type = command.Type });
            }
        }
    }
}