namespace TechTalkServer.Entities;

public record MasterTurn
{
    public required Turn Turn { get; init; }
    public required Asset Asset { get; init; } 
}