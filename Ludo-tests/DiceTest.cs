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
            if (dice.LastRoll == 6)
            {
                Assert.AreEqual("You rolled a 6", result);
            }
            else
            {
                Assert.AreEqual($"You rolled a {dice.LastRoll}", result);
            }

            // Output the result
            Console.WriteLine(result);
        }
    }

    // Placeholder for the Dice class
    public class Dice
    {
        public int LastRoll { get; private set; }

        public int Roll()
        {
            Random random = new Random();
            LastRoll = random.Next(1, 7);
            return LastRoll;
        }

        public string RollAndCheck()
        {
            int roll = Roll();
            if (roll == 6)
            {
                return "You rolled a 6";
            }
            return $"You rolled a {roll}";
        }
    }
}