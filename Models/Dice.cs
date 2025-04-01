namespace Models
{
    public class Dice
    {
        public int Result { get; set; }
        public int LastRoll { get; set; }

        public int Roll()
        {
            Random random = new Random();
            Result = random.Next(1, 7);
            return Result;
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
