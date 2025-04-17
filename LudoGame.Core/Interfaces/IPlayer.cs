using LudoGame.Core.Domain;
using LudoGame.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.Core.Interfaces
{
    public interface IPlayer
    {
        PlayerColor Color { get; }
        IEnumerable<Piece> Pieces { get; }
        bool HasWon { get; }
        IEnumerable<Piece> MovablePieces(int roll);
    }
}
