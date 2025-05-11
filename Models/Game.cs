using Models;
using LudoAPI.Models;
using System.Reflection;
namespace LudoAPI.Models
{
    public class Game
    {
        public Board Board { get; private set; }
        public List<Player> Players { get; private set; }
        public Player CurrentPlayer => Players[CurrentPlayerIndex];
        public int CurrentPlayerIndex { get; private set; }
        private Dice Dice { get; set; }
        public Player Winner { get; private set; }
        public GameSettings Settings { get; private set; }
        public int ConsecutiveSixes { get; set; }

        public Game(GameSettings settings)
        {
            Settings = settings;
            // Update the constructor call in Game.cs
            Board = new Board(settings.BoardSize, settings.EnableSafeZones); // Use EnableSafeZones instead of HasSafeZones
                                                                             // Pass required arguments
        }


        public void Initialize()
        {
            Board = new Board(Settings.BoardSize, Settings.EnableSafeZones); // Pass required arguments
            Players = new List<Player>();
            Dice = new Dice();

            for (int i = 0; i < Settings.NumberOfPlayers; i++)
            {
                var player = new Player
                {
                    Tokens = Enumerable.Range(0, Settings.TokensPerPlayer)
                        .Select(_ => new Token { State = TokenState.AtStart })
                        .ToList()
                };
                Players.Add(player);
            }
        }

        public void MoveToken(Player player, Token token, int steps)
        {
            if (token.State == TokenState.AtStart)
                throw new InvalidOperationException("Token must enter the board first.");

            if (token.State == TokenState.OnBoard)
            {
                token.Position += steps;

                if (Board.IsHomePosition(token.Position.Value, CurrentPlayerIndex))
                {
                    token.State = TokenState.InHome;
                    token.Position = null; // Clear position when in home
                }
            }
            else if (token.State == TokenState.InHome)
            {
                throw new InvalidOperationException("Token is already in home.");
            }
        }




        public void EnterBoard(Token token)
        {
            if (token.State != TokenState.AtStart)
                throw new InvalidOperationException("Token is not at the starting position.");

            token.State = TokenState.OnBoard;
            token.Position = Board.GetStartingPosition(CurrentPlayerIndex);
        }


        public void CaptureToken(Token movingToken)
        {
            foreach (var player in Players)
            {
                if (player == CurrentPlayer) continue;

                foreach (var token in player.Tokens)
                {
                    if (token.State == TokenState.OnBoard &&
                        token.Position == movingToken.Position &&
                        !Board.IsSafeZone(token.Position.Value)) // Check if the position is not a safe zone
                    {
                        token.State = TokenState.AtStart;
                        token.Position = null; // Reset position
                    }
                }
            }
        }

        public bool IsSafeZone(int position)
        {
            return Board.SafeZones.Contains(position); // Define safe zones in the Board class
        }

        public bool CheckWinCondition(Player player)
        {
            return player.Tokens.All(token => token.State == TokenState.InHome);
        }


        public void NextTurn()
        {
            Dice.ResetConsecutiveSixes();
            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Players.Count;
        }
        public bool HasPlayerWon(Player player)
        {
            return player.Tokens.All(token => token.State == TokenState.InHome);
        }

        public void CheckForWinner()
        {
            foreach (var player in Players)
            {
                if (HasPlayerWon(player))
                {
                    Winner = player;
                    break;
                }
            }
        }
        public void EndTurn()
        {
            CheckForWinner();
            if (Winner == null)
            {
                NextTurn();
            }
            else
            {
                Console.WriteLine($"Player {Players.IndexOf(Winner) + 1} has won the game!");
            }
        }

    }
}
