using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]  
public class GameServiceTests
{
    [TestMethod]  
    public void AddPlayer_ShouldIncreasePlayerCount()
    {
        // Arrange
        var gameService = new GameService();

        // Act
        bool result = gameService.AddPlayer("Alice");

        // Assert
        Assert.IsTrue(result); 
        Assert.AreEqual(1, gameService.GetPlayers().Count); 
    }

    [TestMethod]
    public void AddPlayer_ShouldReturnFalse_WhenMaxPlayersReached()
    {
        // Arrange
        var gameService = new GameService();

        
        gameService.AddPlayer("Alice");
        gameService.AddPlayer("Bob");
        gameService.AddPlayer("Charlie");
        gameService.AddPlayer("David");

        // Act
        bool result = gameService.AddPlayer("Eve"); 

        // Assert
        Assert.IsFalse(result); 
        Assert.AreEqual(4, gameService.GetPlayers().Count); 
    }
}
