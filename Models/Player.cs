using LudoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Player
    {
        public List<Player> Players { get; private set; }
        public List<Token> Tokens { get; set; }

        
    }
}
