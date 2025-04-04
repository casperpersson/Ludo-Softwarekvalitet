using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_tests
{
    public interface IPlayerRepository
    {
        Player GetPlayerByName(string name);
    }

}
