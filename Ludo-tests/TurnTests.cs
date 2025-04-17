using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LudoGame;
using Ludo_tests;
using Ludo_tests.Ludo_tests;

namespace LudoGame.Tests
{
    [TestClass]
    public class TurnTests
    {
        [TestMethod]
        public void Game_ShouldStartWithFirstPlayerTurn()
        {
            var players = new List<Player> { new Player("Spiller 1"), new Player("Spiller 2") };
            var game = new Game(players);
            Assert.AreEqual("Spiller 1", game.GetCurrentPlayer().Name);
        }

        [TestMethod]
        public void NextTurn_ShouldGoToNextPlayer()
        {
            var players = new List<Player> { new Player("Spiller 1"), new Player("Spiller 2") };
            var game = new Game(players);
            game.NextTurn();
            Assert.AreEqual("Spiller 2", game.GetCurrentPlayer().Name);
        }

        [TestMethod]
        public void Player_ShouldGetExtraTurn_WhenRollingSix()
        {
            var players = new List<Player> { new Player("Spiller 1"), new Player("Spiller 2") };
            var game = new Game(players);
            game.RollDice(6);
            Assert.AreEqual("Spiller 1", game.GetCurrentPlayer().Name);
        }

        [TestMethod]
         public void Piece_ShouldSendOpponentHome_WhenLandingOnSameField()
        {
            // Arrange
            var player1 = new Player("Player 1");
            var player2 = new Player("Player 2");

            var piece1 = new Piece(player1);
            var piece2 = new Piece(player2);

            var board = new Board();

            // Placer modstanderens brik på felt 8
            piece2.MoveTo(8);
            board.PlacePiece(piece2, 8);

            // Act: Player 1 lander samme sted
            board.PlacePiece(piece1, 8);

            // Assert: Brik 2 skal sendes hjem, og brik 1 skal stå der
            Assert.IsTrue(piece2.IsAtHome, "Brik 2 burde være sendt hjem.");
            Assert.AreEqual(8, piece1.Position, "Brik 1 burde stå på felt 8.");
        }

    }
}
