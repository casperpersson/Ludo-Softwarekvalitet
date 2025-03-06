using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiceGame.Tests
{
    [TestClass]
    public class DiceTests
    {
        [TestMethod]
        public void RollDice_ShouldReturnNumberBetween1And6()
        {
            // Arrange
            var dice = new Dice();

            // Act
            var result = dice.Roll();

            // Assert
            Assert.IsTrue(result >= 1 && result <= 6, "Dice roll should be between 1 and 6.");
        }
    }
}
