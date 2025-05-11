using LudoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Token
    {
        public TokenState State { get; set; }
        public int? Position { get; set; }

        
    }
    public enum TokenState
    {
        AtStart,
        OnBoard,
        InHome
    }

}
