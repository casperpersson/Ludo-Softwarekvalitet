using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

[TestClass]
public class GameServiceTests
{
    [TestMethod]
    public void AddPlayer_ShouldIncreasePlayerCount()
    {
        var gameService = new GameService();
        bool result = gameService.AddPlayer("Alice", "Red");
        Assert.IsTrue(result);
        Assert.AreEqual(1, gameService.GetPlayers().Count);
    }

    [TestMethod]
    public void AddPlayer_ShouldReturnFalse_WhenMaxPlayersReached()
    {
        var gameService = new GameService();
        gameService.AddPlayer("Alice", "Red");
        gameService.AddPlayer("Bob", "Blue");
        gameService.AddPlayer("Charlie", "Green");
        gameService.AddPlayer("David", "Yellow");

        bool result = gameService.AddPlayer("Eve", "Purple");

        Assert.IsFalse(result);
        Assert.AreEqual(4, gameService.GetPlayers().Count);
    }

    [TestMethod]
    public void RemovePlayer_ShouldDecreasePlayerCount()
    {
        var gameService = new GameService();
        gameService.AddPlayer("Alice", "Red");
        gameService.AddPlayer("Bob", "Blue");

        bool result = gameService.RemovePlayer("Alice");

        Assert.IsTrue(result);
        Assert.AreEqual(1, gameService.GetPlayers().Count);
        Assert.IsFalse(gameService.GetPlayers().Any(p => p.Name == "Alice"));
    }

    [TestMethod]
    public void HasPlayerWon_ShouldReturnTrue_WhenAllTokensAreAtGoal()
    {
        var gameService = new GameService();
        gameService.AddPlayer("Alice", "Red");

        var alice = gameService.GetPlayers().First(p => p.Name == "Alice");
        alice.Tokens = new List<int> { 57, 57, 57, 57 };

        bool hasWon = gameService.HasPlayerWon(alice);

        Assert.IsTrue(hasWon);
    }

    [TestMethod]
    public void HasPlayerWon_ShouldReturnFalse_WhenNotAllTokensAreAtGoal()
    {
        var gameService = new GameService();
        gameService.AddPlayer("Bob", "Blue");

        var bob = gameService.GetPlayers().First(p => p.Name == "Bob");
        bob.Tokens = new List<int> { 57, 57, 57, 10 };

        bool hasWon = gameService.HasPlayerWon(bob);

        Assert.IsFalse(hasWon);
    }
}
