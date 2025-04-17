using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame.Core.Dice
{

    /// <summary>Abstraktion over en terning (I – Interface‑Segregation).</summary>
    public interface IDice
    {
        int Roll();
    }
}
