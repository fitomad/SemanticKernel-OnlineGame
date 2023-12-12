using Microsoft.AspNetCore.Identity;
using TechTalkServer.Entities;

namespace TechTalkServer.Data;

public interface IPlayRepository
{
    public (string role, Turn turn)[] FetchAll();
    public void Insert(string prompt, string role);
}

internal class PlayRepository: IPlayRepository
{
    private List<(string role, Turn turn)> _plays = new List<(string role, Turn turn)>();
    
    public (string role, Turn turn)[] FetchAll() 
    {
        return _plays.ToArray();
    }

    public void Insert(string prompt, string role)
    {
        var newPlay = (role: role, turn: new Turn { Result = prompt });
        _plays.Add(newPlay);
    }
}