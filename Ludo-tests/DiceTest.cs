using LudoAPI.Models;
using Models;
using Moq;
using FluentAssertions;

namespace Ludo_tests
{
    [TestClass]
    public class DiceTest
    {
        [TestMethod]
        public void TestDiceRoll()
        {
            // Arrange
            Dice dice = new Dice();

            // Act
            int diceRoll = dice.Roll();

            // Assert
            diceRoll.Should().BeInRange(1, 6, "a dice roll should always be between 1 and 6");
        }

        [TestMethod]
        public void TestSpecialTextForSix()
        {
            // Arrange
            Dice dice = new Dice();

            // Act
            string result = dice.RollAndCheck();

            // Assert
            if (dice.Result == 6)
            {
                result.Should().Be("you rolled a 6", "the special text should be displayed when rolling a 6");
            }
            else
            {
                result.Should().Be($"you rolled a {dice.Result}", "the result text should match the rolled value");
            }
        }

        [TestMethod]
        public void RollDie_ShouldAllowExtraTurnOnSix()
        {
            // Arrange  
            var settings = new GameSettings(); // Create a GameSettings instance  
            var game = new Game(settings); // Pass the settings to the Game constructor  
            game.Initialize();
            var dice = new Mock<Dice>();
            dice.SetupSequence(d => d.Roll()).Returns(6).Returns(4); // Simulate rolling a 6 and then a 4  

            // Act  
            int firstRoll = dice.Object.Roll(); // Use dice.Object to access the mocked Dice instance  
            int secondRoll = dice.Object.Roll();

            // Assert  
            firstRoll.Should().Be(6, "rolling a 6 should allow an extra turn");
            secondRoll.Should().Be(4, "the second roll should match the mocked value");
            game.ConsecutiveSixes.Should().Be(0, "the counter should reset after rolling a non-six");
        }

        [TestMethod]
        public void RollDie_ShouldEndTurnAfterThreeConsecutiveSixes()
        {
            // Arrange  
            var settings = new GameSettings(); // Create a GameSettings instance  
            var game = new Game(settings); // Pass the settings to the Game constructor  
            var dice = new Mock<Dice>();
            game.Initialize();
            dice.SetupSequence(d => d.Roll()).Returns(6).Returns(6).Returns(6); // Simulate rolling three sixes  

            // Act  
            int firstRoll = dice.Object.Roll();
            int secondRoll = dice.Object.Roll();
            int thirdRoll = dice.Object.Roll();

            // Assert  
            firstRoll.Should().Be(6, "the first roll should be a six");
            secondRoll.Should().Be(6, "the second roll should be a six");
            thirdRoll.Should().Be(6, "the third roll should be a six");
            game.ConsecutiveSixes.Should().Be(0, "the counter should reset after three consecutive sixes");
            game.CurrentPlayer.Should().NotBe(game.Players[0], "the turn should advance after three consecutive sixes");
        }
    }
}
