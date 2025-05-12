namespace LudoAPI.Services.Interfaces
{
    public interface IDiceService
    {
        int Roll();
        void ResetConsecutiveSixes();
    }
}
