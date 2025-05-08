using LudoAPI.Models;
using Models;

namespace Ludo_tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void GameInitialization_ShouldCreateBoardAndPlayers()
        {
            // Arrange
            var game = new Game();

            // Act
            game.Initialize();

            // Assert
            Assert.IsNotNull(game.Board);
            Assert.AreEqual(4, game.Players.Count); // Assuming 4 players
            foreach (var player in game.Players)
            {
                Assert.AreEqual(4, player.Tokens.Count); // Each player has 4 tokens
                foreach (var token in player.Tokens)
                {
                    Assert.AreEqual(TokenState.AtStart, token.State);
                }
            }
        }

        [TestMethod]
        public void NextTurn_ShouldAdvanceToNextPlayer()
        {
            // Arrange
            var game = new Game();
            game.Initialize();

            // Act
            var initialPlayer = game.CurrentPlayer;
            game.NextTurn();
            var nextPlayer = game.CurrentPlayer;

            // Assert
            Assert.AreNotEqual(initialPlayer, nextPlayer);
        }
        [TestMethod]
        public void MoveToken_ShouldCaptureOpponentToken()
        {
            // Arrange
            var game = new Game();
            game.Initialize();
            var player1 = game.Players[0];
            var player2 = game.Players[1];
            var token1 = player1.Tokens[0];
            var token2 = player2.Tokens[0];

            token1.State = TokenState.OnBoard;
            token1.Position = 5;

            token2.State = TokenState.OnBoard;
            token2.Position = 5;

            // Act
            game.CaptureToken(token1);

            // Assert
            Assert.AreEqual(TokenState.AtStart, token2.State);
            Assert.IsNull(token2.Position);
        }
        [TestMethod]
        public void EnterBoard_ShouldSetTokenPositionToStartingPosition()
        {
            // Arrange
            var game = new Game();
            game.Initialize();
            var player = game.CurrentPlayer;
            var token = player.Tokens[0];

            // Act
            game.EnterBoard(token);

            // Assert
            Assert.AreEqual(TokenState.OnBoard, token.State);
            Assert.AreEqual(game.Board.GetStartingPosition(game.CurrentPlayerIndex), token.Position);
        }
        [TestMethod]
        public void IsHomePosition_ShouldReturnTrueForHomePosition()
        {
            // Arrange
            var board = new Board();

            // Act
            var isHome = board.IsHomePosition(40, 0); // Player 1's home position

            // Assert
            Assert.IsTrue(isHome);
        }

        [TestMethod]
        public void IsHomePosition_ShouldReturnFalseForNonHomePosition()
        {
            // Arrange
            var board = new Board();

            // Act
            var isHome = board.IsHomePosition(10, 0); // Not a home position for Player 1

            // Assert
            Assert.IsFalse(isHome);
        }

    }
}
