using Common.Models.Command;

namespace FavoriteService.Service
{
    public interface IFavoriteDbService
    {
        Task EntryFavoriteProcessAsync(EntryFavoriteCommand command);
    }
}