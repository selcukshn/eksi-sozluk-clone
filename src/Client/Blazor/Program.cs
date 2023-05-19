using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor;
using Common.Helpers;
using Blazor.Services.Request.Base;
using Blazor.Services.Request.Entry;
using Blazor.Services.Request.EntryComment;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient(sp => new HttpClient
{
    BaseAddress = new Uri(WebConstants.ApiHttpsAddress),
});
builder.Services.AddTransient<IRequestService, RequestService>();
builder.Services.AddTransient<IEntryRequestService, EntryRequestService>();
builder.Services.AddTransient<IEntryCommentRequestService, EntryCommentRequestService>();
await builder.Build().RunAsync();
