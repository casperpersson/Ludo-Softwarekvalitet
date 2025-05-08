using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GameSettings
    {
        public int NumberOfPlayers { get; set; } = 4; // Default to 4 players
        public int TokensPerPlayer { get; set; } = 4; // Default to 4 tokens per player
        public int BoardSize { get; set; } = 56; // Default board size (e.g., 56 positions)
        public bool EnableSafeZones { get; set; } = true; // Enable safe zones by default
        public bool AllowExtraTurnOnSix { get; set; } = true; // Default rule for rolling a six
    }

}
