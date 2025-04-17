using LudoGame.Core.Dice;
using LudoGame.Core.Enums;
using LudoGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.Core.Domain
{
    /// <summary>
    /// Orkestrerer tur‑flow og afhænger kun af abstraktioner (D – DIP).
    /// </summary>
    public sealed class Game
    {
        private readonly IDice _dice;
        private readonly IBoard _board;
        private readonly IList<IPlayer> _players;
        private int _idx;

        public Game(IDice dice, IBoard board, IEnumerable<PlayerColor> colors)
        {
            _dice = dice;
            _board = board;
            _players = colors.Select(c => (IPlayer)new Player(c, board)).ToList();
            _idx = 0; // kan randomiseres
        }

        public IPlayer Current => _players[_idx];
        public int Roll() => _dice.Roll();

        /// <summary>Spiller én tur. UI vælger brik via delegat.</summary>
        public void PlayTurn(Func<IPlayer, int, Piece?> choosePiece)
        {
            int roll = Roll();
            var movable = Current.MovablePieces(roll).ToArray();
            if (movable.Length == 0) { NextTurn(roll); return; }

            var piece = choosePiece(Current, roll) ?? movable.First();
            if (!_board.CanMove(piece, roll))
                throw new InvalidOperationException("Illegal move");

            if (piece.State == PieceState.InYard) _board.EnterBoard(piece);
            else _board.MovePiece(piece, roll);

            if (Current.HasWon) GameWon?.Invoke(Current);

            NextTurn(roll);
        }

        private void NextTurn(int roll)
        {
            if (roll != 6) _idx = (_idx + 1) % _players.Count;
        }

        public event Action<IPlayer>? GameWon;
    }
}

