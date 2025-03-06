

namespace Ludo_tests
{
    [TestClass]
    public class PieceTests
    {
        [TestClass]
        public class PieceTest
        {
            [TestMethod]
            public void TestPieceMove()
            {
                // Arrange
                Piece piece = new Piece();
                int expected = 6;

                // Act
                int actual = piece.Move(expected);

                // Assert
                Assert.AreEqual(expected, actual, "The piece did not move the expected number of steps.");

                // Output the result
                Console.WriteLine($"Piece moved {actual} steps.");
            }
        }

        public class Piece
        {
            public int Position { get; private set; }

            public Piece()
            {
                Position = 0;
            }

            public int Move(int steps)
            {
                Position += steps;
                return Position;
            }
        }
    }
}
