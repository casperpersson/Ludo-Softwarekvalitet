using LudoAPI.Models;
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
                Assert.AreEqual("you rolled a 6", result);
            }
            else
            {
                Assert.AreEqual($"you rolled a {dice.Result}", result);
            }
        }
    //    [TestMethod]
    //    public void RollDie_ShouldAllowExtraTurnOnSix()
    //    {
    //        // Arrange
    //        var game = new Game();
    //        game.Initialize();
    //        var dice = new Mock<Dice>();
    //        dice.SetupSequence(d => d.Roll()).Returns(6).Returns(4); // Simulate rolling a 6 and then a 4
    //        game.SetDice(dice.Object);

    //        // Act
    //        int firstRoll = game.RollDie();
    //        int secondRoll = game.RollDie();

    //        // Assert
    //        Assert.AreEqual(6, firstRoll);
    //        Assert.AreEqual(4, secondRoll);
    //        Assert.AreEqual(0, game.ConsecutiveSixes); // Counter should reset after non-six
    //    }
    //    [TestMethod]
    //    public void RollDie_ShouldEndTurnAfterThreeConsecutiveSixes()
    //    {
    //        // Arrange
    //        var game = new Game();
    //        var dice = new Dice();
    //        game.Initialize();
    //        var dice = new Mock<Dice>();
    //        dice.SetupSequence(d => d.Roll()).Returns(6).Returns(6).Returns(6); // Simulate rolling three sixes
    //        game.SetDice(dice.Object);

    //        // Act
    //        int firstRoll = game.RollDie();
    //        int secondRoll = game.RollDie();
    //        int thirdRoll = game.RollDie();

    //        // Assert
    //        Assert.AreEqual(6, firstRoll);
    //        Assert.AreEqual(6, secondRoll);
    //        Assert.AreEqual(6, thirdRoll);
    //        Assert.AreEqual(0, game.ConsecutiveSixes); // Counter should reset after three sixes
    //        Assert.AreNotEqual(game.CurrentPlayer, game.Players[0]); // Turn should advance
    //    }

    }
}