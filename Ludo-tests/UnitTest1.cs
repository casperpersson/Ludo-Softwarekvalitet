using Newtonsoft.Json.Linq;

namespace Ludo_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void BoardSpaceAddlinkToNextBoardSpace()
        {
            BoardSpace boardSpace1 = new BoardSpace();
            BoardSpace boardSpace2 = new BoardSpace();

            boardSpace1.NextSpace = boardSpace2;

            Assert.IsNotNull(boardSpace1.NextSpace);
        }

        [TestMethod]
        public void BoardSpaceGetNextBoardSpace()
        {
            BoardSpace boardSpace1 = new BoardSpace();
            BoardSpace boardSpace2 = new BoardSpace();

            boardSpace1.NextSpace = boardSpace2;

            Assert.AreNotSame(boardSpace1, boardSpace2);
        }


    }
}