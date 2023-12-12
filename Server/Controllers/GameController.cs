using Microsoft.AspNetCore.Mvc;
using TechTalkServer.Entities;
using TechTalkServer.Data;
using Intelligence;
using Fitomad.OpenAI.Models.Image;
using Fitomad.OpenAI.Entities.Image;
using System.Text;

namespace TechTalkServer.Controllers;

[ApiController]
[Route("games")]
public class GameController: ControllerBase
{
    private IGameRepository _gameRepository;
    private IPlayRepository _playRepository;
    private IIntelligenceClient _intelligenceClient;
    private IOpenAIClient _openAIClient;

    public GameController(IGameRepository gameRepository, IIntelligenceClient intelligenceClient, IPlayRepository playRepository, IOpenAIClient openAIClient)
    {
        _intelligenceClient = intelligenceClient;
        _gameRepository = gameRepository;
        _playRepository = playRepository;
        _openAIClient = openAIClient;

    }
    
    [HttpGet]
    public ActionResult<Game[]> GetGames()
    {
        return Ok(_gameRepository.FetchAll());
    }

    [HttpGet("{gameID}")]
    public async Task<ActionResult<Description>> GetGameIntro(string gameID)
    {
        var game = _gameRepository.FetchGame(gameID);
        var aiDescription = await _intelligenceClient.GetDescription(game.Name, genre: game.Genre);

        var gameDescription = new Description
        {
            GameName = game.Name,
            Text = aiDescription
        };

        _playRepository.Insert(aiDescription, role: "system");

        return Ok(gameDescription);
    }

    [HttpPost("{gameName}")]
    public async Task<ActionResult<MasterTurn>> PostGameTurn(string gameName, [FromBody] Turn userTurn)
    {
        (string role, Turn turn)[] history = _playRepository.FetchAll();
        var historyLog = new StringBuilder();

        foreach(var entry in history)
        {
            var log = $"{entry.role}: {entry.turn.Result}";
            historyLog.AppendLine(log);
        }
        
        var gameResponse = await _intelligenceClient.Perform(userTurn.Result, history: historyLog.ToString());
        
        var imageRequest = new ImageRequestBuilder()
            .WithModel(ImageModelKind.DALL_E_3)
            .WithSize(DallE3Size.Square)
            .WithImagesCount(1)
            .WithPrompt(gameResponse)
            .Build();

        ImageResponse generatedImage = await _openAIClient.Image.CreateImageAsync(imageRequest);

        _playRepository.Insert(userTurn.Result, role: "user");

        var response = new MasterTurn
        {
            Turn = new Turn
            {
                Result = gameResponse
            },
            Asset = new Asset
            {
                Url = generatedImage.Images.First().Url
            }
        };

        return Ok(response);
    }

    [HttpPost("{gameName}/image")]
    public async Task<ActionResult<Asset>> GetGamePlayImage(string gameName, [FromBody] Turn turn)
    {
        Console.WriteLine($"🚀 GetGamePlayImage: {gameName}");
        var imageUri = await _intelligenceClient.GetImage(description: turn.Result);

        var asset = new Asset
        {
            Url = imageUri
        };

        return Ok(asset);
    }
}