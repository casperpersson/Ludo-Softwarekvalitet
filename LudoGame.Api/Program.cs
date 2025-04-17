using LudoGame.Core;
using LudoGame.Api.Store;
using LudoGame.Core.Dice;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Core dependencies
builder.Services.AddSingleton<IDice, RandomDice>();
builder.Services.AddSingleton<IGameStore, InMemoryGameStore>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

// Gør Program tilgængelig for WebApplicationFactory<T> i tests
public partial class Program { }
