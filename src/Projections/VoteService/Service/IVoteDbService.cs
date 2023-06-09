using Common.Models.Command;

namespace VoteService.Service
{
    public interface IVoteDbService
    {
        Task EntryVoteProcessAsync(EntryVoteCommand command);
    }
}