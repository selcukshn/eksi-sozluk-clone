using Persistence;
using Application;
using FluentValidation.AspNetCore;
using Common.Helpers;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using System.Security.Cryptography.X509Certificates;
using Api.Middlewares;
using Api.Extensions;
using Microsoft.AspNetCore.Mvc;
using Common.Models.Response;

var builder = WebApplication.CreateBuilder(args);
// Port configuration
builder.WebHost.ConfigureKestrel(opt =>
{
    opt.ListenLocalhost(WebConstants.HttpPort);
    opt.ListenLocalhost(WebConstants.HttpsPort, listenOptions =>
    {
        listenOptions.UseHttps(httpsOptions =>
        {
            var certificate = CertificateLoader.LoadFromStoreCert("localhost", "My", StoreLocation.CurrentUser, allowInvalid: true);
            httpsOptions.ServerCertificateSelector = (context, name) =>
            {
                return certificate;
            };
        });
    });
});
// builder.Services.AddHttpsRedirection(opt =>
// {
//     opt.HttpsPort = WebConstants.HttpsPort;
// });
// Add services to the container.
builder.Services
    .AddControllers()
    .DisableJsonResultParametersNamingPolicy()
    .SuppressFluentValidationExceptionModel<ExceptionResponse>();

builder.Services
    .AddEndpointsApiExplorer()
    .AddPersistenceDependencies(builder.Configuration)
    .AddApplicationDependencies()
    .AuthenticationConfiguration(builder.Configuration)
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("DefaultPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

var app = builder.Build();
app.UseCors("DefaultPolicy");
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlerMiddleware>();
// app.ExceptionHandling();

// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();
app.Run();
