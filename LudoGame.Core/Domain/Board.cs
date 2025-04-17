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
    /// Implementerer Ludo‑reglerne (S + O; står for al felt‑logik).
    /// </summary>
    public class Board : IBoard
    {
        private const int LoopLength = 52;
        private const int HomeLength = 6;

        private static readonly Dictionary<PlayerColor, int> StartIndex = new()
    {
        { PlayerColor.Red, 0 }, { PlayerColor.Green, 13 },
        { PlayerColor.Yellow, 26 }, { PlayerColor.Blue, 39 }
    };
        private static readonly Dictionary<PlayerColor, int> EntryIndex = new()
    {
        { PlayerColor.Red, 51 }, { PlayerColor.Green, 12 },
        { PlayerColor.Yellow, 25 }, { PlayerColor.Blue, 38 }
    };

        // 0‑51 på fælles-banen
        private readonly Dictionary<int, Piece?> _loop = new();
        // (color, 0‑5) i hjemmebanen
        private readonly Dictionary<(PlayerColor, int), Piece?> _home = new();

        public Board()
        {
            for (int i = 0; i < LoopLength; i++) _loop[i] = null;
            foreach (PlayerColor c in Enum.GetValues<PlayerColor>())
                for (int h = 0; h < HomeLength; h++)
                    _home[(c, h)] = null;
        }

        private static int Norm(int idx) => (idx % LoopLength + LoopLength) % LoopLength;
        private int DistToHome(PlayerColor c, int idx) =>
            (EntryIndex[c] - Norm(idx) + LoopLength) % LoopLength + 1;

        #region IBoard — validering & mutation
        public bool CanMove(Piece p, int steps)
        {
            if (p.State == PieceState.Finished) return false;
            if (p.State == PieceState.InYard)
                return steps == 6 && _loop[StartIndex[p.Color]] == null;

            if (p.State == PieceState.OnLoop)
            {
                int dist = DistToHome(p.Color, p.Position);
                if (steps < dist)
                    return _loop[Norm(p.Position + steps)]?.Color != p.Color;

                int homeIdx = steps - dist;
                return homeIdx < HomeLength && _home[(p.Color, homeIdx)] == null;
            }

            // p.State == InHome
            return p.Position + steps < HomeLength &&
                   _home[(p.Color, p.Position + steps)] == null;
        }

        public void EnterBoard(Piece p)
        {
            int start = StartIndex[p.Color];
            _loop[start] = p;
            p.State = PieceState.OnLoop;
            p.Position = start;
        }

        public void MovePiece(Piece p, int steps)
        {
            if (p.State == PieceState.InYard) { EnterBoard(p); return; }

            if (p.State == PieceState.OnLoop)
            {
                int dist = DistToHome(p.Color, p.Position);
                if (steps < dist)
                {
                    int tgt = Norm(p.Position + steps);
                    CaptureIfOpponent(p, tgt);
                    _loop[p.Position] = null;
                    _loop[tgt] = p;
                    p.Position = tgt;
                }
                else
                {
                    int hIdx = steps - dist;
                    _loop[p.Position] = null;
                    _home[(p.Color, hIdx)] = p;
                    p.State = hIdx == HomeLength - 1 ? PieceState.Finished : PieceState.InHome;
                    p.Position = hIdx;
                }
                return;
            }

            // In home‑stretch
            _home[(p.Color, p.Position)] = null;
            p.Position += steps;
            _home[(p.Color, p.Position)] = p;
            p.State = p.Position == HomeLength - 1 ? PieceState.Finished : PieceState.InHome;
        }

        public bool IsFinished(Piece p) => p.State == PieceState.Finished;
        #endregion

        private void CaptureIfOpponent(Piece mover, int idx)
        {
            var victim = _loop[idx];
            if (victim != null && victim.Color != mover.Color)
            {
                victim.State = PieceState.InYard;
                victim.Position = -1;
                _loop[idx] = null;
            }
        }
    }
}
