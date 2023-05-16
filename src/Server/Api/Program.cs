using Persistence;
using Application;
using FluentValidation.AspNetCore;
using Common.Helpers;
using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);
// Port configuration
builder.WebHost.ConfigureKestrel(opt =>
{
    opt.ListenLocalhost(WebConstants.HttpPort);
    opt.ListenLocalhost(WebConstants.HttpsPort, listenOptions =>
    {
        listenOptions.UseHttps(httpsOptions =>
        {
            var localhostCert = CertificateLoader.LoadFromStoreCert("localhost", "My", StoreLocation.CurrentUser, allowInvalid: true);
            httpsOptions.ServerCertificateSelector = (context, name) =>
            {
                return localhostCert;
            };
        });
    });
});
// builder.Services.AddHttpsRedirection(opt =>
// {
//     opt.HttpsPort = WebConstants.HttpsPort;
// });
// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddPersistenceDependencies(builder.Configuration);
builder.Services.AddApplicationDependencies();
builder.Services.AddCors();

var app = builder.Build();
app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});
app.UseHttpsRedirection();
// app.UseAuthorization();

app.MapControllers();

app.Run();
