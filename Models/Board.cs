using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Board
    {
        public int Size { get; private set; }
        public List<int> SafeZones { get; } = new List<int> { 0, 10, 20, 30 }; // Example safe zones
        public Board(int size, bool enableSafeZones)
        {
            Size = size;
            SafeZones = enableSafeZones ? new List<int> { 0, 10, 20, 30 } : new List<int>();
        }
        private readonly Dictionary<int, int> _startingPositions = new()
    {
        { 0, 0 },  // Player 1 starts at position 0
        { 1, 10 }, // Player 2 starts at position 10
        { 2, 20 }, // Player 3 starts at position 20
        { 3, 30 }  // Player 4 starts at position 30
    };
        private readonly Dictionary<int, List<int>> _homePositions = new()
    {
        { 0, new List<int> { 40, 41, 42, 43 } }, // Player 1's home positions
        { 1, new List<int> { 44, 45, 46, 47 } }, // Player 2's home positions
        { 2, new List<int> { 48, 49, 50, 51 } }, // Player 3's home positions
        { 3, new List<int> { 52, 53, 54, 55 } }  // Player 4's home positions
    };
    

    public bool IsSafeZone(int position)
    {
        return SafeZones.Contains(position);
    }

        public bool IsHomePosition(int position, int playerIndex)
        {
            if (!_homePositions.ContainsKey(playerIndex))
                throw new ArgumentException("Invalid player index.");

            return _homePositions[playerIndex].Contains(position);
        }

        public int GetStartingPosition(int playerIndex)
        {
            if (!_startingPositions.ContainsKey(playerIndex))
                throw new ArgumentException("Invalid player index.");

            return _startingPositions[playerIndex];
        }

        
    }

}
