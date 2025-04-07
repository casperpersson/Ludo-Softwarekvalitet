using LudoAPI;

namespace Ludo_tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void BoardSpaceAddlinkToNextBoardSpace()
        {
            BoardSpace boardSpace1 = new BoardSpace(1);
            BoardSpace boardSpace2 = new BoardSpace(2);

            boardSpace1.NextSpace = boardSpace2;

            Assert.IsNotNull(boardSpace1.NextSpace);
        }

        [TestMethod]
        public void BoardSpaceGetNextBoardSpace()
        {
            BoardSpace boardSpace1 = new BoardSpace(1);
            BoardSpace boardSpace2 = new BoardSpace(2);

            boardSpace1.NextSpace = boardSpace2;

            Assert.AreNotSame(boardSpace1, boardSpace2);
        }

        [TestMethod]
        public void BoardSpaceTokenMoveUnto()
        {
            BoardSpace boardSpace1 = new BoardSpace(1);
            Token token1 = new Token();

            boardSpace1.ReciveToken(token1);
            boardSpace1.GetTokens();

            Assert.IsTrue(boardSpace1.GetTokens().Contains(token1));
        }

        [TestMethod]
        public void BoardSpaceTokenMoveOff()
        {
            BoardSpace boardSpace1 = new BoardSpace(1);
            Token token1 = new Token();

            boardSpace1.ReciveToken(token1);
            boardSpace1.ReleaseToken(token1);

            Assert.IsFalse(boardSpace1.GetTokens().Contains(token1));
        }
    }
}