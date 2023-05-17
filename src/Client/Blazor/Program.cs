using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor;
using Common.Helpers;
using Blazor.Services.Request;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(WebConstants.ApiHttpsAddress),
});
builder.Services.AddScoped<IRequestService, RequestService>();
await builder.Build().RunAsync();
