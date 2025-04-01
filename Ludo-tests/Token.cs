
namespace Ludo_tests
{
    public class Token
    {
        public iBoardSpace currentSpace { get; internal set; }

        public void MoveTo(BoardSpace boardSpace)
        {
            if (currentSpace != null)
            {
                currentSpace.ReleaseToken(this);
            }
            currentSpace = boardSpace;
            currentSpace.ReciveToken(this);
        }
    }
}