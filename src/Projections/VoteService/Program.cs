using VoteService;
using VoteService.Service;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IVoteDbService, VoteDbService>();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
