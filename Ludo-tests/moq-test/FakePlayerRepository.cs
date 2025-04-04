using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_tests
{
    public class FakePlayerRepository : IPlayerRepository
    {
        public Player GetPlayerByName(string name)
        {
            Thread.Sleep(100); // Simuler langsom database
            return new Player { Name = name, Color = "Red" };
        }
    }
}
