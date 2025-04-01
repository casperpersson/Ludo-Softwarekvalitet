using Models;
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
            Assert.IsTrue(diceRoll >= 1 && diceRoll <= 6, "The dice roll is out of range.");

            // Output the result
            Console.WriteLine($"Dice roll result: {diceRoll}");
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
                Assert.AreEqual("You rolled a 6", result);
            }
            else
            {
                Assert.AreEqual($"You rolled a {dice.Result}", result);
            }
        }
    }
}