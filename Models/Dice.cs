using LudoAPI.Models;
namespace Models
{
    public class Dice
    {
        public int Result { get; set; }
        public int LastRoll { get; set; }
        public int ConsecutiveSixes { get; private set; } = 0;

        public void ResetConsecutiveSixes()
        {
            ConsecutiveSixes = 0;
        }

        public int Roll()
        {
            Random random = new Random();
            Result = random.Next(1, 7);
            return Result;
        }

        private Dice _dice = new Dice();

        public int RollDie()
        {
            int roll = _dice.Roll();

            if (roll == 6)
            {
                ConsecutiveSixes++;

                if (ConsecutiveSixes == 3)
                {
                    // End the turn after three consecutive sixes
                    ResetConsecutiveSixes();
                    Game.NextTurn();
                    return roll;
                }

                // Allow the player to roll again
                return roll;
            }

            // Reset the counter if a non-six is rolled
            ResetConsecutiveSixes();
            return roll;
        }

        public string RollAndCheck()
        {
            int roll = Roll();
            if (roll == 6)
            {
                return $"You rolled a {roll}";
            }
            else
            {
                return $"you rolled a {roll}";
            }
                
        }
    }
}
