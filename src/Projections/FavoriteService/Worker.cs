using Common.Infrastructure.RabbitMQ;
using Common.Models.Command;
using FavoriteService.Service;

namespace FavoriteService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IFavoriteDbService FavoriteDbService;

    public Worker(ILogger<Worker> logger, IFavoriteDbService favoriteDbService)
    {
        _logger = logger;
        FavoriteDbService = favoriteDbService;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var queueConsumer = new QueueConsumer(QueueConstants.CreateEntryFavoriteQueue);
        queueConsumer.Received<EntryFavoriteCommand>(async received =>
        {
            await FavoriteDbService.EntryFavoriteProcessAsync(received);
            System.Console.WriteLine($"Data received EntryId: {received.EntryId} , UserId: {received.UserId}");
        }).Consume();
    }
}
