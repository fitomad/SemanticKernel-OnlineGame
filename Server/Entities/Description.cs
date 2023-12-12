namespace TechTalkServer.Entities;

public record Description
{
    public required string GameName { get; init; }
    public required string Text { get; init; }
}