
namespace LudoAPI
{
    public class Token
    {
        public iBoardSpace CurrentSpace { get; internal set; }

        public void MoveTo(BoardSpace boardSpace)
        {
            if (CurrentSpace != null)
            {
                CurrentSpace.ReleaseToken(this);
            }
            CurrentSpace = boardSpace;
            CurrentSpace.ReciveToken(this);
        }
    }
}