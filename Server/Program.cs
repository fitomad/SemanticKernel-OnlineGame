using System.Runtime.CompilerServices;
using TechTalkServer.Entities;
using TechTalkServer.Data;
using Intelligence;
using Fitomad.OpenAI;
using Fitomad.OpenAI.Extensions;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI

var apiKey = builder.Configuration["OpenAI:ApiKey"];

IntelligenceClient intelligence = new IntelligenceClientBuilder()
    .WithOpenAIApiKey(apiKey!)
    .WithOpenAIModel("gpt-3.5-turbo")
    .Build();

builder.Services.AddSingleton<IIntelligenceClient>(intelligence);
builder.Services.AddSingleton<IPlayRepository, PlayRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();

var openAISettings = new OpenAISettingsBuilder()
    .WithApiKey(apiKey!)
    .Build();

builder.Services.AddOpenAIHttpClient(settings: openAISettings);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();
app.UseHttpsRedirection();



/*
RouteGroupBuilder gameRoute = app.MapGroup("/game");

gameRoute.MapGet("/", () =>
{
    var games =  Enumerable.Range(1, 5).Select(index =>
        new Game {
            Name = "El Bosque",
            Description = "Una descripción",
            GameID = "el-bosque"
        }
    )
    .ToArray();
    
    return TypedResults.Ok(games);
})
.WithName("GetGames")
.WithOpenApi();

gameRoute.MapGet("/{gameName}", (string gameName) => 
{
    return Results.Ok($"Description ({gameName})");
})
.WithName("GetGameDescription")
.WithOpenApi();

gameRoute.MapPost("/{gameName}", (string gameName) =>
{
    return Results.Ok($"Contestación de ChatGPT ({gameName})");
})
.WithName("GetGameResponse")
.WithOpenApi();
*/
app.Run();