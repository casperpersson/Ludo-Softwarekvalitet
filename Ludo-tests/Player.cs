using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_tests
{
    public class Player
    {
        public string Name { get; set; }
        public string Color { get; set; } // fx "Red", "Blue"
        public List<int> Tokens { get; set; } = new List<int> { -1, -1, -1, -1 }; // start i base
    }

}
