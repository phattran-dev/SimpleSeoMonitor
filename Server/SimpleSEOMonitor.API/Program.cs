using Scalar.AspNetCore;
using SimpleSEOMonitor.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddHttpClient();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
    builder => builder
        .SetIsOriginAllowed((origin) => true)
        .AllowAnyHeader()
        .AllowAnyMethod()
    );
});

builder.Services.RegistryQueryExecutor(configuration)
    .AddServicesAndHelpers()
    .RegistryQueryHandlers()
    .RegistryHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseCors(builder =>
{
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
