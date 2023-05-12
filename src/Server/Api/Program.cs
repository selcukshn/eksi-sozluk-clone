using Persistence;
using Application;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
