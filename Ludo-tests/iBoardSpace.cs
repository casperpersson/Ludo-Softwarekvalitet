using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_tests
{
    public interface iBoardSpace
    {
        void ReciveToken(Token token);
        void ReleaseToken(Token token);
    }
}
