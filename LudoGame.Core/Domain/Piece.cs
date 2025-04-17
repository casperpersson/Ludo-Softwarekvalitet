using LudoGame.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.Core.Domain
{
    /// <summary>Værdiobjekt for en enkelt brik (S – Single‑Responsibility).</summary>
    public sealed class Piece
    {
        public Piece(PlayerColor color) => Color = color;

        public PlayerColor Color { get; }
        public PieceState State { get; internal set; } = PieceState.InYard;
        public int Position { get; internal set; } = -1; // ‑1 = yard
    }
}
