using Ludo_tests;
using System.Collections.Generic;
using System.Linq;

public class GameService
{
    private const int MAX_PLAYERS = 4;
    private List<Player> players = new List<Player>();

    public bool AddPlayer(string name, string color)
    {
        if (players.Count >= MAX_PLAYERS || players.Any(p => p.Name == name || p.Color == color))
            return false;

        players.Add(new Player { Name = name, Color = color });
        return true;
    }

    public bool RemovePlayer(string name)
    {
        var player = players.FirstOrDefault(p => p.Name == name);
        if (player == null) return false;

        return players.Remove(player);
    }

    public List<Player> GetPlayers()
    {
        return players;
    }

    public bool HasPlayerWon(Player player)
    {
        return player.Tokens.All(t => t == 57);
    }
}
