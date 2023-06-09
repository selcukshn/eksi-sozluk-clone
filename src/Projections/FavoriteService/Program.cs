using FavoriteService;
using FavoriteService.Service;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IFavoriteDbService, FavoriteDbService>();
    })
    .Build();

await host.RunAsync();
