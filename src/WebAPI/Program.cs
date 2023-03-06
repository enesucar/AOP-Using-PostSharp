using FluentValidation;
using System.Reflection;
using WebAPI.CrossCuttingConcerns.Caching;
using WebAPI.CrossCuttingConcerns.Caching.Microsoft;
using WebAPI.DataAccess;
using WebAPI.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<ICacheManager, MemoryCacheManager>();
builder.Services.AddSingleton<IWeatherForecastRepository, WeatherForecastRepository>();

ServiceTool.Create(builder.Services);

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
