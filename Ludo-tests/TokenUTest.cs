using Newtonsoft.Json.Linq;

namespace Ludo_tests;

[TestClass]
public class TokenUTest
{
    [TestMethod]
    public void TokenMoveToBoardSpace()
    {
        BoardSpace boardSpace1 = new BoardSpace();
        Token token1 = new Token();

        token1.MoveTo(boardSpace1);

        Assert.AreSame(token1.currentSpace, boardSpace1);
    }

    [TestMethod]
    public void TokenMovedOffBoardSpace()
    {
        BoardSpace boardSpace1 = new BoardSpace();
        BoardSpace boardSpace2 = new BoardSpace();
        Token token1 = new Token();

        token1.MoveTo(boardSpace1);
        token1.MoveTo(boardSpace2);

        Assert.AreNotSame(token1.currentSpace, boardSpace1);
    }
}
