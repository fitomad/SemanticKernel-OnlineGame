using TechTalkServer.Entities;

namespace TechTalkServer.Data;

public interface IGameRepository
{
    public Game[] FetchAll();
    public Game FetchGame(string gameID);
}

internal class GameRepository: IGameRepository
{
    private List<Game> games = new List<Game> {
        new Game {
            GameID = "el-bosque",
            Name = "El Bosque",
            Genre = "Terror",
            Description = "Un juego de terror donde exploras un bosque lleno de horrores y secretos. Combate, resuelve puzzles y sobrevive a los peligros que acechan en la oscuridad. Una experiencia de terror psicológico única. ¿Te atreves?"
        },
        new Game {
            GameID = "el-dragon",
            Name = "El Dragón",
            Genre = "Fantasy",
            Description = "Elige tu casa, alíate o traiciona, y cambia la historia con tus decisiones. Un juego online de rol de poder, honor y supervivencia."
        },
        new Game {
            GameID = "derry",
            Name = "Derry",
            Genre = "Terror",
            Description = "Enfrenta al payaso Pennywise que se alimenta del miedo de los niños en Derry, un pueblo lleno de secretos y horrores. Crea tu personaje, únete a tus amigos, y vence al monstruo."
        },
        new Game {
            GameID = "stars",
            Name = "Stars",
            Genre = "Sci-Fi",
            Description = "Explora la galaxia en Stars, un juego de rol online donde puedes personalizar tu nave espacial, visitar planetas exóticos, combatir contra alienígenas hostiles, y descubrir los secretos del universo."
        },
        new Game {
            GameID = "2070",
            Name = "2070",
            Genre = "Cyberpunk",
            Description = "Entra en el mundo de 2070, un juego de rol online donde puedes crear tu propio personaje, explorar una ciudad distópica, luchar contra corporaciones malvadas y hackers rebeldes, y forjar tu propio destino."
        }
    };

    public Game[] FetchAll()
    {
        return games.ToArray();
    }

    public Game FetchGame(string gameID)
    {
        var selectedGame = (
            from game in games
            where game.GameID == gameID
            select game
        )
        .First<Game>();

        return selectedGame;
    }
}