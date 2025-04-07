using LudoAPI;
namespace Ludo_tests
{
    [TestClass]
    public class TokenUTest
    {
        [TestMethod]
        public void TokenMoveToBoardSpace()
        {
            BoardSpace boardSpace1 = new BoardSpace(1);
            Token token1 = new Token();

            token1.MoveTo(boardSpace1);

            Assert.AreSame(token1.CurrentSpace, boardSpace1);
        }

        [TestMethod]
        public void TokenMovedOffBoardSpace()
        {
            BoardSpace boardSpace1 = new BoardSpace(1);
            BoardSpace boardSpace2 = new BoardSpace(2);
            Token token1 = new Token();

            token1.MoveTo(boardSpace1);
            token1.MoveTo(boardSpace2);

            Assert.AreNotSame(token1.CurrentSpace, boardSpace1);
        }
    }
}