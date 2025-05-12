using LudoAPI.Services.Interfaces;

namespace LudoAPI.Services
{
    public class DiceService : IDiceService
    {
        private int _consecutiveSixes = 0;
        private Random _random = new();

        public int Roll()
        {
            int result = _random.Next(1, 7);
            _consecutiveSixes = (result == 6) ? _consecutiveSixes + 1 : 0;
            return result;
        }

        public void ResetConsecutiveSixes()
        {
            _consecutiveSixes = 0;
        }
    }
}
