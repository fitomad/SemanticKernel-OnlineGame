namespace TechTalkServer.Entities;

public record Game
{
    public required string Name { get; init;}
    public required string Description { get; init; }
    public required string GameID { get; init; }
    public required string Genre { get; init; }
}