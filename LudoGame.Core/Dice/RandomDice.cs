using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.Core.Dice
{
    /// <summary>Tilfældig 6‑sidet terning (S + O + D i SOLID).</summary>
    public sealed class RandomDice : IDice
    {
        private readonly Random _rng = new();
        public int Roll() => _rng.Next(1, 7);
    }
}
