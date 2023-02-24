
using Microsoft.Extensions.Configuration;
using SympliDevelopment.Api.Services.Interfaces;
using SympliDevelopment.Api.Services;
using SympliDevelopment.Api.Services.Models;
using SympliDevelopment.Api.Factories.Interfaces;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISearchService, GoogleSearchService>();
builder.Services.AddScoped<ISearchService, BingSearchService>();

builder.Services.AddScoped<IDetectionService, GoogleDetectionService>();
builder.Services.AddScoped<IDetectionService, BingDetectionService>();

builder.Services.AddScoped<ISearchAbstractFactory, GoogleFactory>();
builder.Services.AddScoped<ISearchAbstractFactory, BingFactory>();

builder.Services.AddSingleton<IMemoryCache,MemoryCache>();

builder.Services.AddHttpClient();
builder.Services.Configure<SeparatorOptions>(builder.Configuration.GetSection("Separators"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
