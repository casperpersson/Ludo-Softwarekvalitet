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
            var settings = new GameSettings(); // Create a GameSettings instance  
            var game = new Game(settings); // Pass the settings to the Game constructor 

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
            var settings = new GameSettings(); // Create a GameSettings instance  
            var game = new Game(settings); // Pass the settings to the Game constructor 
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
            var settings = new GameSettings(); // Create a GameSettings instance  
            var game = new Game(settings); // Pass the settings to the Game constructor 
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
            var settings = new GameSettings(); // Create a GameSettings instance  
            var game = new Game(settings); // Pass the settings to the Game constructor 
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
            var board = new Board(52, true); // Provide required arguments for Board constructor  

            // Act  
            var isHome = board.IsHomePosition(40, 0); // Player 1's home position  

            // Assert  
            Assert.IsTrue(isHome);
        }

        [TestMethod]
        public void IsHomePosition_ShouldReturnFalseForNonHomePosition()
        {
            // Arrange  
            var board = new Board(52, true); // Provide required arguments for Board constructor  

            // Act  
            var isHome = board.IsHomePosition(10, 0); // Not a home position for Player 1  

            // Assert  
            Assert.IsFalse(isHome);
        }

        [TestMethod]
        public void CaptureToken_ShouldNotCaptureTokenInSafeZone()
        {
            // Arrange
            var settings = new GameSettings(); // Create a GameSettings instance  
            var game = new Game(settings); // Pass the settings to the Game constructor 
            game.Initialize();
            var player1 = game.Players[0];
            var player2 = game.Players[1];
            var token1 = player1.Tokens[0];
            var token2 = player2.Tokens[0];

            token1.State = TokenState.OnBoard;
            token1.Position = 10; // Safe zone

            token2.State = TokenState.OnBoard;
            token2.Position = 10; // Same position as token1

            // Act
            game.CaptureToken(token1);

            // Assert
            Assert.AreEqual(TokenState.OnBoard, token2.State); // Token2 should remain on the board
            Assert.AreEqual(10, token2.Position); // Position should remain unchanged
        }

        [TestMethod]
        public void CaptureToken_ShouldCaptureTokenOutsideSafeZone()
        {
            // Arrange
            var settings = new GameSettings(); // Create a GameSettings instance  
            var game = new Game(settings); // Pass the settings to the Game constructor 
            game.Initialize();
            var player1 = game.Players[0];
            var player2 = game.Players[1];
            var token1 = player1.Tokens[0];
            var token2 = player2.Tokens[0];

            token1.State = TokenState.OnBoard;
            token1.Position = 5; // Not a safe zone

            token2.State = TokenState.OnBoard;
            token2.Position = 5; // Same position as token1

            // Act
            game.CaptureToken(token1);

            // Assert
            Assert.AreEqual(TokenState.AtStart, token2.State); // Token2 should be sent back to start
            Assert.IsNull(token2.Position); // Position should be reset
        }
        [TestMethod]
        public void HasPlayerWon_ShouldReturnTrueWhenAllTokensAreInHome()
        {
            // Arrange
            var settings = new GameSettings(); // Create a GameSettings instance  
            var game = new Game(settings); // Pass the settings to the Game constructor 
            game.Initialize();
            var player = game.Players[0];
            foreach (var token in player.Tokens)
            {
                token.State = TokenState.InHome;
            }

            // Act
            bool hasWon = game.HasPlayerWon(player);

            // Assert
            Assert.IsTrue(hasWon);
        }

        [TestMethod]
        public void HasPlayerWon_ShouldReturnFalseWhenNotAllTokensAreInHome()
        {
            // Arrange
            var settings = new GameSettings(); // Create a GameSettings instance  
            var game = new Game(settings); // Pass the settings to the Game constructor 
            game.Initialize();
            var player = game.Players[0];
            player.Tokens[0].State = TokenState.InHome;
            player.Tokens[1].State = TokenState.OnBoard;

            // Act
            bool hasWon = game.HasPlayerWon(player);

            // Assert
            Assert.IsFalse(hasWon);
        }

        [TestMethod]
        public void CheckForWinner_ShouldDeclareWinnerWhenPlayerWins()
        {
            // Arrange
            var settings = new GameSettings(); // Create a GameSettings instance  
            var game = new Game(settings); // Pass the settings to the Game constructor 
            game.Initialize();
            var player = game.Players[0];
            foreach (var token in player.Tokens)
            {
                token.State = TokenState.InHome;
            }

            // Act
            game.CheckForWinner();

            // Assert
            Assert.AreEqual(player, game.Winner);
        }

    }
}
