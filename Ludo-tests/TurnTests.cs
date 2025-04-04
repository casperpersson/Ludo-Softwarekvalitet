using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LudoGame;
using Ludo_tests;

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
    }
}
