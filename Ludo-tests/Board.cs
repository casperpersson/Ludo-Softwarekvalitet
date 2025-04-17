using Ludo_tests.Ludo_tests;
using System.Collections.Generic;

namespace Ludo_tests
{
    public class Board
    {
        private readonly Dictionary<int, Piece> _positions = new Dictionary<int, Piece>();

        public void PlacePiece(Piece piece, int position)
        {
            if (_positions.TryGetValue(position, out var existingPiece))
            {
                if (existingPiece.Owner != piece.Owner)
                {
                    existingPiece.SendHome(); // slå modstander hjem
                    _positions.Remove(position);
                }
            }

            piece.MoveTo(position);
            _positions[position] = piece;
        }
    }
}
