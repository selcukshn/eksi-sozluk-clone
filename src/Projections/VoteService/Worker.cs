using Common.Infrastructure.RabbitMQ;
using Common.Models.Command;
using VoteService.Service;

namespace VoteService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IVoteDbService VoteDbService;

    public Worker(ILogger<Worker> logger, IVoteDbService voteDbService)
    {
        _logger = logger;
        VoteDbService = voteDbService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var queueConsumer = new QueueConsumer(QueueConstants.CreateEntryVoteQueue);
        queueConsumer.Received<EntryVoteCommand>(async received =>
        {
            await VoteDbService.EntryVoteProcessAsync(received);
            System.Console.WriteLine($"Vote data received 'EntryId' : {received.EntryId} , 'UserId' : {received.UserId} 'VoteType' : {received.Type}");
        }).Consume();
    }
}
