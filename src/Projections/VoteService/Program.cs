using VoteService;
using VoteService.Service;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IVoteDbService, VoteDbService>();
    })
    .Build();

await host.RunAsync();
