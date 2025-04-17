
using LudoGame.Core;
using System.ComponentModel;
using System.IO.Pipelines;
using System.Reflection;
using LudoGame.Api.Store;
using LudoGame.Core.Domain;
using LudoGame.Core.Dice;
using LudoGame.Core.Enums;
using LudoGame.Core.Interfaces;


namespace LudoGame.Api.Store
{
    public sealed class InMemoryGameStore : IGameStore
    {
        private readonly Dictionary<Guid, TrackedGame> _games = new();

        public TrackedGame Create(IEnumerable<PlayerColor> colors, IDice dice)
        {
            var game = new Game(dice, new Board(), colors);
            var tracked = new TrackedGame(game);
            _games[tracked.Id] = tracked;
            return tracked;
        }

        public TrackedGame? Get(Guid id) => _games.TryGetValue(id, out var g) ? g : null;
    }

    public sealed class TrackedGame
    {
        public TrackedGame(Game game) => Game = game;
        public Guid Id { get; } = Guid.NewGuid();
        public Game Game { get; }

        public IEnumerable<Piece> Pieces
        {
            get
            {
                var field = typeof(Game).GetField("_players", BindingFlags.Instance | BindingFlags.NonPublic);
                return field?.GetValue(Game) is IEnumerable<IPlayer> players
                    ? players.SelectMany(p => p.Pieces)
                    : Enumerable.Empty<Piece>();
            }
        }
    }
}