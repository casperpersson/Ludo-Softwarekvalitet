using LudoAPI.Models;
using Models;
using Xunit;
using Assert = Xunit.Assert;

namespace Ludo_tests
{
    public class GameTests
    {
        [Theory]
        [InlineData(0, 6, 6)]
        [InlineData(1, 3, 4)]
        [InlineData(2, 0, 2)]
        public void NextTurn_ShouldCycleThroughPlayers(int initialIndex, int turns, int expectedIndex)
        {
            // Arrange
            var settings = new GameSettings { NumberOfPlayers = 4 };
            var game = new Game(settings);
            game.Initialize();
            game.GetType().GetProperty("CurrentPlayerIndex").SetValue(game, initialIndex);

            // Act
            for (int i = 0; i < turns; i++)
                game.NextTurn();

            // Assert
            Assert.Equal(expectedIndex % settings.NumberOfPlayers, game.CurrentPlayerIndex);
        }

        [Theory]
        [InlineData(TokenState.AtStart, typeof(InvalidOperationException))]
        [InlineData(TokenState.InHome, typeof(InvalidOperationException))]
        [InlineData(TokenState.OnBoard, null)]
        public void MoveToken_ThrowsOrMovesBasedOnState(TokenState initialState, Type expectedException)
        {
            // Arrange
            var settings = new GameSettings();
            var game = new Game(settings);
            game.Initialize();
            var player = game.Players[0];
            var token = player.Tokens[0];
            token.State = initialState;
            token.Position = initialState == TokenState.OnBoard ? 0 : null;

            // Act & Assert
            if (expectedException != null)
            {
                Assert.Throws(expectedException, () => game.MoveToken(player, token, 3));
            }
            else
            {
                game.MoveToken(player, token, 3);
                Assert.Equal(3, token.Position);
            }
        }

        [Theory]
        [InlineData(TokenState.AtStart, true)]
        [InlineData(TokenState.OnBoard, false)]
        [InlineData(TokenState.InHome, false)]
        public void EnterBoard_OnlyAllowsAtStart(TokenState initialState, bool shouldSucceed)
        {
            // Arrange
            var settings = new GameSettings();
            var game = new Game(settings);
            game.Initialize();
            var token = game.CurrentPlayer.Tokens[0];
            token.State = initialState;

            // Act & Assert
            if (shouldSucceed)
            {
                game.EnterBoard(token);
                Assert.Equal(TokenState.OnBoard, token.State);
                Assert.Equal(game.Board.GetStartingPosition(game.CurrentPlayerIndex), token.Position);
            }
            else
            {
                Assert.Throws<InvalidOperationException>(() => game.EnterBoard(token));
            }
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(5, false)]
        [InlineData(10, true)]
        [InlineData(15, false)]
        public void IsSafeZone_ReturnsExpected(int position, bool expected)
        {
            // Arrange
            var settings = new GameSettings { BoardSize = 56, EnableSafeZones = true };
            var game = new Game(settings);

            // Act
            var result = game.IsSafeZone(position);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(TokenState.InHome, TokenState.InHome, true)]
        [InlineData(TokenState.InHome, TokenState.OnBoard, false)]
        [InlineData(TokenState.OnBoard, TokenState.OnBoard, false)]
        public void CheckWinCondition_ReturnsExpected(TokenState t1, TokenState t2, bool expected)
        {
            // Arrange
            var settings = new GameSettings();
            var game = new Game(settings);
            game.Initialize();
            var player = game.Players[0];
            player.Tokens[0].State = t1;
            player.Tokens[1].State = t2;

            // Act
            var result = game.CheckWinCondition(player);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
