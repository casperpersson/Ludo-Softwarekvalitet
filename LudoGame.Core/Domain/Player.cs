using LudoGame.Core.Enums;
using LudoGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.Core.Domain
{
    /// <summary>Spiller‑aggregat (SRP) der delegere felt­logik til IBoard.</summary>
    public sealed class Player : IPlayer
    {
        private const int PieceCount = 4;
        private readonly IBoard _board;

        public Player(PlayerColor color, IBoard board)
        {
            Color = color;
            _board = board;
            Pieces = Enumerable.Range(0, PieceCount)
                               .Select(_ => new Piece(color))
                               .ToArray();
        }

        public PlayerColor Color { get; }
        public IEnumerable<Piece> Pieces { get; }

        public bool HasWon => Pieces.All(p => _board.IsFinished(p));

        public IEnumerable<Piece> MovablePieces(int roll) =>
            Pieces.Where(p => _board.CanMove(p, roll));
    }
}
