using LudoGame.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.Core.Interfaces
{
    public interface IBoard
    {
        bool CanMove(Piece piece, int steps);
        void MovePiece(Piece piece, int steps);
        void EnterBoard(Piece piece);
        bool IsFinished(Piece piece);
    }
}
