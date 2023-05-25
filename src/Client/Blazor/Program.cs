using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor;
using Common.Helpers;
using Blazor.Services;
using Blazored.LocalStorage;
using Blazor.Configurations.Http;
using Blazor.Configurations;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddServicesDependencies();
builder.Services.AddConfigurationsDependencies();

builder.Services.AddHttpClient("LocalApi", client =>
{
    client.BaseAddress = new Uri(WebConstants.ApiHttpsAddress);
}).AddHttpMessageHandler<AuthenticationHandler>();

builder.Services.AddScoped(factory =>
{
    var clientFactory = factory.GetRequiredService<IHttpClientFactory>();
    return clientFactory.CreateClient("LocalApi");
});

await builder.Build().RunAsync();
