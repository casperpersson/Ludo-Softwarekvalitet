using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_tests
{
    namespace Ludo_tests
    {
        public class Piece
        {
            public Player Owner { get; }
            public int Position { get; private set; }
            public bool IsAtHome { get; private set; }

            public Piece(Player owner)
            {
                Owner = owner;
                SendHome();
            }

            public void MoveTo(int position)
            {
                Position = position;
                IsAtHome = false;
            }

            public void SendHome()
            {
                Position = -1;
                IsAtHome = true;
            }
        }
    }

}
