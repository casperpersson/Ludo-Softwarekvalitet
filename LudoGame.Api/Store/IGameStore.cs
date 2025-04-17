using LudoGame.Core;
using LudoGame.Core.Dice;
using LudoGame.Core.Enums;
using System.ComponentModel;


namespace LudoGame.Api.Store
{
    
    public interface IGameStore
    {
        TrackedGame Create(IEnumerable<PlayerColor> colors, IDice dice);
        TrackedGame? Get(Guid id);
    }
    
}
